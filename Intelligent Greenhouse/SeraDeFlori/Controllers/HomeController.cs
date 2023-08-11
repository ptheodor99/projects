using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeraDeFlori.Models;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;

namespace SeraDeFlori.Controllers
{
    public class HomeController : Controller
    {
        static Authentification AuthentificationObject = new();
        string ConectionString = "server=31.22.4.93; database=meditati_licenta_na; uid=meditati_admin_na; pwd=Alexandrueste99!";



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            string user = form["user"];
            string pass = form["password"];


            MySqlConnection connection = new MySqlConnection(ConectionString);

            connection.Open();
            string query = "SELECT PermissionsLayer FROM Credentials WHERE User = @User AND Pass = @Pass";

            MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@User", user);
            command.Parameters.AddWithValue("@Pass", pass);

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                    AuthentificationObject.Layer = (int)reader["PermissionsLayer"];
                connection.Close();


                connection.Open();
                query = "SELECT * FROM PermLayers WHERE LayerLevel = @Layer";
                command = new(query, connection);
                command.Parameters.AddWithValue("@Layer", AuthentificationObject.Layer);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AuthentificationObject.WR = (bool)reader["WR"];
                    AuthentificationObject.RR = (bool)reader["RR"];
                    AuthentificationObject.ModifyAllData = (bool)reader["ModifyAllData"];
                    AuthentificationObject.ModifyOrdinary = (bool)reader["ModifyOrdinary"];
                }
                connection.Close();



