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

        public Form1()
        {
            InitializeComponent();

            #region (每小時統計)起訖時間下拉單
            string[] hourArr = new string[24];
            for(var i = 0; i < 24; i++)
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

            #region 設定顯示規則，預設選擇「每小時統計」
            QueryTypeCb.SelectedIndex = 0;
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

            // 查詢種類
            if (QueryTypeCb.Text != "每小時統計" || QueryTypeCb.Text != "每日統計")
            {
                MessageBox.Show("請選擇查詢種類");
                return;
            }
            #endregion
        }

        /// <summary>
        /// 清除按鈕
        /// </summary>
        private void ClearBtn_Click(object sender, System.EventArgs e)
        {
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
                StartCb.Visible = true;
                EndCb.Visible = true;
                StartDtp.Visible = false;
                EndDtp.Visible = false;
            }
            else if (QueryTypeCb.Text == "每日統計")
            {
                StartCb.Visible = false;
                EndCb.Visible = false;
                StartDtp.Visible = true;
                EndDtp.Visible = true;
            }
            else
            {
                // 都沒選擇的話就全部隱藏
                StartCb.Visible = false;
                EndCb.Visible = false;
                StartDtp.Visible = false;
                EndDtp.Visible = false;
            }
        }
    }
}
