using System;
using System.Runtime.Serialization;

namespace SeraDeFlori.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }


    public class Authentification
    {
        public int Layer { get; set; }
        public bool WR { get; set; }
        public bool RR { get; set; }
        public bool ModifyAllData { get; set; }
        public bool ModifyOrdinary { get; set; }
    }


    public class LimitValues
    {
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }
        public double MinHumidity { get; set; }
        public double MaxHumidity { get; set; }
        public double MinSoilHumidity { get; set; }
        public double MaxSoilHumidity { get; set; }
        public double MinLightPercent { get; set; }

    }

    public class EnviroenmentData
    {
        public DateTime TimeStamp { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double SoilHumidity { get; set; }
        public double CarbonDioxide { get; set; }
        public double LightPercent { get; set; }
    }


    public class Credentials
    {
        public string User { get; set; }
        public string Pass { get; set; }
        public int PermissionsLayer { get; set; }
    }

    public class PermLayers
    {
        public int LayerLevel { get; set; }
        public bool WR { get; set; }
        public bool RR { get; set; }
        public bool ModifyAllData { get; set; }
        public bool ModifyOrdinary { get; set; }
    }

    public class WaterStatistics
    {
        public DateTime TimeStamp { get; set; }
        public int SecondsWatered { get; set; }
        public double SoilHumidityDif { get; set; }
        public int SecondsRemeasure { get; set; }
        public double SoilHumidityPerSecond { get; set; }
    }

    public class Malicious
    {
        public int WaterTime { get; set; }
        public int MaxPeltTimeOn { get; set; }
        public int MaxPeltTimeOff { get; set; }
        public int MeasureTime { get; set; }
        public int WaterDelayTime { get; set; }
    }


    public class Commands
    {
        public string Hot { get; set; }
        public string Cold { get; set; }
        public string Pelt { get; set; }
        public string Pump { get; set; }
        public string Light { get; set; }
    }

    public class CommandsTime
    {
        public int Hot { get; set; }
        public int Cold { get; set; }
        public int Pelt { get; set; }
        public int Pump { get; set; }
        public int Light { get; set; }
    }



    [DataContract]
    public class DataPoints
    {
        public DataPoints(DateTime label, double y)
        {
            this.Label = label;
            this.Y = y;
        }

        [DataMember(Name = "label")]
        public DateTime Label;

        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }


    




    [DataContract]
    public class PowerChartModel
    {
        public PowerChartModel(string Aparatus, double Power)
        {
            this.Aparatus = Aparatus;
            this.Power = Power;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "label")]
        public string Aparatus = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Power = null;
    }


}