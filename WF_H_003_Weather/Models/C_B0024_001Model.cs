using System;

namespace WF_H_003_Weather.Models
{
    /// <summary>
    /// 30天觀測資料-局屬地面測站觀測資料模型
    /// </summary>
    public class C_B0024_001Model
    {
        public Cwbdata cwbdata { get; set; }
    }

    public class Cwbdata
    {
        public string xsischemaLocation { get; set; }
        public string xmlns { get; set; }
        public string xmlnsxsi { get; set; }
        public string identifier { get; set; }
        public string datasetID { get; set; }

        /// <summary>
        /// 資料集名稱
        /// </summary>
        public string datasetName { get; set; }
        public string dataItemID { get; set; }
        public string sender { get; set; }
        public string sent { get; set; }
        public string status { get; set; }
        public string scope { get; set; }
        public string msgType { get; set; }
        public string publisherOID { get; set; }

        /// <summary>
        /// Resources
        /// </summary>
        public Resources resources { get; set; }
    }

    /// <summary>
    /// Resources
    /// </summary>
    public class Resources
    {
        /// <summary>
        /// Resource
        /// </summary>
        public Resource resource { get; set; }
    }

    /// <summary>
    /// Resource
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Metadata
        /// </summary>
        public Metadata metadata { get; set; }

        /// <summary>
        /// 資料
        /// </summary>
        public Data data { get; set; }
    }

    public class Metadata
    {
        public string resourceID { get; set; }
        public string resourceName { get; set; }
        public string resourceDescription { get; set; }
        public string language { get; set; }
        public string homepage { get; set; }
        public Sources sources { get; set; }
        public Temporal temporal { get; set; }
        public Spatial spatial { get; set; }
        public Weatherelements weatherElements { get; set; }
        public Statistics statistics { get; set; }
    }

    public class Sources
    {
        public Source[] source { get; set; }
    }

    public class Source
    {
        public string title { get; set; }
        public string path { get; set; }
    }

    public class Temporal
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
    }

    public class Spatial
    {
        public string description { get; set; }
        public Coordinatereferencesystem coordinateReferenceSystem { get; set; }
    }

    public class Coordinatereferencesystem
    {
        public string EPSGCode { get; set; }
        public string name { get; set; }
        public string datum { get; set; }
        public string coordinateFormat { get; set; }
    }

    public class Weatherelements
    {
        public Weatherelement[] weatherElement { get; set; }
    }

    public class Weatherelement
    {
        public string tagName { get; set; }
        public string description { get; set; }
        public string units { get; set; }
        public Specialvalues specialValues { get; set; }
        public string format { get; set; }
    }

    public class Specialvalues
    {
        public Specialvalue[] specialValue { get; set; }
    }

    public class Specialvalue
    {
        public string value { get; set; }
        public string description { get; set; }
    }

    public class Statistics
    {
        public Statisticalperiods statisticalPeriods { get; set; }
        public Weatherelement1 weatherElement { get; set; }
    }

    public class Statisticalperiods
    {
        public Statisticalperiod statisticalPeriod { get; set; }
    }

    public class Statisticalperiod
    {
        public string periodTagName { get; set; }
        public string description { get; set; }
    }

    public class Weatherelement1
    {
        public string tagName { get; set; }
        public string description { get; set; }
        public string units { get; set; }
        public Statisticalmethods statisticalMethods { get; set; }
    }

    public class Statisticalmethods
    {
        public Statisticalmethod[] statisticalMethod { get; set; }
    }

    public class Statisticalmethod
    {
        public string methodTagName { get; set; }
        public string description { get; set; }
    }

    /// <summary>
    /// 資料
    /// </summary>
    public class Data
    {
        public Surfaceobs surfaceObs { get; set; }
    }

    /// <summary>
    /// 觀測資料
    /// </summary>
    public class Surfaceobs
    {
        /// <summary>
        /// 觀測站資料列表
        /// </summary>
        public Location[] location { get; set; }
    }

    /// <summary>
    /// 觀測站資料
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 觀測站資訊
        /// </summary>
        public Station station { get; set; }

        /// <summary>
        /// 觀測站每小時觀測紀錄
        /// </summary>
        public Stationobstimes stationObsTimes { get; set; }

        /// <summary>
        /// 觀測站每日觀測統計紀錄
        /// </summary>
        public Stationobsstatistics stationObsStatistics { get; set; }
    }

    /// <summary>
    /// 觀測站資訊
    /// </summary>
    public class Station
    {
        /// <summary>
        /// 觀測站Id
        /// </summary>
        public string stationID { get; set; }

        /// <summary>
        /// 觀測站中文名
        /// </summary>
        public string stationName { get; set; }

        /// <summary>
        /// 觀測站英文名
        /// </summary>
        public string stationNameEN { get; set; }

        /// <summary>
        /// 觀測站描述
        /// </summary>
        public string stationAttribute { get; set; }
    }

    /// <summary>
    /// 觀測站每小時觀測紀錄
    /// </summary>
    public class Stationobstimes
    {
        /// <summary>
        /// 觀測站觀測紀錄列表
        /// </summary>
        public Stationobstime[] stationObsTime { get; set; }
    }

    /// <summary>
    /// 觀測站觀測紀錄
    /// </summary>
    public class Stationobstime
    {
        /// <summary>
        /// 時間
        /// </summary>
        public string dataTime { get; set; }

        /// <summary>
        /// 天氣資訊
        /// </summary>
        public Weatherelements1 weatherElements { get; set; }
    }

    /// <summary>
    /// 天氣資訊
    /// </summary>
    public class Weatherelements1
    {
        /// <summary>
        /// 氣壓
        /// </summary>
        public string stationPressure { get; set; }

        /// <summary>
        /// 溫度
        /// </summary>
        public string temperature { get; set; }

        /// <summary>
        /// 相對濕度
        /// </summary>
        public string relativeHumidity { get; set; }

        /// <summary>
        /// 風速
        /// </summary>
        public string windSpeed { get; set; }

        /// <summary>
        /// 風向
        /// </summary>
        public string windDirectionDescription { get; set; }

        /// <summary>
        /// 降雨量
        /// </summary>
        public string precipitation { get; set; }

        /// <summary>
        /// 日照時間
        /// </summary>
        public string sunshineDuration { get; set; }
    }

    /// <summary>
    /// 觀測站每日觀測統計紀錄
    /// </summary>
    public class Stationobsstatistics
    {
        /// <summary>
        /// 溫度紀錄
        /// </summary>
        public Temperature temperature { get; set; }
    }

    /// <summary>
    /// 溫度紀錄
    /// </summary>
    public class Temperature
    {
        /// <summary>
        /// 每日紀錄
        /// </summary>
        public Daily[] daily { get; set; }
    }

    /// <summary>
    /// 每日紀錄
    /// </summary>
    public class Daily
    {
        /// <summary>
        /// 日期 yyyy-MM-dd
        /// </summary>
        public string dataDate { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        public string maximum { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        public string minimum { get; set; }

        /// <summary>
        /// 平均值
        /// </summary>
        public string mean { get; set; }
    }
}
