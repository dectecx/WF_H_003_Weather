using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using WF_H_003_Weather.Models;

namespace WF_H_003_Weather
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Json檔名
        /// </summary>
        private readonly string _jsonFileName = "C-B0024-001.json";

        /// <summary>
        /// 資料輕量化後的Json檔名(測試時使用)
        /// </summary>
        private readonly string _jsonFileNameForTest = "C-B0024-001(測試用slim版).json";

        /// <summary>
        /// 讀檔後所有觀測站資料
        /// </summary>
        private Location[] _locationDatas { get; set; }

        public MainForm()
        {
            InitializeComponent();

            #region (每小時統計)起訖時間下拉單
            string[] hourArr = new string[24];
            for (var i = 0; i < 24; i++)
            {
                hourArr[i] = i.ToString().PadLeft(2, '0') + ":00";
            }
            StartCb.Items.AddRange(hourArr);
            EndCb.Items.AddRange(hourArr);
            #endregion

            #region 取得Json資料
            C_B0024_001Model model = GetJsonData();
            _locationDatas = model.cwbdata.resources.resource.data.surfaceObs.location;
            #endregion

            #region 取得所有觀測站名稱
            string[] locationNames = GetLocationNames();
            LocationCb.Items.AddRange(locationNames);
            #endregion

            #region 設定查詢種類下拉單
            string[] queryType = new string[] { "每小時統計", "每日統計" };
            QueryTypeCb.Items.AddRange(queryType);
            #endregion

            #region 設定顯示規則
            // 觀測站預設選擇第一筆
            LocationCb.SelectedIndex = 0;
            // 查詢種類預設選擇「每小時統計」
            QueryTypeCb.SelectedIndex = 0;
            // 起始時間第一筆
            StartCb.SelectedIndex = 0;
            // 結束時間最後一筆
            EndCb.SelectedIndex = EndCb.Items.Count - 1;
            #endregion
        }

        /// <summary>
        /// 取得Json資料
        /// </summary>
        private C_B0024_001Model GetJsonData()
        {
            // 模式，ture:slim測試用輕量化資料 false:原始資料
            bool mode = ModeSlimRb.Checked;
            // 檔案路徑
            string filePath = "./Datas/";
            // 檔名
            string jsonFileName = mode ? _jsonFileNameForTest : _jsonFileName;
            // 完整路徑
            string fullFilePath = filePath + jsonFileName;
            // 讀檔
            StreamReader r = new StreamReader(fullFilePath);
            // 轉成字串
            string jsonString = r.ReadToEnd();
            // 轉成物件
            C_B0024_001Model model = JsonSerializer.Deserialize<C_B0024_001Model>(jsonString);
            return model;
        }

        /// <summary>
        /// 取得觀測站名稱清單
        /// </summary>
        /// <returns></returns>
        private string[] GetLocationNames()
        {
            #region 取得所有觀測站名稱
            List<string> locationNames = new List<string>();
            foreach (Location item in _locationDatas)
            {
                string stationFullName = "(" + item.station.stationID + ") " + item.station.stationName;
                locationNames.Add(stationFullName);
            }
            return locationNames.ToArray();
            #endregion
        }

        /// <summary>
        /// 查詢按鈕
        /// </summary>
        private void QueryBtn_Click(object sender, System.EventArgs e)
        {
            #region 防呆檢核
            // 模式
            if (!ModeSlimRb.Checked && !ModeOrigRb.Checked)
            {
                MessageBox.Show("請選擇模式");
                return;
            }

            // 觀測站
            if (LocationCb.Text.Contains("請選擇"))
            {
                MessageBox.Show("請選擇觀測站");
                return;
            }

            // 查詢種類
            if (QueryTypeCb.Text != "每小時統計" && QueryTypeCb.Text != "每日統計")
            {
                MessageBox.Show("請選擇查詢種類");
                return;
            }

            // 起訖邏輯
            if (QueryTypeCb.Text == "每小時統計")
            {
                // 取時間前兩碼(小時)，轉成數字再做比較
                int sh = Convert.ToInt32(StartCb.Text.Substring(0, 2));
                int eh = Convert.ToInt32(EndCb.Text.Substring(0, 2));
                if (sh > eh)
                {
                    MessageBox.Show("起始時間不可大於結束時間");
                    return;
                }
            }
            else if (QueryTypeCb.Text == "每日統計" && StartDtp.Value > EndDtp.Value)
            {
                MessageBox.Show("起始日期不可大於結束日期");
                return;
            }
            #endregion

            #region 從資料包內找出該筆觀測站資料
            Location target = null;
            foreach (Location item in _locationDatas)
            {
                // 左括號位置
                int left = LocationCb.Text.IndexOf("(");
                // 右括號位置
                int right = LocationCb.Text.IndexOf(")");
                // Id長度，要多扣掉左邊括號1長度
                int idLength = right - left - 1;
                // 取得Id，從左括號的下一個位置開始
                string currentId = LocationCb.Text.Substring(left + 1, idLength);
                // 從資料包內找出該筆觀測站資料，找到並設定至暫存的target後，即可break離開迴圈
                if (item.station.stationID == currentId)
                {
                    target = item;
                    break;
                }
            }

            if (target == null)
            {
                MessageBox.Show("查無資料");
                return;
            }
            #endregion

            // 清除Grid欄位
            ResultGv.Columns.Clear();
            // 清除Grid資料
            ResultGv.Rows.Clear();
            // 設定Grid欄位、資料
            if (QueryTypeCb.Text == "每小時統計")
            {
                #region 篩選資料
                // 起訖日期
                DateTime sd = StartDtp.Value;
                // 起始時間(取時間前兩碼(小時)，轉成數字再做比較)
                int sh = Convert.ToInt32(StartCb.Text.Substring(0, 2)); ;
                // 結束時間(取時間前兩碼(小時)，轉成數字再做比較)
                int eh = Convert.ToInt32(EndCb.Text.Substring(0, 2));
                // 篩選後資料
                List<Stationobstime> filter = new List<Stationobstime>();
                for (int i = 0; i < target.stationObsTimes.stationObsTime.Length; i++)
                {
                    Stationobstime item = target.stationObsTimes.stationObsTime[i];
                    // 由於C#無法直接轉換24:00:00這種格式，因此先手動將字串改成00:00:00
                    if (item.dataTime.Contains("T24:"))
                    {
                        item.dataTime = item.dataTime.Replace("T24:", "T00:");
                    }
                    // 取得日期跟時間並轉換成日期格式
                    string dtStr = item.dataTime;
                    DateTime dt = Convert.ToDateTime(dtStr);
                    // 判斷日期是否相同(避免會有時間問題，所以要用Date，只用日期部分判斷)、判斷時間是否在區間內
                    if (dt.Date == sd.Date && dt.Hour >= sh && dt.Hour <= eh)
                    {
                        filter.Add(item);
                    }
                }
                #endregion

                // 傳入「篩選後」的每小時資料，並設定Grid
                SetTimesGridView(filter.ToArray());
            }
            else
            {
                #region 篩選資料
                // 起始日期
                DateTime sd = StartDtp.Value;
                // 結束日期
                DateTime ed = EndDtp.Value;
                // 篩選後資料
                List<Daily> filter = new List<Daily>();
                for (int i = 0; i < target.stationObsStatistics.temperature.daily.Length; i++)
                {
                    Daily item = target.stationObsStatistics.temperature.daily[i];
                    // 取得日期並轉換成日期格式
                    string dtStr = item.dataDate;
                    DateTime dt = Convert.ToDateTime(dtStr);
                    // 判斷日期是否在區間內(避免會有時間問題，所以要用Date，只用日期部分判斷)
                    if (dt.Date >= sd && dt.Date <= ed)
                    {
                        filter.Add(item);
                    }
                }
                #endregion

                // 傳入「篩選後」的每日資料，並設定Grid
                SetDailyGridView(filter.ToArray());
            }
        }

        /// <summary>
        /// 清除按鈕
        /// </summary>
        private void ClearBtn_Click(object sender, System.EventArgs e)
        {
            // 清除Grid欄位
            ResultGv.Columns.Clear();
            // 清除Grid資料
            ResultGv.Rows.Clear();
        }

        /// <summary>
        /// 查詢種類下拉單
        /// </summary>
        private void QueryTypeCb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // 依據選擇的查詢種類，顯示或隱藏對應的查詢元件
            if (QueryTypeCb.Text == "每小時統計")
            {
                SELbl.Visible = true;

                // 起始日期維持顯示
                StartDtp.Visible = true;
                DtpLbl.Visible = false;
                EndDtp.Visible = false;

                StartCb.Visible = true;
                CbLbl.Visible = true;
                EndCb.Visible = true;
            }
            else if (QueryTypeCb.Text == "每日統計")
            {
                SELbl.Visible = true;

                StartDtp.Visible = true;
                DtpLbl.Visible = true;
                EndDtp.Visible = true;

                StartCb.Visible = false;
                CbLbl.Visible = false;
                EndCb.Visible = false;
            }
            else
            {
                // 都沒選擇的話就全部隱藏
                SELbl.Visible = false;

                StartDtp.Visible = false;
                DtpLbl.Visible = false;
                EndDtp.Visible = false;

                StartCb.Visible = false;
                CbLbl.Visible = false;
                EndCb.Visible = false;
            }
        }

        /// <summary>
        /// 設定「觀測站每小時觀測紀錄」GridView
        /// </summary>
        private void SetTimesGridView(Stationobstime[] timesDatas)
        {
            #region 設定Grid欄位
            string[] columns = new string[]
            {
                "時間", "氣壓", "溫度", "相對濕度",
                "風速", "風向", "降雨量", "日照時間"
            };
            foreach (string column in columns)
            {
                DataGridViewColumn gridViewColumn = new DataGridViewColumn()
                {
                    // 格子設定為一般的TextBox格子
                    CellTemplate = new DataGridViewTextBoxCell(),
                    // 資料行名稱
                    Name = column,
                    // 標題文字
                    HeaderText = column,
                    // 自動依據資料內容調整欄位寬度
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                ResultGv.Columns.Add(gridViewColumn);
            }
            #endregion

            #region 設定Grid資料
            for (int i = 0; i < timesDatas.Length; i++)
            {
                Stationobstime item = timesDatas[i];
                ResultGv.Rows.Add();
                ResultGv.Rows[i].Cells["時間"].Value = item.dataTime;
                ResultGv.Rows[i].Cells["氣壓"].Value = item.weatherElements.stationPressure;
                ResultGv.Rows[i].Cells["溫度"].Value = item.weatherElements.temperature;
                ResultGv.Rows[i].Cells["相對濕度"].Value = item.weatherElements.relativeHumidity;
                ResultGv.Rows[i].Cells["風速"].Value = item.weatherElements.windSpeed;
                ResultGv.Rows[i].Cells["風向"].Value = item.weatherElements.windDirectionDescription;
                ResultGv.Rows[i].Cells["降雨量"].Value = item.weatherElements.precipitation;
                ResultGv.Rows[i].Cells["日照時間"].Value = item.weatherElements.sunshineDuration;

                if (i >= 300 && timesDatas.Length > 300)
                {
                    MessageBox.Show(
                        "資料筆數共" + timesDatas.Length + "筆" +
                        "，因筆數過多，系統僅呈現前300筆");
                    break;
                }
            }
            #endregion
        }

        /// <summary>
        /// 設定「觀測站每日觀測統計紀錄」GridView
        /// </summary>
        private void SetDailyGridView(Daily[] dailyDatas)
        {
            #region 設定Grid欄位
            string[] columns = new string[]
            {
                "日期", "最大值", "最小值", "平均值"
            };
            foreach (string column in columns)
            {
                DataGridViewColumn gridViewColumn = new DataGridViewColumn()
                {
                    // 格子設定為一般的TextBox格子
                    CellTemplate = new DataGridViewTextBoxCell(),
                    // 資料行名稱
                    Name = column,
                    // 標題文字
                    HeaderText = column,
                    // 自動依據資料內容調整欄位寬度
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                ResultGv.Columns.Add(gridViewColumn);
            }
            #endregion

            #region 設定Grid資料
            for (int i = 0; i < dailyDatas.Length; i++)
            {
                Daily item = dailyDatas[i];
                ResultGv.Rows.Add();
                ResultGv.Rows[i].Cells["日期"].Value = item.dataDate;
                ResultGv.Rows[i].Cells["最大值"].Value = item.maximum;
                ResultGv.Rows[i].Cells["最小值"].Value = item.minimum;
                ResultGv.Rows[i].Cells["平均值"].Value = item.mean;

                if (i >= 300 && dailyDatas.Length > 300)
                {
                    MessageBox.Show(
                        "資料筆數共" + dailyDatas.Length + "筆" +
                        "，因筆數過多，系統僅呈現前300筆");
                    break;
                }
            }
            #endregion
        }

        /// <summary>
        /// 模式(Slim)選項按鈕
        /// </summary>
        private void ModeSlimRb_CheckedChanged(object sender, EventArgs e)
        {
            // 重新讀檔
            C_B0024_001Model model = GetJsonData();
            _locationDatas = model.cwbdata.resources.resource.data.surfaceObs.location;
            // 清空當前觀測站下拉選單
            LocationCb.Items.Clear();
            // 更新觀測站下拉選單
            string[] locationNames = GetLocationNames();
            LocationCb.Items.AddRange(locationNames);
        }

        /// <summary>
        /// 模式(Orig)選項按鈕
        /// </summary>
        private void ModeOrigRb_CheckedChanged(object sender, EventArgs e)
        {
            // 重新讀檔
            C_B0024_001Model model = GetJsonData();
            _locationDatas = model.cwbdata.resources.resource.data.surfaceObs.location;
            // 清空當前觀測站下拉選單
            LocationCb.Items.Clear();
            // 更新觀測站下拉選單
            string[] locationNames = GetLocationNames();
            LocationCb.Items.AddRange(locationNames);
        }
    }
}