                return RedirectToAction("WhereToGo");
            }
            else
            {
                ViewBag.InvalidLogin = true;
                connection.Close();
                return View();
            }
      
        }

        public IActionResult WhereToGo()
        {

            return View();
        }

        public IActionResult ViewLimitValues()
        {
            LimitValues LimitValuesObject = new();
            MySqlConnection connection = new MySqlConnection(ConectionString);

            connection.Open();
            string query = "SELECT * FROM LimitValues";

            MySqlCommand command = new MySqlCommand(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                LimitValuesObject.MinTemp = (double)reader["MinTemp"];
                LimitValuesObject.MaxTemp = (double)reader["MaxTemp"];
                LimitValuesObject.MinHumidity = (double)reader["MinHumidity"];
                LimitValuesObject.MaxHumidity = (double)reader["MaxHumidity"];
                LimitValuesObject.MinSoilHumidity = (double)reader["MinSoilHumidity"];
                LimitValuesObject.MaxSoilHumidity = (double)reader["MaxSoilHumidity"];
                LimitValuesObject.MinLightPercent = (double)reader["MinLightPercent"];
            }

            connection.Close();

            ViewBag.LimitValuesObject = LimitValuesObject;

            return View();
        }


        public IActionResult AlterData()
        {
            return View();
        }

        public IActionResult AlterLimitValues()
        {
            if (AuthentificationObject.ModifyAllData == true)
            {
                LimitValues LimitValuesObject = new();
                MySqlConnection connection = new MySqlConnection(ConectionString);

                connection.Open();
                string query = "SELECT * FROM LimitValues";

                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    LimitValuesObject.MinTemp = (double)reader["MinTemp"];
                    LimitValuesObject.MaxTemp = (double)reader["MaxTemp"];
                    LimitValuesObject.MinHumidity = (double)reader["MinHumidity"];
                    LimitValuesObject.MaxHumidity = (double)reader["MaxHumidity"];
                    LimitValuesObject.MinSoilHumidity = (double)reader["MinSoilHumidity"];
                    LimitValuesObject.MaxSoilHumidity = (double)reader["MaxSoilHumidity"];
                    LimitValuesObject.MinLightPercent = (double)reader["MinLightPercent"];
                }

                connection.Close();

                ViewBag.LimitValuesObject = LimitValuesObject;

                return View();
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }

          
        }


        [HttpPost]
        public IActionResult AlterLimitValues(IFormCollection form)
        {
            if (AuthentificationObject.ModifyAllData == true)
            {
                LimitValues LimitValuesObject = new();
                MySqlConnection connection = new MySqlConnection(ConectionString);

                connection.Open();
                string query = "SELECT * FROM LimitValues";

                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    LimitValuesObject.MinTemp = (double)reader["MinTemp"];
                    LimitValuesObject.MaxTemp = (double)reader["MaxTemp"];
                    LimitValuesObject.MinHumidity = (double)reader["MinHumidity"];
                    LimitValuesObject.MaxHumidity = (double)reader["MaxHumidity"];
                    LimitValuesObject.MinSoilHumidity = (double)reader["MinSoilHumidity"];
                    LimitValuesObject.MaxSoilHumidity = (double)reader["MaxSoilHumidity"];
                    LimitValuesObject.MinLightPercent = (double)reader["MinLightPercent"];

                }

                connection.Close();

                if (form["MinTemp"] != "")
                    LimitValuesObject.MinTemp = Convert.ToDouble(form["MinTemp"]);
                if (form["MaxTemp"] != "")
                    LimitValuesObject.MaxTemp = Convert.ToDouble(form["MaxTemp"]);
                if (form["MinHumidity"] != "")
                    LimitValuesObject.MinHumidity = Convert.ToDouble(form["MinHumidity"]);
                if (form["MaxHumidity"] != "")
                    LimitValuesObject.MaxHumidity = Convert.ToDouble(form["MaxHumidity"]);
                if (form["MinSoilHumidity"] != "")
                    LimitValuesObject.MinSoilHumidity = Convert.ToDouble(form["MinSoilHumidity"]);
                if (form["MaxSoilHumidity"] != "")
                    LimitValuesObject.MaxSoilHumidity = Convert.ToDouble(form["MaxSoilHumidity"]);
                if (form["MinLightPercent"] != "")
                    LimitValuesObject.MinLightPercent = Convert.ToDouble(form["MinLightPercent"]);

                connection.Open();

                query = "Select Id FROM LimitValues ORDER BY Id DESC LIMIT 1";

                command = new(query, connection);
                reader = command.ExecuteReader();
                int Id = 0;

                while (reader.Read())
                    Id = (int)reader["Id"];

                reader.Close();

                query = "DELETE FROM LimitValues WHERE Id = @Id";
                command = new(query, connection);
                command.Parameters.AddWithValue("@Id", Id);
                command.ExecuteNonQuery();

                query = "INSERT INTO LimitValues VALUES (1, @MinTemp, @MaxTemp, @MinHumidity, @MaxHumidity, @MinSoilHumidity, @MaxSoilHumidity, @MinLightPercent)";
                command = new(query, connection);

                command.Parameters.AddWithValue("@MinTemp", LimitValuesObject.MinTemp);
                command.Parameters.AddWithValue("@MaxTemp", LimitValuesObject.MaxTemp);
                command.Parameters.AddWithValue("@MinHumidity", LimitValuesObject.MinHumidity);
                command.Parameters.AddWithValue("@MaxHumidity", LimitValuesObject.MaxHumidity);
                command.Parameters.AddWithValue("@MinSoilHumidity", LimitValuesObject.MinSoilHumidity);
                command.Parameters.AddWithValue("@MaxSoilHumidity", LimitValuesObject.MaxSoilHumidity);
                command.Parameters.AddWithValue("@MinLightPercent", LimitValuesObject.MinLightPercent);
                command.ExecuteNonQuery();
                connection.Close();


                ViewBag.LimitValuesObject = LimitValuesObject;

                return View();
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }

           
        }

        public IActionResult NoPermissions()
        {
            return View();
        }



        public IActionResult Reports()
        {
            List<EnviroenmentData> EnviroenmentDataList = new();
            MySqlConnection connection = new MySqlConnection(ConectionString);

            connection.Open();
            string query = "SELECT * FROM EnvData ORDER BY TimeStamp DESC LIMIT 100";

            MySqlCommand command = new MySqlCommand(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                EnviroenmentData EnviroenmentDataObject = new();
                EnviroenmentDataObject.TimeStamp = (DateTime)reader["TimeStamp"];
                EnviroenmentDataObject.Temperature = (double)reader["Temperature"];
                EnviroenmentDataObject.Humidity = (double)reader["Humidity"];
                EnviroenmentDataObject.SoilHumidity = (double)reader["SoilHumidity"];
                EnviroenmentDataObject.CarbonDioxide = (double)reader["CarbonDioxide"];
                EnviroenmentDataObject.LightPercent = (double)reader["LightPercent"];
                EnviroenmentDataList.Add(EnviroenmentDataObject);
            }

            List<DataPoints> Temperature = new();
            List<DataPoints> Humidity = new();
            List<DataPoints> SoilHumidity = new();
            List<DataPoints> CarbonDioxide = new();
            List<DataPoints> LightPercent = new();
            foreach(var x in EnviroenmentDataList)
            {
                Temperature.Add(new DataPoints(x.TimeStamp, x.Temperature));
                Humidity.Add(new DataPoints(x.TimeStamp, x.Humidity));
                SoilHumidity.Add(new DataPoints(x.TimeStamp, x.SoilHumidity));
                CarbonDioxide.Add(new DataPoints(x.TimeStamp, x.CarbonDioxide));
                LightPercent.Add(new DataPoints(x.TimeStamp, x.LightPercent));
            }
            ViewBag.Temperature = JsonConvert.SerializeObject(Temperature);
            ViewBag.Humidity = JsonConvert.SerializeObject(Humidity);
            ViewBag.SoilHumidity = JsonConvert.SerializeObject(SoilHumidity);
            ViewBag.CarbonDioxide = JsonConvert.SerializeObject(CarbonDioxide);
            ViewBag.LightPercent = JsonConvert.SerializeObject(LightPercent);

            return View();
        }


        public IActionResult AlterCredentials()
        {
            if (AuthentificationObject.ModifyAllData == true)
            {

                List<PermLayers> PermLayersList = new();

                MySqlConnection connection = new(ConectionString);

                connection.Open();

                string query = "SELECT * FROM PermLayers";

                MySqlCommand command = new(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    PermLayers PermLayersObject = new();
                    PermLayersObject.LayerLevel = (int)reader["LayerLevel"];
                    PermLayersObject.WR = (bool)reader["WR"];
                    PermLayersObject.RR = (bool)reader["RR"];
                    PermLayersObject.ModifyAllData = (bool)reader["ModifyAllData"];
                    PermLayersObject.ModifyOrdinary = (bool)reader["ModifyOrdinary"];
                    PermLayersList.Add(PermLayersObject);
                }
                
                connection.Close();

                ViewBag.PermLayersList = PermLayersList;
                List<Credentials> CredentialsList = new();
                
                 connection = new MySqlConnection(ConectionString);

                connection.Open();
                query = "SELECT * FROM Credentials";

                command = new MySqlCommand(query, connection);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Credentials CredentialsObject = new();
                    CredentialsObject.User = (string)reader["User"];
                    CredentialsObject.Pass = (string)reader["Pass"];
                    CredentialsObject.PermissionsLayer = (int)reader["PermissionsLayer"];
                    CredentialsList.Add(CredentialsObject);
                }

                connection.Close();

                ViewBag.CredentialsList = CredentialsList;

                return View();
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }

        }


        [HttpPost]
        public IActionResult AlterCredentials(IFormCollection form)
        {
            if (AuthentificationObject.ModifyAllData == true)
            {
                List<PermLayers> PermLayersList = new();

                MySqlConnection connection = new(ConectionString);

                connection.Open();

                string query = "SELECT * FROM PermLayers";

                MySqlCommand command = new(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    PermLayers PermLayersObject = new();
                    PermLayersObject.LayerLevel = (int)reader["LayerLevel"];
                    PermLayersObject.WR = (bool)reader["WR"];
                    PermLayersObject.RR = (bool)reader["RR"];
                    PermLayersObject.ModifyAllData = (bool)reader["ModifyAllData"];
                    PermLayersObject.ModifyOrdinary = (bool)reader["ModifyOrdinary"];
                    PermLayersList.Add(PermLayersObject);
                }
                ViewBag.PermLayersList = PermLayersList;
                connection.Close();

                if (form["Action"] == "add")
                {
                    
                    if(form["User"]=="" || form["Pass"] == "" || form["PermissionsLayer"] == "")
                    {
                        TempData["Message"] = "Nu puteti lasa niciun camp gol daca ati ales Adauga";
                        return RedirectToAction("MultipleError");
                    }
                    else
                    {
                        connection = new MySqlConnection(ConectionString);
                        connection.Open();

                        query = "SELECT Id FROM Credentials ORDER BY ID DESC LIMIT 1";

                        command = new(query, connection);

                        int Id = 0;

                        reader = command.ExecuteReader();

                        while (reader.Read())
                            Id = (int)reader["Id"];

                        reader.Close();


                        connection = new MySqlConnection(ConectionString);
                        connection.Open();
                        query = "INSERT INTO Credentials VALUES (@Id, @User, @Pass, @PermissionsLayer)";

                        command = new(query, connection);
                        command.Parameters.AddWithValue("@Id", Id + 1);
                        command.Parameters.AddWithValue("@User", form["User"]);
                        command.Parameters.AddWithValue("@Pass", form["Pass"]);
                        command.Parameters.AddWithValue("@PermissionsLayer", form["PermissionsLayer"]);

                        command.ExecuteNonQuery();


                        query = "SELECT * FROM Credentials";

                        command = new MySqlCommand(query, connection);

                        reader = command.ExecuteReader();
                        List<Credentials> CredentialsList = new();

                        while (reader.Read())
                        {
                            Credentials CredentialsObject = new();
                            CredentialsObject.User = (string)reader["User"];
                            CredentialsObject.Pass = (string)reader["Pass"];
                            CredentialsObject.PermissionsLayer = (int)reader["PermissionsLayer"];
                            CredentialsList.Add(CredentialsObject);
                        }

                        connection.Close();
                        ViewBag.CredentialsList = CredentialsList;

                        return View();
                    }
                }
                else if(form["Action"] == "modify")
                {
                    if (form["Users"] == "None")
                    {
                        TempData["Message"] = "Daca ati ales Modifica, atunci trebuie sa selectati un user";
                        return RedirectToAction("MultipleError");
                    }
                    else if ( form["User"] == "" && form["Pass"] == "" && form["PermissionsLayer"] == "")
                    {
                        TempData["Message"] = "Trebuie sa modificati cel putin un camp";
                        return RedirectToAction("MultipleError");
                    }
                    else
                    {
                        query = "UPDATE Credentials SET ";

                        int cnt = 0;

                        if (form["User"] != "")
                        {
                            cnt++;
                            query += "User = '";
                            query += form["User"];
                            query += "'";
                        }
                        if (form["Pass"] != "")
                        {
                            
                            if (cnt > 0)
                                query += ", ";
                            cnt++;
                            query += "Pass = '";
                            query += form["Pass"];
                            query += "'";
                        }
                        if (form["PermissionsLayer"] != "")
                        {
                            
                            if (cnt > 0)
                                query += ", ";
                            cnt++;
                            query += "PermissionsLayer = '";
                            query += form["PermissionsLayer"];
                            query += "'";
                        }

                        query += " WHERE User = '";
                        query += form["Users"];
                        query += "'";

                        connection = new MySqlConnection(ConectionString);
                        connection.Open();

                        command = new (query, connection);

                        command.ExecuteNonQuery();
                        

                        query = "SELECT * FROM Credentials";

                        command = new MySqlCommand(query, connection);

                        reader = command.ExecuteReader();
                        List<Credentials> CredentialsList = new();

                        while (reader.Read())
                        {
                            Credentials CredentialsObject = new();
                            CredentialsObject.User = (string)reader["User"];
                            CredentialsObject.Pass = (string)reader["Pass"];
                            CredentialsObject.PermissionsLayer = (int)reader["PermissionsLayer"];
                            CredentialsList.Add(CredentialsObject);
                        }
                        connection.Close();
                        ViewBag.CredentialsList = CredentialsList;


                        return View();
                    }

                }
                else
                {
                    if (form["Users"] == "None")
                    {
                        TempData["Message"] = "Trebuie sa alegi un user pe care sa il stergi";
                        return RedirectToAction("MultipleError");
                    }
                    else
                    {
                        connection = new MySqlConnection(ConectionString);
                        connection.Open();

                        query = "DELETE FROM Credentials WHERE User = @User";

                        command = new(query, connection);

                        command.Parameters.AddWithValue("@User", form["Users"]);

                        command.ExecuteNonQuery();

                        

                        query = "SELECT * FROM Credentials";

                        command = new MySqlCommand(query, connection);

                        reader = command.ExecuteReader();
                        List<Credentials> CredentialsList = new();

                        while (reader.Read())
                        {
                            Credentials CredentialsObject = new();
                            CredentialsObject.User = (string)reader["User"];
                            CredentialsObject.Pass = (string)reader["Pass"];
                            CredentialsObject.PermissionsLayer = (int)reader["PermissionsLayer"];
                            CredentialsList.Add(CredentialsObject);
                        }

                        ViewBag.CredentialsList = CredentialsList;
                        connection.Close();

                        return View();
                    }

                }
                

            }
            else
            {
                return RedirectToAction("NoPermissions");
            }

        }

        public IActionResult AlterPermLayers()
        {
            if (AuthentificationObject.ModifyAllData == true)
            {
                List<PermLayers> PermLayersList = new();

                MySqlConnection connection = new(ConectionString);

                connection.Open();

                string query = "SELECT * FROM PermLayers";

                MySqlCommand command = new(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    PermLayers PermLayersObject = new();
                    PermLayersObject.LayerLevel = (int)reader["LayerLevel"];
                    PermLayersObject.WR = (bool)reader["WR"];
                    PermLayersObject.RR = (bool)reader["RR"];
                    PermLayersObject.ModifyAllData = (bool)reader["ModifyAllData"];
                    PermLayersObject.ModifyOrdinary = (bool)reader["ModifyOrdinary"];
                    PermLayersList.Add(PermLayersObject);
                }
                ViewBag.PermLayersList = PermLayersList;
                connection.Close();
                return View();
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }

        }
        /*

        [HttpPost]
        public IActionResult AlterPermLayers(IFormCollection form)
        {
            if (AuthentificationObject.ModifyAllData == true)
            {
                if (form["Action"] == "add")
                {
                    if (form["LayerLevel"] == "" || form["WR"] == "" || form["RR"] == "" || form["ModifyAllData"] == "" || form["ModifyOrdinary"] == "")
                    {
                        TempData["Message"] = "Nu puteti lasa niciun camp gol daca ati ales Adauga";
                        return RedirectToAction("MultipleError");
                    }
                    else
                    {
                        MySqlConnection connection = new MySqlConnection(ConectionString);
                        connection.Open();

                        string query = "SELECT Id FROM PermLayers ORDER BY ID DESC LIMIT 1";

                        MySqlCommand command = new(query, connection);

                        int Id = 0;

                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                            Id = (int)reader["Id"];

                        reader.Close();


                        connection = new MySqlConnection(ConectionString);
                        connection.Open();

                        query = "INSERT INTO PermLayers VALUES (@Id, @LayerLevel, @WR, @RR, @ModifyAllData, @ModifyOrdinary)";

                        command = new(query, connection);

                        command.Parameters.AddWithValue("@Id", Id + 1);
                        command.Parameters.AddWithValue("@LayerLevel", form["LayerLevel"]);
                        command.Parameters.AddWithValue("@WR", form["WR"]);
                        command.Parameters.AddWithValue("@RR", form["RR"]);
                        command.Parameters.AddWithValue("@ModifyAllData", form["ModifyAllData"]);
                        command.Parameters.AddWithValue("@ModifyOrdinary", form["ModifyOrdinary"]);

                        command.ExecuteNonQuery();


                        query = "SELECT * FROM PermLayers";

                        command = new(query, connection);

                        reader = command.ExecuteReader();

                        List<PermLayers> PermLayersList = new();

                        while (reader.Read())
                        {
                            PermLayers PermLayersObject = new();
                            PermLayersObject.LayerLevel = (int)reader["LayerLevel"];
                            PermLayersObject.WR = (bool)reader["WR"];
                            PermLayersObject.RR = (bool)reader["RR"];
                            PermLayersObject.ModifyAllData = (bool)reader["ModifyAllData"];
                            PermLayersObject.ModifyOrdinary = (bool)reader["ModifyOrdinary"];
                            PermLayersList.Add(PermLayersObject);
                        }
                        ViewBag.PermLayersList = PermLayersList;
                        connection.Close();
                        
                        return View();
                    }
                }
                else if (form["Action"] == "modify")
                {
                    
                    if (form["Layers"] == "None")
                    {
                        TempData["Message"] = "Daca ati ales Modifica, atunci trebuie sa selectati un nivel";
                        return RedirectToAction("MultipleError");
                    }
                    else if (form["LayerLevel"] == "" && form["WR"] == "" && form["RR"] == "" && form["ModifyAllData"] == "" && form["ModifyOrdinary"] == "")
                    {
                        TempData["Message"] = "Trebuie sa modificati cel putin un camp";
                        return RedirectToAction("MultipleError");
                    }
                    else
                    {
                        string query = "UPDATE PermLayers SET ";
                        int cnt = 0;

                        if (form["LayerLevel"] != "")
                        {
                            cnt++;
                            query += "LayerLevel = ";
                            query += form["LayerLevel"];
                        }

                        if (form["WR"] != "")
                        {
                            if (cnt > 0)
                                query += ", ";
                            cnt++;
                            query += "WR = ";
                            query += form["WR"];
                        }

                        if (form["RR"] != "")
                        {
                            if (cnt > 0)
                                query += ", ";
                            cnt++;
                            query += "RR = ";
                            query += form["RR"];
                        }

                        if (form["ModifyAllData"] != "")
                        {
                            if (cnt > 0)
                                query += ", ";
                            cnt++;
                            query += "ModifyAllData = ";
                            query += form["ModifyAllData"];
                        }

                        if (form["ModifyOrdinary"] != "")
                        {
                            if (cnt > 0)
                                query += ", ";
                            cnt++;
                            query += "ModifyOrdinary = ";
                            query += form["ModifyOrdinary"];
                        }

                        query += " WHERE LayerLevel = ";
                        query += form["LayerLevel"];

                        
                        MySqlConnection connection = new MySqlConnection(ConectionString);
                        connection.Open();

                        MySqlCommand command = new(query, connection);

                        command.ExecuteNonQuery();

                        query = "SELECT * FROM PermLayers";

                        command = new(query, connection);

                        MySqlDataReader reader = command.ExecuteReader();

                        List<PermLayers> PermLayersList = new();

                        while (reader.Read())
                        {
                            PermLayers PermLayersObject = new();
                            PermLayersObject.LayerLevel = (int)reader["LayerLevel"];
                            PermLayersObject.WR = (bool)reader["WR"];
                            PermLayersObject.RR = (bool)reader["RR"];
                            PermLayersObject.ModifyAllData = (bool)reader["ModifyAllData"];
                            PermLayersObject.ModifyOrdinary = (bool)reader["ModifyOrdinary"];
                            PermLayersList.Add(PermLayersObject);
                        }
                        ViewBag.PermLayersList = PermLayersList;
                        connection.Close();
                        return View();
                    }
                }
                else
                {
                   
                    if (form["Layers"] == "None")
                    {
                        TempData["Message"] = "Trebuie sa alegi un nivel pe care sa il stergi";
                        return RedirectToAction("MultipleError");
                    }
                    else
                    {
                        MySqlConnection connection = new MySqlConnection(ConectionString);
                        connection.Open();

                        string query = "DELETE FROM PermLayers WHERE LayerLevel = @LayerLevel";

                        MySqlCommand command = new(query, connection);

                        command.Parameters.AddWithValue("@LayerLevel", form["Layers"]);

                        command.ExecuteNonQuery();

                        query = "SELECT * FROM PermLayers";

                        command = new(query, connection);

                        MySqlDataReader reader = command.ExecuteReader();

                        List<PermLayers> PermLayersList = new();

                        while (reader.Read())
                        {
                            PermLayers PermLayersObject = new();
                            PermLayersObject.LayerLevel = (int)reader["LayerLevel"];
                            PermLayersObject.WR = (bool)reader["WR"];
                            PermLayersObject.RR = (bool)reader["RR"];
                            PermLayersObject.ModifyAllData = (bool)reader["ModifyAllData"];
                            PermLayersObject.ModifyOrdinary = (bool)reader["ModifyOrdinary"];
                            PermLayersList.Add(PermLayersObject);
                        }
                        ViewBag.PermLayersList = PermLayersList;
                        connection.Close();
                        return View();
                    }


                }

            }
            else
            {
                return RedirectToAction("NoPermissions");

            }
        }
        */

        public IActionResult AlterWaterStatistics()
        {
            List<WaterStatistics> WaterStatisticsList = new();

            MySqlConnection connection = new(ConectionString);
            connection.Open();

            string query = "SELECT * FROM WaterStatistics";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                WaterStatistics WaterStatisticsObject = new();
                WaterStatisticsObject.TimeStamp = (DateTime)reader["TimeStamp"];
                WaterStatisticsObject.SecondsWatered = (int)reader["SecondsWatered"];
                WaterStatisticsObject.SoilHumidityDif = (double)reader["SoilHumidityDif"];
                WaterStatisticsObject.SecondsRemeasure = (int)reader["SecondsRemeasure"];
                WaterStatisticsObject.SoilHumidityPerSecond = (double)reader["SoilHumidityPerSecond"];
                WaterStatisticsList.Add(WaterStatisticsObject);
            }

            connection.Close();
            ViewBag.WaterStatisticsList = WaterStatisticsList;

            List<DataPoints> SoilHumidityPerSecond = new();


            double Average = 0;

            foreach(var x in WaterStatisticsList)
            {
                SoilHumidityPerSecond.Add(new DataPoints(x.TimeStamp, x.SoilHumidityPerSecond));
                Average += x.SoilHumidityPerSecond;
            }

            ViewBag.SoilHumidityPerSecond = JsonConvert.SerializeObject(SoilHumidityPerSecond);

            Average /= WaterStatisticsList.Count;

            ViewBag.Average = Average;


            return View();
        }

        public IActionResult AlterEnvData()
        {
            List<EnviroenmentData> EnviroenmentDataList = new();

            MySqlConnection connection = new(ConectionString);
            connection.Open();

            string query = "SELECT * FROM EnvData ORDER BY TimeStamp DESC LIMIT 1000";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                EnviroenmentData EnviroenmentDataObject = new();
                EnviroenmentDataObject.TimeStamp = (DateTime)reader["TimeStamp"];
                EnviroenmentDataObject.Temperature = (double)reader["Temperature"];
                EnviroenmentDataObject.Humidity = (double)reader["Humidity"];
                EnviroenmentDataObject.SoilHumidity = (double)reader["SoilHumidity"];
                EnviroenmentDataObject.CarbonDioxide = (double)reader["CarbonDioxide"];
                EnviroenmentDataObject.LightPercent = (double)reader["LightPercent"];
                EnviroenmentDataList.Add(EnviroenmentDataObject);
            }

            connection.Close();
            ViewBag.EnviroenmentDataList = EnviroenmentDataList;


            return View();
        }



        public IActionResult AlterMalicious()
        {

            if (AuthentificationObject.ModifyAllData == true)
            {
                Malicious MaliciousObject = new();
                MySqlConnection connection = new(ConectionString);
                connection.Open();


                string query = "SELECT * FROM Malicious";

                MySqlCommand command = new(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MaliciousObject.WaterTime = (int)reader["WaterTime"];
                    MaliciousObject.MaxPeltTimeOn = (int)reader["MaxPeltTimeOn"];
                    MaliciousObject.MaxPeltTimeOff = (int)reader["MaxPeltTimeOff"];
                    MaliciousObject.MeasureTime = (int)reader["MeasureTime"];
                    MaliciousObject.WaterDelayTime = (int)reader["WaterDelayTime"];
                }


                connection.Close();

                ViewBag.MaliciousObject = MaliciousObject;

                return View();

            }
            else
            {
                return RedirectToAction("NoPermissions");

            }


        }


        [HttpPost]
        public IActionResult AlterMalicious(IFormCollection form)
        {
            if (AuthentificationObject.ModifyAllData == true)
            {
                Malicious MaliciousObject = new();
                MySqlConnection connection = new(ConectionString);
                connection.Open();


                string query = "SELECT * FROM Malicious";

                MySqlCommand command = new(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MaliciousObject.WaterTime = (int)reader["WaterTime"];
                    MaliciousObject.MaxPeltTimeOn = (int)reader["MaxPeltTimeOn"];
                    MaliciousObject.MaxPeltTimeOff = (int)reader["MaxPeltTimeOff"];
                    MaliciousObject.MeasureTime = (int)reader["MeasureTime"];
                    MaliciousObject.WaterDelayTime = (int)reader["WaterDelayTime"];
                }

                reader.Close();
                connection.Close();

                

                if (form["WaterTime"] != "")
                    MaliciousObject.WaterTime = Convert.ToInt32(form["WaterTime"]);

                if (form["MaxPeltTimeOn"] != "")
                    MaliciousObject.MaxPeltTimeOn = Convert.ToInt32(form["MaxPeltTimeOn"]);

                if (form["MaxPeltTimeOff"] != "")
                    MaliciousObject.MaxPeltTimeOff = Convert.ToInt32(form["MaxPeltTimeOff"]);

                if (form["MeasureTime"] != "")
                    MaliciousObject.MeasureTime = Convert.ToInt32(form["MeasureTime"]);

                if (form["WaterDelayTime"] != "")
                    MaliciousObject.WaterDelayTime = Convert.ToInt32(form["WaterDelayTime"]);


                int Id = 0;

                query = "SELECT Id FROM Malicious";

                connection.Open();

                command = new(query, connection);

                reader = command.ExecuteReader();

                while (reader.Read())
                    Id = (int)reader["Id"];
                reader.Close();


                query = "DELETE FROM Malicious WHERE Id = @Id";

                command = new(query, connection);

                command.Parameters.AddWithValue("@Id", Id);

                command.ExecuteNonQuery();


                query = "INSERT INTO Malicious VALUES (@Id, @WaterTime, @MaxPeltTimeOn, @MaxPeltTimeOff, @MeasureTime, @WaterDelayTime)";

                command = new(query, connection);

                command.Parameters.AddWithValue("@Id", Id + 1);
                command.Parameters.AddWithValue("@WaterTime", MaliciousObject.WaterTime);
                command.Parameters.AddWithValue("@MaxPeltTimeOn", MaliciousObject.MaxPeltTimeOn);
                command.Parameters.AddWithValue("@MaxPeltTimeOff", MaliciousObject.MaxPeltTimeOff);
                command.Parameters.AddWithValue("@MeasureTime", MaliciousObject.MeasureTime);
                command.Parameters.AddWithValue("@WaterDelayTime", MaliciousObject.WaterDelayTime);

                command.ExecuteNonQuery();

                connection.Close();



                ViewBag.MaliciousObject = MaliciousObject;

                return View();

            }
            else
            {
                return RedirectToAction("NoPermissions");

            }

        }

        public IActionResult ViewMalicious()
        {

            Malicious MaliciousObject = new();
            MySqlConnection connection = new(ConectionString);
            connection.Open();


            string query = "SELECT * FROM Malicious";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MaliciousObject.WaterTime = (int)reader["WaterTime"];
                MaliciousObject.MaxPeltTimeOn = (int)reader["MaxPeltTimeOn"];
                MaliciousObject.MaxPeltTimeOff = (int)reader["MaxPeltTimeOff"];
                MaliciousObject.MeasureTime = (int)reader["MeasureTime"];
                MaliciousObject.WaterDelayTime = (int)reader["WaterDelayTime"];
            }


            connection.Close();

            ViewBag.MaliciousObject = MaliciousObject;

            return View();

        }


        public IActionResult AlterCommands()
        {

            if (AuthentificationObject.ModifyOrdinary == true)
            {
                Commands CommandsObject = new();
                CommandsTime CommandsTimeObject = new();

                MySqlConnection connection = new(ConectionString);

                string query = "SELECT * FROM Commands";

                connection.Open();

                MySqlCommand command = new(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CommandsObject.Hot = (string)reader["Hot"];
                    CommandsObject.Cold = (string)reader["Cold"];
                    CommandsObject.Pelt = (string)reader["Pelt"];
                    CommandsObject.Pump = (string)reader["Pump"];
                    CommandsObject.Light = (string)reader["Light"];
                }

                reader.Close();

               


                query = "SELECT * FROM CommandsTime";

                command = new(query, connection);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CommandsTimeObject.Hot = (int)reader["Hot"];
                    CommandsTimeObject.Cold = (int)reader["Cold"];
                    CommandsTimeObject.Pelt = (int)reader["Pelt"];
                    CommandsTimeObject.Pump = (int)reader["Pump"];
                    CommandsTimeObject.Light = (int)reader["Light"];
                }

                connection.Close();

                ViewBag.CommandsObject = CommandsObject;
                ViewBag.CommandsTimeObject = CommandsTimeObject;
                return View();
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }

            
        }

        [HttpPost]
        public IActionResult AlterCommands(IFormCollection form)
        {
            if (AuthentificationObject.ModifyOrdinary == true)
            {
                if (form["Command"] == "ON")
                {

                    if (form["Time"] == "")
                    {
                        TempData["Message"] = "Trebuie sa impui un timp daca ai ales Pornit";
                        return RedirectToAction("MultipleError");
                    }
                    else {
                        MySqlConnection connection = new(ConectionString);

                        connection.Open();

                        string query = "SELECT Id FROM Commands";

                        int IdCommand = 1;

                        MySqlCommand command = new(query, connection);

                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                            IdCommand = (int)reader["Id"];

                        reader.Close();

                        string query2 = "";

                        if (form["App"] == "Hot")
                        {
                            query = "UPDATE Commands SET Hot = 'ON' WHERE Id = @Id";
                            query2 = "UPDATE CommandsTime SET Hot = @Time WHERE Id = @Id";
                        }
                        else if (form["App"] == "Cold")
                        {
                            query = "UPDATE Commands SET Cold = 'ON' WHERE Id = @Id";
                            query2 = "UPDATE CommandsTime SET Cold = @Time WHERE Id = @Id";
                        }
                        else if (form["App"] == "Pelt")
                        {
                            query = "UPDATE Commands SET Pelt = 'ON' WHERE Id = @Id";
                            query2 = "UPDATE CommandsTime SET Pelt = @Time WHERE Id = @Id";
                        }
                        else if (form["App"] == "Pump")
                        {
                            query = "UPDATE Commands SET Pump  = 'ON' WHERE Id = @Id";
                            query2 = "UPDATE CommandsTime SET Pump = @Time WHERE Id = @Id";
                        }
                        else
                        {
                            query = "UPDATE Commands SET Light = 'ON' WHERE Id = @Id";
                            query2 = "UPDATE CommandsTime SET Light = @Time WHERE Id = @Id";
                        }
                        command = new(query, connection);

                        command.Parameters.AddWithValue("@Id", IdCommand);

                        command.ExecuteNonQuery();


                        int IdCommandsTime = 1;

                        query = "SELECT Id FROM CommandsTime";
                        command = new(query, connection);
                        reader = command.ExecuteReader();

                        while (reader.Read())
                            IdCommandsTime = (int)reader["Id"];

                        reader.Close();

                        command = new(query2, connection);
                        command.Parameters.AddWithValue("@Time", Convert.ToInt32(form["Time"]));
                        command.Parameters.AddWithValue("@Id", IdCommandsTime);

                        command.ExecuteNonQuery();

                        query = "SELECT * FROM Commands";
                        command = new(query, connection);

                        reader = command.ExecuteReader();

                        Commands CommandsObject = new();

                        while (reader.Read())
                        {
                            CommandsObject.Hot = (string)reader["Hot"];
                            CommandsObject.Cold = (string)reader["Cold"];
                            CommandsObject.Pelt = (string)reader["Pelt"];
                            CommandsObject.Pump = (string)reader["Pump"];
                            CommandsObject.Light = (string)reader["Light"];
                        }

                        reader.Close();

                        query = "SELECT * FROM CommandsTime";

                        command = new(query, connection);

                        reader = command.ExecuteReader();

                        CommandsTime CommandsTimeObject = new();

                        while (reader.Read())
                        {
                            CommandsTimeObject.Hot = (int)reader["Hot"];
                            CommandsTimeObject.Cold = (int)reader["Cold"];
                            CommandsTimeObject.Pelt = (int)reader["Pelt"];
                            CommandsTimeObject.Pump = (int)reader["Pump"];
                            CommandsTimeObject.Light = (int)reader["Light"];
                        }


                        connection.Close();

                        ViewBag.CommandsObject = CommandsObject;
                        ViewBag.CommandsTimeObject = CommandsTimeObject;
                        return View();

                    }
                }
                else
                {
                    Commands CommandsObject = new();
                    CommandsTime CommandsTimeObject = new();

                    MySqlConnection connection = new(ConectionString);

                    string query = "SELECT * FROM Commands";

                    connection.Open();

                    MySqlCommand command = new(query, connection);

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        CommandsObject.Hot = (string)reader["Hot"];
                        CommandsObject.Cold = (string)reader["Cold"];
                        CommandsObject.Pelt = (string)reader["Pelt"];
                        CommandsObject.Pump = (string)reader["Pump"];
                        CommandsObject.Light = (string)reader["Light"];
                    }

                    reader.Close();




                    query = "SELECT * FROM CommandsTime";

                    command = new(query, connection);

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        CommandsTimeObject.Hot = (int)reader["Hot"];
                        CommandsTimeObject.Cold = (int)reader["Cold"];
                        CommandsTimeObject.Pelt = (int)reader["Pelt"];
                        CommandsTimeObject.Pump = (int)reader["Pump"];
                        CommandsTimeObject.Light = (int)reader["Light"];
                    }

                    connection.Close();

                    ViewBag.CommandsObject = CommandsObject;
                    ViewBag.CommandsTimeObject = CommandsTimeObject;
                    return View();
                }



            }
            else
            {
                return RedirectToAction("NoPermissions");
            }
            return View();
        }


        public IActionResult MultipleError()
        {
            return View();
        }


        public IActionResult InformatiiFlori()
        {
            return View();
        }

       public IActionResult Trandafir()
        {
            return View();
        }

        public IActionResult Crin()
        {
            return View();
        }

        public IActionResult Lalea()
        {
            return View();
        }

        public IActionResult Garoafa()
        {
            return View();
        }

        public IActionResult Muscata()
        {
            return View();
        }

        public IActionResult Margareta()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
