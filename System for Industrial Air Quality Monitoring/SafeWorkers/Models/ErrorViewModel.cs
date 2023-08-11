using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SafeWorkers.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class DangerModel
    {
        public double H2 { get; set; }
        public double LPG { get; set; }
        public double Methane { get; set; }
        public double CO { get; set; }
        public double Alcohol { get; set; }
        public double Smoke { get; set; }
        public double Propane { get; set; }
        public double CO2 { get; set; }
        public double NH4 { get; set; }
        public double Toluene { get; set; }
        public double Acetone { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }


    public class AllModel
    {
        public double H2 { get; set; }
        public double LPG { get; set; }
        public double Methane { get; set; }
        public double CO { get; set; }
        public double Alcohol { get; set; }
        public double Smoke { get; set; }
        public double Propane { get; set; }
        public double CO2 { get; set; }
        public double NH4 { get; set; }
        public double Toluene { get; set; }
        public double Acetone { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }


    public class Authentification
    {
        public int Layer { get; set; }
        public bool WR { get; set; }
        public bool RR { get; set; }
        public bool ModifyAllData { get; set; }
        public bool ModifyOrdinary { get; set; }
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



    public class MQ2_1
    {
        public double H2 { get; set; }
        public double LPG { get; set; }
        public double Methane { get; set; }
        public double CO { get; set; }
        public double Alcohol { get; set; }
        public double Smoke { get; set; }
        public double Propane { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class MQ2_2
    {
        public double H2 { get; set; }
        public double LPG { get; set; }
        public double Methane { get; set; }
        public double CO { get; set; }
        public double Alcohol { get; set; }
        public double Smoke { get; set; }
        public double Propane { get; set; }
        public DateTime TimeStamp { get; set; }

    }

    public class MQ9_1
    {
        public double LPG { get; set; }
        public double CO { get; set; }
        public double Methane { get; set; }
        public DateTime TimeStamp { get; set; }

    }

    public class MQ9_2
    {
        public double LPG { get; set; }
        public double CO { get; set; }
        public double Methane { get; set; }
        public DateTime TimeStamp { get; set; }

    }

    public class MQ135_1
    {
        public double CO2 { get; set; }
        public double CO { get; set; }
        public double Alcohol { get; set; }
        public double NH4 { get; set; }
        public double Toluene { get; set; }
        public double Acetone { get; set; }
        public DateTime TimeStamp { get; set; }

    }

    public class MQ135_2
    {
        public double CO2 { get; set; }
        public double CO { get; set; }
        public double Alcohol { get; set; }
        public double NH4 { get; set; }
        public double Toluene { get; set; }
        public double Acetone { get; set; }
        public DateTime TimeStamp { get; set; }

    }

    public class DHT_1
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public DateTime TimeStamp { get; set; }

    }

    public class DHT_2
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public DateTime TimeStamp { get; set; }

    }

    public class EnvData
    {
        public List<MQ2_1> MQ2_1_List { get; set; }
        public List<MQ2_2> MQ2_2_List { get; set; }
        public List<MQ9_1> MQ9_1_List { get; set; }
        public List<MQ9_2> MQ9_2_List { get; set; }
        public List<MQ135_1> MQ135_1_List { get; set; }
        public List<MQ135_2> MQ135_2_List { get; set; }
        public List<DHT_1> DHT_1_List { get; set; }
        public List<DHT_2> DHT_2_List { get; set; }
    }

    
    public class Malicious
    {
        public int MeasureTime { get; set; }
        public int AlarmTime { get; set; }
    }

    public class Commands
    {
        public string Red { get; set; }
        public string Yellow { get; set; }
        public string Green { get; set; }
        public string Buzzer { get; set; }
        public string Test { get; set; }
    }

    public class CommandsTime
    {
        public int Red { get; set; }
        public int Yellow { get; set; }
        public int Green { get; set; }
        public int Buzzer { get; set; }
        public int Test { get; set; }
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
    public class DataStats
    {
        public DataStats(int label, double y)
        {
            this.Label = label;
            this.Y = y;
        }

        [DataMember(Name = "label")]
        public int Label;

        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }
    
    
}
