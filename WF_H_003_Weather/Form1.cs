using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using WF_H_003_Weather.Models;

namespace WF_H_003_Weather
{
    public partial class Form1 : Form
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

        /// <summary>
        /// 最後一次查詢時的模式 (slim/orig)
        /// 若執行查詢時，模式與前次相同，就使用記憶體內的緩存資料
        /// 若否，則重新讀檔
        /// </summary>
        private string _lastQueryMode { get; set; }

        public Form1()
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

            // 更新最後查詢時的模式
            string mode = ModeSlimRb.Checked ? "slim" : "orig";
            _lastQueryMode = mode; 
            #endregion

            #region 取得所有觀測站名稱
            List<string> locationNames = new List<string>();
            foreach (Location item in _locationDatas)
            {
                string stationFullName = "(" + item.station.stationID + ") " + item.station.stationName;
                locationNames.Add(stationFullName);
            }
            LocationCb.Items.AddRange(locationNames.ToArray());
            #endregion

            #region 設定查詢種類下拉單
            string[] queryType = new string[] { "每小時統計", "每日統計" };
            QueryTypeCb.Items.AddRange(queryType);
            #endregion

            #region 設定顯示規則
            // 預設選擇「每小時統計」
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
                int sm = Convert.ToInt32(StartCb.Text.Substring(0, 2));
                int em = Convert.ToInt32(EndCb.Text.Substring(0, 2));
                if (sm > em)
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

            // 最後一次查詢時的模式 (slim/orig)
            // 若執行查詢時，模式與前次相同，就使用記憶體內的緩存資料
            // 若否，則重新讀檔
            string mode = ModeSlimRb.Checked ? "slim" : "orig";
            if (mode != _lastQueryMode)
            {
                // 重新讀檔
                C_B0024_001Model model = GetJsonData();
                _locationDatas = model.cwbdata.resources.resource.data.surfaceObs.location;
                // 更新最後查詢時的模式
                _lastQueryMode = mode;
            }

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
                // 傳入每小時資料，並設定Grid
                SetTimesGridView(target.stationObsTimes);
            }
            else
            {
                // 傳入每日資料，並設定Grid
                SetDailyGridView(target.stationObsStatistics);
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
        private void SetTimesGridView(Stationobstimes timesDatas)
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

            for (var i = 0; i < timesDatas.stationObsTime.Length; i++)
            {
                var item = timesDatas.stationObsTime[i];
                ResultGv.Rows.Add();
                ResultGv.Rows[i].Cells["時間"].Value = item.dataTime;
                ResultGv.Rows[i].Cells["氣壓"].Value = item.weatherElements.stationPressure;
                ResultGv.Rows[i].Cells["溫度"].Value = item.weatherElements.temperature;
                ResultGv.Rows[i].Cells["相對濕度"].Value = item.weatherElements.relativeHumidity;
                ResultGv.Rows[i].Cells["風速"].Value = item.weatherElements.windSpeed;
                ResultGv.Rows[i].Cells["風向"].Value = item.weatherElements.windDirectionDescription;
                ResultGv.Rows[i].Cells["降雨量"].Value = item.weatherElements.precipitation;
                ResultGv.Rows[i].Cells["日照時間"].Value = item.weatherElements.sunshineDuration;

                if (i >= 300 && timesDatas.stationObsTime.Length > 300)
                {
                    MessageBox.Show(
                        "資料筆數共" + timesDatas.stationObsTime.Length + "筆" +
                        "，因筆數過多，系統僅呈現前300筆");
                    break;
                }
            }
        }

        /// <summary>
        /// 設定「觀測站每日觀測統計紀錄」GridView
        /// </summary>
        private void SetDailyGridView(Stationobsstatistics dailyDatas)
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

            for (var i = 0; i < dailyDatas.temperature.daily.Length; i++)
            {
                var item = dailyDatas.temperature.daily[i];
                ResultGv.Rows.Add();
                ResultGv.Rows[i].Cells["日期"].Value = item.dataDate;
                ResultGv.Rows[i].Cells["最大值"].Value = item.maximum;
                ResultGv.Rows[i].Cells["最小值"].Value = item.minimum;
                ResultGv.Rows[i].Cells["平均值"].Value = item.mean;

                if (i >= 300 && dailyDatas.temperature.daily.Length > 300)
                {
                    MessageBox.Show(
                        "資料筆數共" + dailyDatas.temperature.daily.Length + "筆" +
                        "，因筆數過多，系統僅呈現前300筆");
                    break;
                }
            }
        }
    }
}
