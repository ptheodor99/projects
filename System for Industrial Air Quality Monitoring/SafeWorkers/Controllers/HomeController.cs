using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SafeWorkers.Models;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;

namespace SafeWorkers.Controllers
{
    
    public class HomeController : Controller
    {
        static Authentification AuthentificationObject = new();
        string ConStr = "server=31.22.4.93; database=meditati_licenta_pt; uid=meditati_admin_pt; pwd=Alexandrueste99!";
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
            string password = form["password"];

            MySqlConnection connection = new MySqlConnection(ConStr);

            connection.Open();
            string query = "SELECT PermissionsLayer FROM Credentials WHERE User = @User AND Pass = @Pass";

            MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@User", user);
            command.Parameters.AddWithValue("@Pass", password);

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while(reader.Read())
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



                return RedirectToAction("PageSelect");
            }
            else
            {
                ViewBag.BadCred = true;
                connection.Close();
                return View();
            }           
        }

        public IActionResult PageSelect()
        {

            return View();
        }


        public IActionResult Danger()
        {
            DangerModel DangerModelObject = new();



            MySqlConnection connection = new MySqlConnection(ConStr);

            connection.Open();
            string query = "SELECT * FROM Danger";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                
                DangerModelObject.H2 = (double)reader["H2"];
                DangerModelObject.LPG = (double)reader["LPG"];
                DangerModelObject.Methane = (double)reader["Methane"];
                DangerModelObject.CO = (double)reader["CO"];
                DangerModelObject.Alcohol = (double)reader["Alcohol"];
                DangerModelObject.Smoke = (double)reader["Smoke"];
                DangerModelObject.Propane = (double)reader["Propane"];
                DangerModelObject.CO2 = (double)reader["CO2"];
                DangerModelObject.NH4 = (double)reader["NH4"];
                DangerModelObject.Toluene = (double)reader["Toluene"];
                DangerModelObject.Acetone = (double)reader["Acetone"];
                DangerModelObject.Temperature = (double)reader["Temperature"];
                DangerModelObject.Humidity = (double)reader["Humidity"];
            }



            connection.Close();
            return View(DangerModelObject);
        }


        public IActionResult RealTimeData()
        {

            EnvData EnvDataObject = new();

            MySqlConnection connection = new MySqlConnection(ConStr);




            //----------------------------------------------------- MQ2_1----------------------------------------------
            connection.Open();
            string query = "SELECT * FROM MQ2_1 ORDER BY TimeStamp DESC LIMIT 100";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                List<MQ2_1> MQ2_1_List = new();
                while (reader.Read())
                {
                    MQ2_1 MQ2_1_Object = new();
                    MQ2_1_Object.H2 = (double)reader["H2"];
                    MQ2_1_Object.LPG = (double)reader["LPG"];
                    MQ2_1_Object.Methane = (double)reader["Methane"];
                    MQ2_1_Object.CO = (double)reader["CO"];
                    MQ2_1_Object.Alcohol = (double)reader["Alcohol"];
                    MQ2_1_Object.Smoke = (double)reader["Smoke"];
                    MQ2_1_Object.Propane = (double)reader["Propane"];
                    MQ2_1_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                    MQ2_1_List.Add(MQ2_1_Object);
                }
                EnvDataObject.MQ2_1_List = MQ2_1_List;
            }

            connection.Close();

            List<DataPoints> MQ2_1_H2 = new();
            List<DataPoints> MQ2_1_LPG = new();
            List<DataPoints> MQ2_1_Methane = new();
            List<DataPoints> MQ2_1_CO = new();
            List<DataPoints> MQ2_1_Alcohol = new();
            List<DataPoints> MQ2_1_Smoke = new();
            List<DataPoints> MQ2_1_Propane = new();

            foreach (var x in EnvDataObject.MQ2_1_List)
            {
                MQ2_1_H2.Add(new DataPoints(x.TimeStamp, x.H2));
                MQ2_1_LPG.Add(new DataPoints(x.TimeStamp, x.LPG));
                MQ2_1_Methane.Add(new DataPoints(x.TimeStamp, x.Methane));
                MQ2_1_CO.Add(new DataPoints(x.TimeStamp, x.CO));
                MQ2_1_Alcohol.Add(new DataPoints(x.TimeStamp, x.Alcohol));
                MQ2_1_Smoke.Add(new DataPoints(x.TimeStamp, x.Smoke));
                MQ2_1_Propane.Add(new DataPoints(x.TimeStamp, x.Propane));
            }

            ViewBag.MQ2_1_H2 = JsonConvert.SerializeObject(MQ2_1_H2);
            ViewBag.MQ2_1_LPG = JsonConvert.SerializeObject(MQ2_1_LPG);
            ViewBag.MQ2_1_Methane = JsonConvert.SerializeObject(MQ2_1_Methane);
            ViewBag.MQ2_1_CO = JsonConvert.SerializeObject(MQ2_1_CO);
            ViewBag.MQ2_1_Alcohol = JsonConvert.SerializeObject(MQ2_1_Alcohol);
            ViewBag.MQ2_1_Smoke = JsonConvert.SerializeObject(MQ2_1_Smoke);
            ViewBag.MQ2_1_Propane = JsonConvert.SerializeObject(MQ2_1_Propane);








            //----------------------------------------------------- MQ9_1----------------------------------------------
            connection.Open();
            query = "SELECT * FROM MQ9_1 ORDER BY TimeStamp DESC LIMIT 100";

            command = new(query, connection);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                List<MQ9_1> MQ9_1_List = new();
                while (reader.Read())
                {
                    MQ9_1 MQ9_1_Object = new();
                    MQ9_1_Object.LPG = (double)reader["LPG"];
                    MQ9_1_Object.CO = (double)reader["CO"];
                    MQ9_1_Object.Methane = (double)reader["Methane"];
                    MQ9_1_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                    MQ9_1_List.Add(MQ9_1_Object);
                }
                EnvDataObject.MQ9_1_List = MQ9_1_List;
            }

            connection.Close();


            List<DataPoints> MQ9_1_LPG = new();
            List<DataPoints> MQ9_1_CO = new();
            List<DataPoints> MQ9_1_Methane = new();

            foreach (var x in EnvDataObject.MQ9_1_List)
            {
                MQ9_1_LPG.Add(new DataPoints(x.TimeStamp, x.LPG));
                MQ9_1_CO.Add(new DataPoints(x.TimeStamp, x.CO));
                MQ9_1_Methane.Add(new DataPoints(x.TimeStamp, x.Methane));
            }

            ViewBag.MQ9_1_LPG = JsonConvert.SerializeObject(MQ9_1_LPG);
            ViewBag.MQ9_1_CO = JsonConvert.SerializeObject(MQ9_1_CO);
            ViewBag.MQ9_1_Methane = JsonConvert.SerializeObject(MQ9_1_Methane);

            //----------------------------------------------------- MQ135_1----------------------------------------------

            connection.Open();
            query = "SELECT * FROM MQ135_1 ORDER BY TimeStamp DESC LIMIT 100";

            command = new(query, connection);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                List<MQ135_1> MQ135_1_List = new();
                while (reader.Read())
                {
                    MQ135_1 MQ135_1_Object = new();
                    MQ135_1_Object.CO2 = (double)reader["CO2"];
                    MQ135_1_Object.CO = (double)reader["CO"];
                    MQ135_1_Object.Alcohol = (double)reader["Alcohol"];
                    MQ135_1_Object.NH4 = (double)reader["NH4"];
                    MQ135_1_Object.Toluene = (double)reader["Toluene"];
                    MQ135_1_Object.Acetone = (double)reader["Acetone"];
                    MQ135_1_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                    MQ135_1_List.Add(MQ135_1_Object);
                }
                EnvDataObject.MQ135_1_List = MQ135_1_List;
            }

            connection.Close();

            List<DataPoints> MQ135_1_CO2 = new();
            List<DataPoints> MQ135_1_CO = new();
            List<DataPoints> MQ135_1_Alcohol = new();
            List<DataPoints> MQ135_1_NH4 = new();
            List<DataPoints> MQ135_1_Toluene = new();
            List<DataPoints> MQ135_1_Acetone = new();

            foreach (var x in EnvDataObject.MQ135_1_List)
            {
                MQ135_1_CO2.Add(new DataPoints(x.TimeStamp, x.CO2));
                MQ135_1_CO.Add(new DataPoints(x.TimeStamp, x.CO));
                MQ135_1_Alcohol.Add(new DataPoints(x.TimeStamp, x.Alcohol));
                MQ135_1_NH4.Add(new DataPoints(x.TimeStamp, x.NH4));
                MQ135_1_Toluene.Add(new DataPoints(x.TimeStamp, x.Toluene));
                MQ135_1_Acetone.Add(new DataPoints(x.TimeStamp, x.Acetone));

            }


            ViewBag.MQ135_1_CO2 = JsonConvert.SerializeObject(MQ135_1_CO2);
            ViewBag.MQ135_1_CO = JsonConvert.SerializeObject(MQ135_1_CO);
            ViewBag.MQ135_1_Alcohol = JsonConvert.SerializeObject(MQ135_1_Alcohol);
            ViewBag.MQ135_1_NH4 = JsonConvert.SerializeObject(MQ135_1_NH4);
            ViewBag.MQ135_1_Toluene = JsonConvert.SerializeObject(MQ135_1_Toluene);
            ViewBag.MQ135_1_Acetone = JsonConvert.SerializeObject(MQ135_1_Acetone);

            //----------------------------------------------------- DHT_1----------------------------------------------




            connection.Open();
            query = "SELECT * FROM DHT_1 ORDER BY TimeStamp DESC LIMIT 100";

            command = new(query, connection);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                List<DHT_1> DHT_1_List = new();
                while (reader.Read())
                {
                    DHT_1 DHT_1_Object = new();
                    DHT_1_Object.Temperature = (double)reader["Temperature"];
                    DHT_1_Object.Humidity = (double)reader["Humidity"];
                    DHT_1_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                    DHT_1_List.Add(DHT_1_Object);
                }
                EnvDataObject.DHT_1_List = DHT_1_List;
            }

            connection.Close();

            List<DataPoints> DHT_1_Temperature = new();
            List<DataPoints> DHT_1_Humidity = new();


            foreach (var x in EnvDataObject.DHT_1_List)
            {
                DHT_1_Temperature.Add(new DataPoints(x.TimeStamp, x.Temperature));
                DHT_1_Humidity.Add(new DataPoints(x.TimeStamp, x.Humidity));
            }

            ViewBag.DHT_1_Temperature = JsonConvert.SerializeObject(DHT_1_Temperature);
            ViewBag.DHT_1_Humidity = JsonConvert.SerializeObject(DHT_1_Humidity);









            //----------------------------------------------------- MQ2_2----------------------------------------------



            connection.Open();
            query = "SELECT * FROM MQ2_2 ORDER BY TimeStamp DESC LIMIT 100";

            command = new(query, connection);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                List<MQ2_2> MQ2_2_List = new();
                while (reader.Read())
                {
                    MQ2_2 MQ2_2_Object = new();
                    MQ2_2_Object.H2 = (double)reader["H2"];
                    MQ2_2_Object.LPG = (double)reader["LPG"];
                    MQ2_2_Object.Methane = (double)reader["Methane"];
                    MQ2_2_Object.CO = (double)reader["CO"];
                    MQ2_2_Object.Alcohol = (double)reader["Alcohol"];
                    MQ2_2_Object.Smoke = (double)reader["Smoke"];
                    MQ2_2_Object.Propane = (double)reader["Propane"];
                    MQ2_2_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                    MQ2_2_List.Add(MQ2_2_Object);
                }
                EnvDataObject.MQ2_2_List = MQ2_2_List;
            }

            connection.Close();

            List<DataPoints> MQ2_2_H2 = new();
            List<DataPoints> MQ2_2_LPG = new();
            List<DataPoints> MQ2_2_Methane = new();
            List<DataPoints> MQ2_2_CO = new();
            List<DataPoints> MQ2_2_Alcohol = new();
            List<DataPoints> MQ2_2_Smoke = new();
            List<DataPoints> MQ2_2_Propane = new();

            foreach (var x in EnvDataObject.MQ2_2_List)
            {
                MQ2_2_H2.Add(new DataPoints(x.TimeStamp, x.H2));
                MQ2_2_LPG.Add(new DataPoints(x.TimeStamp, x.LPG));
                MQ2_2_Methane.Add(new DataPoints(x.TimeStamp, x.Methane));
                MQ2_2_CO.Add(new DataPoints(x.TimeStamp, x.CO));
                MQ2_2_Alcohol.Add(new DataPoints(x.TimeStamp, x.Alcohol));
                MQ2_2_Smoke.Add(new DataPoints(x.TimeStamp, x.Smoke));
                MQ2_2_Propane.Add(new DataPoints(x.TimeStamp, x.Propane));
            }

            ViewBag.MQ2_2_H2 = JsonConvert.SerializeObject(MQ2_2_H2);
            ViewBag.MQ2_2_LPG = JsonConvert.SerializeObject(MQ2_2_LPG);
            ViewBag.MQ2_2_Methane = JsonConvert.SerializeObject(MQ2_2_Methane);
            ViewBag.MQ2_2_CO = JsonConvert.SerializeObject(MQ2_2_CO);
            ViewBag.MQ2_2_Alcohol = JsonConvert.SerializeObject(MQ2_2_Alcohol);
            ViewBag.MQ2_2_Smoke = JsonConvert.SerializeObject(MQ2_2_Smoke);
            ViewBag.MQ2_2_Propane = JsonConvert.SerializeObject(MQ2_2_Propane);




            //----------------------------------------------------- MQ9_2----------------------------------------------


            connection.Open();
            query = "SELECT * FROM MQ9_2 ORDER BY TimeStamp DESC LIMIT 100";

            command = new(query, connection);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                List<MQ9_2> MQ9_2_List = new();
                while (reader.Read())
                {
                    MQ9_2 MQ9_2_Object = new();
                    MQ9_2_Object.LPG = (double)reader["LPG"];
                    MQ9_2_Object.CO = (double)reader["CO"];
                    MQ9_2_Object.Methane = (double)reader["Methane"];
                    MQ9_2_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                    MQ9_2_List.Add(MQ9_2_Object);
                }
                EnvDataObject.MQ9_2_List = MQ9_2_List;
            }

            connection.Close();


            List<DataPoints> MQ9_2_LPG = new();
            List<DataPoints> MQ9_2_CO = new();
            List<DataPoints> MQ9_2_Methane = new();

            foreach (var x in EnvDataObject.MQ9_2_List)
            {
                MQ9_2_LPG.Add(new DataPoints(x.TimeStamp, x.LPG));
                MQ9_2_CO.Add(new DataPoints(x.TimeStamp, x.CO));
                MQ9_2_Methane.Add(new DataPoints(x.TimeStamp, x.Methane));
            }

            ViewBag.MQ9_2_LPG = JsonConvert.SerializeObject(MQ9_2_LPG);
            ViewBag.MQ9_2_CO = JsonConvert.SerializeObject(MQ9_2_CO);
            ViewBag.MQ9_2_Methane = JsonConvert.SerializeObject(MQ9_2_Methane);

            //----------------------------------------------------- MQ135_2----------------------------------------------

            connection.Open();
            query = "SELECT * FROM MQ135_2 ORDER BY TimeStamp DESC LIMIT 100";

            command = new(query, connection);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                List<MQ135_2> MQ135_2_List = new();
                while (reader.Read())
                {
                    MQ135_2 MQ135_2_Object = new();
                    MQ135_2_Object.CO2 = (double)reader["CO2"];
                    MQ135_2_Object.CO = (double)reader["CO"];
                    MQ135_2_Object.Alcohol = (double)reader["Alcohol"];
                    MQ135_2_Object.NH4 = (double)reader["NH4"];
                    MQ135_2_Object.Toluene = (double)reader["Toluene"];
                    MQ135_2_Object.Acetone = (double)reader["Acetone"];
                    MQ135_2_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                    MQ135_2_List.Add(MQ135_2_Object);
                }
                EnvDataObject.MQ135_2_List = MQ135_2_List;
            }

            connection.Close();

            List<DataPoints> MQ135_2_CO2 = new();
            List<DataPoints> MQ135_2_CO = new();
            List<DataPoints> MQ135_2_Alcohol = new();
            List<DataPoints> MQ135_2_NH4 = new();
            List<DataPoints> MQ135_2_Toluene = new();
            List<DataPoints> MQ135_2_Acetone = new();

            foreach (var x in EnvDataObject.MQ135_2_List)
            {
                MQ135_2_CO2.Add(new DataPoints(x.TimeStamp, x.CO2));
                MQ135_2_CO.Add(new DataPoints(x.TimeStamp, x.CO));
                MQ135_2_Alcohol.Add(new DataPoints(x.TimeStamp, x.Alcohol));
                MQ135_2_NH4.Add(new DataPoints(x.TimeStamp, x.NH4));
                MQ135_2_Toluene.Add(new DataPoints(x.TimeStamp, x.Toluene));
                MQ135_2_Acetone.Add(new DataPoints(x.TimeStamp, x.Acetone));

            }


            ViewBag.MQ135_2_CO2 = JsonConvert.SerializeObject(MQ135_2_CO2);
            ViewBag.MQ135_2_CO = JsonConvert.SerializeObject(MQ135_2_CO);
            ViewBag.MQ135_2_Alcohol = JsonConvert.SerializeObject(MQ135_2_Alcohol);
            ViewBag.MQ135_2_NH4 = JsonConvert.SerializeObject(MQ135_2_NH4);
            ViewBag.MQ135_2_Toluene = JsonConvert.SerializeObject(MQ135_2_Toluene);
            ViewBag.MQ135_2_Acetone = JsonConvert.SerializeObject(MQ135_2_Acetone);

            //----------------------------------------------------- DHT_2----------------------------------------------





            connection.Open();
            query = "SELECT * FROM DHT_2 ORDER BY TimeStamp DESC LIMIT 100";

            command = new(query, connection);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                List<DHT_2> DHT_2_List = new();
                while (reader.Read())
                {
                    DHT_2 DHT_2_Object = new();
                    DHT_2_Object.Temperature = (double)reader["Temperature"];
                    DHT_2_Object.Humidity = (double)reader["Humidity"];
                    DHT_2_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                    DHT_2_List.Add(DHT_2_Object);
                }
                EnvDataObject.DHT_2_List = DHT_2_List;
            }

            connection.Close();

            List<DataPoints> DHT_2_Temperature = new();
            List<DataPoints> DHT_2_Humidity = new();


            foreach (var x in EnvDataObject.DHT_2_List)
            {
                DHT_2_Temperature.Add(new DataPoints(x.TimeStamp, x.Temperature));
                DHT_2_Humidity.Add(new DataPoints(x.TimeStamp, x.Humidity));
            }

            ViewBag.DHT_2_Temperature = JsonConvert.SerializeObject(DHT_2_Temperature);
            ViewBag.DHT_2_Humidity = JsonConvert.SerializeObject(DHT_2_Humidity);


            return View();
        }

        public IActionResult AlterTabels()
        {

            return View();
        }

        

        public IActionResult AlterDanger()
        {
            if (AuthentificationObject.ModifyAllData == true)
            {
                MySqlConnection connection = new MySqlConnection(ConStr);
                connection.Open();
                string query = "SELECT * FROM Danger";

                MySqlCommand command = new(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                DangerModel DangerModelObject = new();

                while (reader.Read())
                {

                    DangerModelObject.H2 = (double)(reader["H2"]);
                    DangerModelObject.LPG = (double)reader["LPG"];
                    DangerModelObject.Methane = (double)reader["Methane"];
                    DangerModelObject.CO = (double)reader["CO"];
                    DangerModelObject.Alcohol = (double)reader["Alcohol"];
                    DangerModelObject.Smoke = (double)reader["Smoke"];
                    DangerModelObject.Propane = (double)reader["Propane"];
                    DangerModelObject.CO2 = (double)reader["CO2"];
                    DangerModelObject.NH4 = (double)reader["NH4"];
                    DangerModelObject.Toluene = (double)reader["Toluene"];
                    DangerModelObject.Acetone = (double)reader["Acetone"];
                    DangerModelObject.Temperature = (double)reader["Temperature"];
                    DangerModelObject.Humidity = (double)reader["Humidity"];
                }



                connection.Close();

                ViewBag.DangerModelObject = DangerModelObject;

                return View();
            }
            else
            {
                return RedirectToAction("PermissionError");
            }
        }

        [HttpPost]
        public IActionResult AlterDanger(IFormCollection form)
        {
            if (AuthentificationObject.ModifyAllData == true)
            {
                MySqlConnection connection = new MySqlConnection(ConStr);
                connection.Open();
                string query = "SELECT * FROM Danger";

                MySqlCommand command = new(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                DangerModel DangerModelObject = new();

                while (reader.Read())
                {

                    DangerModelObject.H2 = (double)reader["H2"];
                    DangerModelObject.LPG = (double)reader["LPG"];
                    DangerModelObject.Methane = (double)reader["Methane"];
                    DangerModelObject.CO = (double)reader["CO"];
                    DangerModelObject.Alcohol = (double)reader["Alcohol"];
                    DangerModelObject.Smoke = (double)reader["Smoke"];
                    DangerModelObject.Propane = (double)reader["Propane"];
                    DangerModelObject.CO2 = (double)reader["CO2"];
                    DangerModelObject.NH4 = (double)reader["NH4"];
                    DangerModelObject.Toluene = (double)reader["Toluene"];
                    DangerModelObject.Acetone = (double)reader["Acetone"];
                    DangerModelObject.Temperature = (double)reader["Temperature"];
                    DangerModelObject.Humidity = (double)reader["Humidity"];
                }

                connection.Close();



                if (form["H2"] != "")
                    DangerModelObject.H2 = Convert.ToDouble(form["H2"]);
                if (form["LPG"] != "")
                    DangerModelObject.LPG = Convert.ToDouble(form["LPG"]);
                if (form["Methane"] != "")
                    DangerModelObject.Methane = Convert.ToDouble(form["Methane"]);
                if (form["CO"] != "")
                    DangerModelObject.CO = Convert.ToDouble(form["CO"]);
                if (form["Alcohol"] != "")
                    DangerModelObject.Alcohol = Convert.ToDouble(form["Alcohol"]);
                if (form["Smoke"] != "")
                    DangerModelObject.Smoke = Convert.ToDouble(form["Smoke"]);
                if (form["Propane"] != "")
                    DangerModelObject.Propane = Convert.ToDouble(form["Propane"]);
                if (form["CO2"] != "")
                    DangerModelObject.CO2 = Convert.ToDouble(form["CO2"]);
                if (form["NH4"] != "")
                    DangerModelObject.NH4 = Convert.ToDouble(form["NH4"]);
                if (form["Toluene"] != "")
                    DangerModelObject.Toluene = Convert.ToDouble(form["Toluene"]);
                if (form["Acetone"] != "")
                    DangerModelObject.Acetone = Convert.ToDouble(form["Acetone"]);
                if (form["Temperature"] != "")
                    DangerModelObject.Temperature = Convert.ToDouble(form["Temperature"]);
                if (form["Humidity"] != "")
                    DangerModelObject.Humidity = Convert.ToDouble(form["Humidity"]);


                connection.Open();

                query = "SELECT Id FROM Danger ORDER BY Id DESC LIMIT 1";

                command = new(query, connection);

                reader = command.ExecuteReader();

                int Id = 0;

                while (reader.Read())
                    Id = (int)reader["Id"];


                reader.Close();

                query = "DELETE FROM Danger WHERE Id = @Id";

                command = new(query, connection);
                command.Parameters.AddWithValue("@Id", Id);
                command.ExecuteNonQuery();


                query = "INSERT INTO Danger VALUES(1, @H2, @LPG, @Methane, @CO, @Alcohol, @Smoke, @Propane, @CO2, @NH4, @Toluene, @Acetone, @Temperature, @Humidity)";
                command = new(query, connection);

                command.Parameters.AddWithValue("@H2", DangerModelObject.H2);
                command.Parameters.AddWithValue("@LPG", DangerModelObject.LPG);
                command.Parameters.AddWithValue("@Methane", DangerModelObject.Methane);
                command.Parameters.AddWithValue("@CO", DangerModelObject.CO);
                command.Parameters.AddWithValue("@Alcohol", DangerModelObject.Alcohol);
                command.Parameters.AddWithValue("@Smoke", DangerModelObject.Smoke);
                command.Parameters.AddWithValue("@Propane", DangerModelObject.Propane);
                command.Parameters.AddWithValue("@CO2", DangerModelObject.CO2);
                command.Parameters.AddWithValue("@NH4", DangerModelObject.NH4);
                command.Parameters.AddWithValue("@Toluene", DangerModelObject.Toluene);
                command.Parameters.AddWithValue("@Acetone", DangerModelObject.Acetone);
                command.Parameters.AddWithValue("@Temperature", DangerModelObject.Temperature);
                command.Parameters.AddWithValue("@Humidity", DangerModelObject.Humidity);

                command.ExecuteNonQuery();

                connection.Close();

                ViewBag.DangerModelObject = DangerModelObject;


                return View();
            }
            else
            {
                return RedirectToAction("PermissionError");
            }
        }


        public IActionResult AlterMQ2_1()
        {
            List<MQ2_1> MQ2_1_List = new();
            MySqlConnection connection = new(ConStr);

            connection.Open();

            string query = "SELECT * FROM MQ2_1 ORDER BY TimeStamp DESC LIMIT 1000";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MQ2_1 MQ2_1_Object = new();
                MQ2_1_Object.H2 = (double)reader["H2"];
                MQ2_1_Object.LPG = (double)reader["LPG"];
                MQ2_1_Object.Methane = (double)reader["Methane"];
                MQ2_1_Object.CO = (double)reader["CO"];
                MQ2_1_Object.Alcohol = (double)reader["Alcohol"];
                MQ2_1_Object.Smoke = (double)reader["Smoke"];
                MQ2_1_Object.Propane = (double)reader["Propane"];
                MQ2_1_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                MQ2_1_List.Add(MQ2_1_Object);
            }



            connection.Close();

            ViewBag.MQ2_1_List = MQ2_1_List;

            return View();
        }

        public IActionResult AlterMQ2_2()
        {
            List<MQ2_2> MQ2_2_List = new();
            MySqlConnection connection = new(ConStr);

            connection.Open();

            string query = "SELECT * FROM MQ2_2 ORDER BY TimeStamp DESC LIMIT 1000";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MQ2_2 MQ2_2_Object = new();
                MQ2_2_Object.H2 = (double)reader["H2"];
                MQ2_2_Object.LPG = (double)reader["LPG"];
                MQ2_2_Object.Methane = (double)reader["Methane"];
                MQ2_2_Object.CO = (double)reader["CO"];
                MQ2_2_Object.Alcohol = (double)reader["Alcohol"];
                MQ2_2_Object.Smoke = (double)reader["Smoke"];
                MQ2_2_Object.Propane = (double)reader["Propane"];
                MQ2_2_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                MQ2_2_List.Add(MQ2_2_Object);
            }



            connection.Close();

            ViewBag.MQ2_2_List = MQ2_2_List;

            return View();

        }

        public IActionResult AlterMQ9_1()
        {
            List<MQ9_1> MQ9_1_List = new();

            MySqlConnection connection = new(ConStr);

            connection.Open();

            string query = "SELECT * FROM MQ9_1 ORDER BY TimeStamp DESC LIMIT 1000";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MQ9_1 MQ9_1_Object = new();

                MQ9_1_Object.LPG = (double)reader["LPG"];
                MQ9_1_Object.CO = (double)reader["CO"];
                MQ9_1_Object.Methane = (double)reader["Methane"];
                MQ9_1_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                MQ9_1_List.Add(MQ9_1_Object);
            }


            connection.Close();

            ViewBag.MQ9_1_List = MQ9_1_List;

            return View();
        }

        public IActionResult AlterMQ9_2()
        {
            List<MQ9_2> MQ9_2_List = new();

            MySqlConnection connection = new(ConStr);

            connection.Open();

            string query = "SELECT * FROM MQ9_2 ORDER BY TimeStamp DESC LIMIT 1000";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MQ9_2 MQ9_2_Object = new();

                MQ9_2_Object.LPG = (double)reader["LPG"];
                MQ9_2_Object.CO = (double)reader["CO"];
                MQ9_2_Object.Methane = (double)reader["Methane"];
                MQ9_2_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                MQ9_2_List.Add(MQ9_2_Object);
            }


            connection.Close();

            ViewBag.MQ9_2_List = MQ9_2_List;

            return View();
        }


        public IActionResult AlterMQ135_1()
        {
            List<MQ135_1> MQ135_1_List = new();

            MySqlConnection connection = new(ConStr);

            connection.Open();

            string query = "SELECT * FROM MQ135_1 ORDER BY TimeStamp DESC LIMIT 1000";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MQ135_1 MQ135_1_Object = new();

                MQ135_1_Object.CO2 = (double)reader["CO2"];
                MQ135_1_Object.CO = (double)reader["CO"];
                MQ135_1_Object.Alcohol = (double)reader["Alcohol"];
                MQ135_1_Object.NH4 = (double)reader["NH4"];
                MQ135_1_Object.Toluene = (double)reader["Toluene"];
                MQ135_1_Object.Acetone = (double)reader["Acetone"];
                MQ135_1_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                MQ135_1_List.Add(MQ135_1_Object);
            }


            connection.Close();

            ViewBag.MQ135_1_List = MQ135_1_List;

            return View();
        }


        public IActionResult AlterMQ135_2()
        {

            List<MQ135_2> MQ135_2_List = new();

            MySqlConnection connection = new(ConStr);

            connection.Open();

            string query = "SELECT * FROM MQ135_2 ORDER BY TimeStamp DESC LIMIT 1000";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MQ135_2 MQ135_2_Object = new();

                MQ135_2_Object.CO2 = (double)reader["CO2"];
                MQ135_2_Object.CO = (double)reader["CO"];
                MQ135_2_Object.Alcohol = (double)reader["Alcohol"];
                MQ135_2_Object.NH4 = (double)reader["NH4"];
                MQ135_2_Object.Toluene = (double)reader["Toluene"];
                MQ135_2_Object.Acetone = (double)reader["Acetone"];
                MQ135_2_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                MQ135_2_List.Add(MQ135_2_Object);
            }


            connection.Close();

            ViewBag.MQ135_2_List = MQ135_2_List;

            return View();
        }

        public IActionResult AlterDHT_1()
        {
            List<DHT_1> DHT_1_List = new();

            MySqlConnection connection = new(ConStr);

            connection.Open();

            string query = "SELECT * FROM DHT_1 ORDER BY TimeStamp DESC LIMIT 1000";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DHT_1 DHT_1_Object = new();
                DHT_1_Object.Temperature = (double)reader["Temperature"];
                DHT_1_Object.Humidity = (double)reader["Humidity"];
                DHT_1_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                DHT_1_List.Add(DHT_1_Object);
            }

            connection.Close();

            ViewBag.DHT_1_List = DHT_1_List;

            return View();
        }


        public IActionResult AlterDHT_2()
        {
            List<DHT_2> DHT_2_List = new();

            MySqlConnection connection = new(ConStr);

            connection.Open();

            string query = "SELECT * FROM DHT_2 ORDER BY TimeStamp DESC LIMIT 1000";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DHT_2 DHT_2_Object = new();
                DHT_2_Object.Temperature = (double)reader["Temperature"];
                DHT_2_Object.Humidity = (double)reader["Humidity"];
                DHT_2_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                DHT_2_List.Add(DHT_2_Object);
            }

            connection.Close();

            ViewBag.DHT_2_List = DHT_2_List;

            return View();
        }


        public IActionResult AlterCredentials()
        {
            if (AuthentificationObject.ModifyAllData == true)
            {

                List<PermLayers> PermLayersList = new();

                MySqlConnection connection = new(ConStr);

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

                connection = new MySqlConnection(ConStr);

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
                return RedirectToAction("PermissionsError");
            }

        }



        [HttpPost]
        public IActionResult AlterCredentials(IFormCollection form)
        {
            if (AuthentificationObject.ModifyAllData == true)
            {
                List<PermLayers> PermLayersList = new();

                MySqlConnection connection = new(ConStr);

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

                    if (form["User"] == "" || form["Pass"] == "" || form["PermissionsLayer"] == "")
                    {
                        TempData["Message"] = "Nu puteti lasa niciun camp gol daca ati ales Adauga";
                        return RedirectToAction("Errors");
                    }
                    else
                    {
                        connection = new MySqlConnection(ConStr);
                        connection.Open();

                        query = "SELECT Id FROM Credentials ORDER BY ID DESC LIMIT 1";

                        command = new(query, connection);

                        int Id = 0;

                        reader = command.ExecuteReader();

                        while (reader.Read())
                            Id = (int)reader["Id"];

                        reader.Close();


                        connection = new MySqlConnection(ConStr);
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
                else if (form["Action"] == "modify")
                {
                    if (form["Users"] == "None")
                    {
                        TempData["Message"] = "Daca ati ales Modifica, atunci trebuie sa selectati un user";
                        return RedirectToAction("Errors");
                    }
                    else if (form["User"] == "" && form["Pass"] == "" && form["PermissionsLayer"] == "")
                    {
                        TempData["Message"] = "Trebuie sa modificati cel putin un camp";
                        return RedirectToAction("Errors");
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

                        connection = new MySqlConnection(ConStr);
                        connection.Open();

                        command = new(query, connection);

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
                        return RedirectToAction("Errors");
                    }
                    else
                    {
                        connection = new MySqlConnection(ConStr);
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
                return RedirectToAction("PermissionsError");
            }

        }


        public IActionResult AlterPermLayers()
        {
            if (AuthentificationObject.ModifyAllData == true)
            {
                List<PermLayers> PermLayersList = new();

                MySqlConnection connection = new(ConStr);

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
                return RedirectToAction("PermissionError");
            }

        }


        public IActionResult AlterMalicious()
        {
            if(AuthentificationObject.ModifyAllData == true)
            {
                Malicious MaliciousObject = new();

                MySqlConnection connection = new(ConStr);

                connection.Open();

                string query = "SELECT * FROM Malicious";

                MySqlCommand command = new(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MaliciousObject.MeasureTime = Convert.ToInt32(reader["MeasureTime"]);
                    MaliciousObject.AlarmTime = Convert.ToInt32(reader["AlarmTime"]);
                }

                connection.Close();

                ViewBag.MaliciousObject = MaliciousObject;

                return View();
            }
            else
            {
                return RedirectToAction("PermissionError");
            }




        }

        [HttpPost]
        public IActionResult AlterMalicious(IFormCollection form)
        {
            if (AuthentificationObject.ModifyAllData == true)
            {
                Malicious MaliciousObject = new();

                MySqlConnection connection = new(ConStr);

                connection.Open();

                if (form["MeasureTime"] != "")
                {
                    string query2 = "UPDATE Malicious SET MeasureTime = ";
                    query2 += form["MeasureTime"];

                    MySqlCommand command2 = new(query2, connection);

                    command2.ExecuteNonQuery();

                }


                if (form["AlarmTime"] != "")
                {
                    string query2 = "UPDATE Malicious SET AlarmTime = ";
                    query2 += form["AlarmTime"];

                    MySqlCommand command2 = new(query2, connection);

                    command2.ExecuteNonQuery();
                }

                string query = "SELECT * FROM Malicious";

                MySqlCommand command = new(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MaliciousObject.MeasureTime = Convert.ToInt32(reader["MeasureTime"]);
                    MaliciousObject.AlarmTime = Convert.ToInt32(reader["AlarmTime"]);
                }



                connection.Close();
                ViewBag.MaliciousObject = MaliciousObject;

                return View();
            }
            else
            {
                return RedirectToAction("PermissionError");
            }
 
        }


        public IActionResult ViewMalicious()
        {
            Malicious MaliciousObject = new();

            MySqlConnection connection = new(ConStr);

            connection.Open();

            string query = "SELECT * FROM Malicious";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MaliciousObject.MeasureTime = Convert.ToInt32(reader["MeasureTime"]);
                MaliciousObject.AlarmTime = Convert.ToInt32(reader["AlarmTime"]);
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

                MySqlConnection connection = new(ConStr);


                connection.Open();

                string query = "SELECT * FROM Commands";

                MySqlCommand command = new(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CommandsObject.Red = (string)reader["Red"];
                    CommandsObject.Yellow = (string)reader["Yellow"];
                    CommandsObject.Green = (string)reader["Green"];
                    CommandsObject.Buzzer = (string)reader["Buzzer"];
                    CommandsObject.Test = (string)reader["Test"];
                }

                reader.Close();

                query = "SELECT * FROM CommandsTime";

                command = new(query, connection);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CommandsTimeObject.Red = (int)reader["Red"];
                    CommandsTimeObject.Yellow = (int)reader["Yellow"];
                    CommandsTimeObject.Green = (int)reader["Green"];
                    CommandsTimeObject.Buzzer = (int)reader["Buzzer"];
                    CommandsTimeObject.Test = (int)reader["Test"];
                }
                reader.Close();

                connection.Close();


                ViewBag.CommandsObject = CommandsObject;
                ViewBag.CommandsTimeObject = CommandsTimeObject;
                return View();
            }
            else
            {
                return RedirectToAction("PermissionError");
            }




            
        }

        [HttpPost]
        public IActionResult AlterCommands(IFormCollection form)
        {
            if (AuthentificationObject.ModifyOrdinary == true)
            {
                if (form["Command"] == "ON")
                {
                    if (form["Apps"] == "Alarm")
                    {
                        TempData["Message"] = "Alarma este doar pentru Test";
                        return RedirectToAction("Errors");
                    }

                    if (form["Time"] == "")
                    {
                        TempData["Message"] = "Trebuie specificat un timp daca ai ales Pornit";
                        return RedirectToAction("Errors");
                    }

                    MySqlConnection connection = new(ConStr);
                    connection.Open();

                    if (form["Apps"] == "Red")
                    {
                        string query = "UPDATE Commands SET Red = 'ON'";

                        MySqlCommand command = new(query, connection);
                        command.ExecuteNonQuery();

                        query = "UPDATE CommandsTime SET Red = ";
                        query += form["Time"];

                        command = new(query, connection);
                        command.ExecuteNonQuery();
                    }
                    else if (form["Apps"] == "Yellow")
                    {
                        string query = "UPDATE Commands SET Yellow = 'ON'";

                        MySqlCommand command = new(query, connection);
                        command.ExecuteNonQuery();

                        query = "UPDATE CommandsTime SET Yellow = ";
                        query += form["Time"];
                        command = new(query, connection);
                        command.ExecuteNonQuery();
                    }
                    else if (form["Apps"] == "Green")
                    {
                        string query = "UPDATE Commands SET Green = 'ON'";

                        MySqlCommand command = new(query, connection);
                        command.ExecuteNonQuery();

                        query = "UPDATE CommandsTime SET Green = ";
                        query += form["Time"];
                        command = new(query, connection);
                        command.ExecuteNonQuery();
                    }
                    else if (form["Apps"] == "Buzzer")
                    {
                        string query = "UPDATE Commands SET Buzzer = 'ON'";

                        MySqlCommand command = new(query, connection);
                        command.ExecuteNonQuery();

                        query = "UPDATE CommandsTime SET Buzzer = ";
                        query += form["Time"];
                        command = new(query, connection);
                        command.ExecuteNonQuery();

                    }

                    Commands CommandsObject = new();

                    string query2 = "SELECT * FROM Commands";

                    MySqlCommand command2 = new(query2, connection);

                    MySqlDataReader reader = command2.ExecuteReader();

                    while (reader.Read())
                    {
                        CommandsObject.Red = (string)reader["Red"];
                        CommandsObject.Yellow = (string)reader["Yellow"];
                        CommandsObject.Green = (string)reader["Green"];
                        CommandsObject.Buzzer = (string)reader["Buzzer"];
                        CommandsObject.Test = (string)reader["Test"];
                    }

                    reader.Close();

                    query2 = "SELECT * FROM CommandsTime";

                    command2 = new(query2, connection);

                    reader = command2.ExecuteReader();

                    CommandsTime CommandsTimeObject = new();

                    while (reader.Read())
                    {
                        CommandsTimeObject.Red = (int)reader["Red"];
                        CommandsTimeObject.Yellow = (int)reader["Yellow"];
                        CommandsTimeObject.Green = (int)reader["Green"];
                        CommandsTimeObject.Buzzer = (int)reader["Buzzer"];
                        CommandsTimeObject.Test = (int)reader["Test"];
                    }
                    reader.Close();


                    connection.Close();
                    ViewBag.CommandsObject = CommandsObject;
                    ViewBag.CommandsTimeObject = CommandsTimeObject;

                    return View();

                }
                else if (form["Command"] == "Test")
                {
                    if (form["Apps"] != "Alarm")
                    {
                        TempData["Message"] = "Pentru Test trebuie sa fie ales Alarm";
                        return RedirectToAction("Errors");
                    }

                    if (form["Time"] == "")
                    {
                        TempData["Message"] = "Trebuie specificat un timp daca ai ales Test";
                        return RedirectToAction("Errors");
                    }

                    MySqlConnection connection = new(ConStr);

                    connection.Open();

                    string query = "UPDATE Commands SET Test = 'ON'";

                    MySqlCommand command = new(query, connection);

                    command.ExecuteNonQuery();

                    query = "UPDATE CommandsTime SET Test = ";
                    query += form["Time"];
                    command = new(query, connection);
                    command.ExecuteNonQuery();


                    Commands CommandsObject = new();

                    query = "SELECT * FROM Commands";

                    command = new(query, connection);

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        CommandsObject.Red = (string)reader["Red"];
                        CommandsObject.Yellow = (string)reader["Yellow"];
                        CommandsObject.Green = (string)reader["Green"];
                        CommandsObject.Buzzer = (string)reader["Buzzer"];
                        CommandsObject.Test = (string)reader["Test"];
                    }

                    reader.Close();

                    query = "SELECT * FROM CommandsTime";

                    command = new(query, connection);

                    reader = command.ExecuteReader();

                    CommandsTime CommandsTimeObject = new();

                    while (reader.Read())
                    {
                        CommandsTimeObject.Red = (int)reader["Red"];
                        CommandsTimeObject.Yellow = (int)reader["Yellow"];
                        CommandsTimeObject.Green = (int)reader["Green"];
                        CommandsTimeObject.Buzzer = (int)reader["Buzzer"];
                        CommandsTimeObject.Test = (int)reader["Test"];
                    }
                    reader.Close();


                    connection.Close();

                    ViewBag.CommandsObject = CommandsObject;
                    ViewBag.CommandsTimeObject = CommandsTimeObject;
                    return View();

                }
                else
                {
                    Commands CommandsObject = new();
                    CommandsTime CommandsTimeObject = new();

                    MySqlConnection connection = new(ConStr);


                    connection.Open();

                    string query = "SELECT * FROM Commands";

                    MySqlCommand command = new(query, connection);

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        CommandsObject.Red = (string)reader["Red"];
                        CommandsObject.Yellow = (string)reader["Yellow"];
                        CommandsObject.Green = (string)reader["Green"];
                        CommandsObject.Buzzer = (string)reader["Buzzer"];
                        CommandsObject.Test = (string)reader["Test"];
                    }

                    reader.Close();

                    query = "SELECT * FROM CommandsTime";

                    command = new(query, connection);

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        CommandsTimeObject.Red = (int)reader["Red"];
                        CommandsTimeObject.Yellow = (int)reader["Yellow"];
                        CommandsTimeObject.Green = (int)reader["Green"];
                        CommandsTimeObject.Buzzer = (int)reader["Buzzer"];
                        CommandsTimeObject.Test = (int)reader["Test"];
                    }
                    reader.Close();

                    connection.Close();


                    ViewBag.CommandsObject = CommandsObject;
                    ViewBag.CommandsTimeObject = CommandsTimeObject;
                    return View();
                }



                
            }
            else
            {
                return RedirectToAction("PermissionError");
            }
            
        }


        public IActionResult ViewStatistics()
        {
            EnvData EnvDataObject = new();

            MySqlConnection connection = new MySqlConnection(ConStr);




            //----------------------------------------------------- MQ2_1----------------------------------------------
            connection.Open();
            string query = "SELECT * FROM MQ2_1 ORDER BY TimeStamp DESC LIMIT 100";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            List<MQ2_1> MQ2_1_List = new();


            while (reader.Read())
            {
                MQ2_1 MQ2_1_Object = new();
                MQ2_1_Object.H2 = (double)reader["H2"];
                MQ2_1_Object.LPG = (double)reader["LPG"];
                MQ2_1_Object.Methane = (double)reader["Methane"];
                MQ2_1_Object.CO = (double)reader["CO"];
                MQ2_1_Object.Alcohol = (double)reader["Alcohol"];
                MQ2_1_Object.Smoke = (double)reader["Smoke"];
                MQ2_1_Object.Propane = (double)reader["Propane"];
                MQ2_1_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                MQ2_1_List.Add(MQ2_1_Object);
            }

            reader.Close();

            if (MQ2_1_List.Count != 100)
            {
                TempData["Message"] = "Nu sunt suficiente date";
                return RedirectToAction("Errors");
            }







            //----------------------------------------------------- MQ9_1----------------------------------------------

            query = "SELECT * FROM MQ9_1 ORDER BY TimeStamp DESC LIMIT 100";

            command = new(query, connection);

            reader = command.ExecuteReader();
            List<MQ9_1> MQ9_1_List = new();

            while (reader.Read())
            {
                MQ9_1 MQ9_1_Object = new();
                MQ9_1_Object.LPG = (double)reader["LPG"];
                MQ9_1_Object.CO = (double)reader["CO"];
                MQ9_1_Object.Methane = (double)reader["Methane"];
                MQ9_1_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                MQ9_1_List.Add(MQ9_1_Object);
            }
            reader.Close();

            if (MQ9_1_List.Count != 100)
            {
                TempData["Message"] = "Nu sunt suficiente date";
                return RedirectToAction("Errors");
            }


            //----------------------------------------------------- MQ135_1----------------------------------------------


            query = "SELECT * FROM MQ135_1 ORDER BY TimeStamp DESC LIMIT 100";

            command = new(query, connection);

            reader = command.ExecuteReader();


            List<MQ135_1> MQ135_1_List = new();
            while (reader.Read())
            {
                MQ135_1 MQ135_1_Object = new();
                MQ135_1_Object.CO2 = (double)reader["CO2"];
                MQ135_1_Object.CO = (double)reader["CO"];
                MQ135_1_Object.Alcohol = (double)reader["Alcohol"];
                MQ135_1_Object.NH4 = (double)reader["NH4"];
                MQ135_1_Object.Toluene = (double)reader["Toluene"];
                MQ135_1_Object.Acetone = (double)reader["Acetone"];
                MQ135_1_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                MQ135_1_List.Add(MQ135_1_Object);
            }
            reader.Close();
            if (MQ135_1_List.Count != 100)
            {
                TempData["Message"] = "Nu sunt suficiente date";
                return RedirectToAction("Errors");
            }

            //----------------------------------------------------- DHT_1----------------------------------------------





            query = "SELECT * FROM DHT_1 ORDER BY TimeStamp DESC LIMIT 100";

            command = new(query, connection);

            reader = command.ExecuteReader();


            List<DHT_1> DHT_1_List = new();
            while (reader.Read())
            {
                DHT_1 DHT_1_Object = new();
                DHT_1_Object.Temperature = (double)reader["Temperature"];
                DHT_1_Object.Humidity = (double)reader["Humidity"];
                DHT_1_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                DHT_1_List.Add(DHT_1_Object);
            }

            reader.Close();

            if (DHT_1_List.Count != 100)
            {
                TempData["Message"] = "Nu sunt suficiente date";
                return RedirectToAction("Errors");
            }


            //----------------------------------------------------- MQ2_2----------------------------------------------




            query = "SELECT * FROM MQ2_2 ORDER BY TimeStamp DESC LIMIT 100";

            command = new(query, connection);

            reader = command.ExecuteReader();


            List<MQ2_2> MQ2_2_List = new();
            while (reader.Read())
            {
                MQ2_2 MQ2_2_Object = new();
                MQ2_2_Object.H2 = (double)reader["H2"];
                MQ2_2_Object.LPG = (double)reader["LPG"];
                MQ2_2_Object.Methane = (double)reader["Methane"];
                MQ2_2_Object.CO = (double)reader["CO"];
                MQ2_2_Object.Alcohol = (double)reader["Alcohol"];
                MQ2_2_Object.Smoke = (double)reader["Smoke"];
                MQ2_2_Object.Propane = (double)reader["Propane"];
                MQ2_2_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                MQ2_2_List.Add(MQ2_2_Object);
            }
            reader.Close();
            if (MQ2_2_List.Count != 100)
            {
                TempData["Message"] = "Nu sunt suficiente date";
                return RedirectToAction("Errors");
            }


            //----------------------------------------------------- MQ9_2----------------------------------------------



            query = "SELECT * FROM MQ9_2 ORDER BY TimeStamp DESC LIMIT 100";

            command = new(query, connection);

            reader = command.ExecuteReader();


            List<MQ9_2> MQ9_2_List = new();
            while (reader.Read())
            {
                MQ9_2 MQ9_2_Object = new();
                MQ9_2_Object.LPG = (double)reader["LPG"];
                MQ9_2_Object.CO = (double)reader["CO"];
                MQ9_2_Object.Methane = (double)reader["Methane"];
                MQ9_2_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                MQ9_2_List.Add(MQ9_2_Object);
            }
            reader.Close();
            if (MQ9_2_List.Count != 100)
            {
                TempData["Message"] = "Nu sunt suficiente date";
                return RedirectToAction("Errors");
            }

            //----------------------------------------------------- MQ135_2----------------------------------------------


            query = "SELECT * FROM MQ135_2 ORDER BY TimeStamp DESC LIMIT 100";

            command = new(query, connection);

            reader = command.ExecuteReader();


            List<MQ135_2> MQ135_2_List = new();
            while (reader.Read())
            {
                MQ135_2 MQ135_2_Object = new();
                MQ135_2_Object.CO2 = (double)reader["CO2"];
                MQ135_2_Object.CO = (double)reader["CO"];
                MQ135_2_Object.Alcohol = (double)reader["Alcohol"];
                MQ135_2_Object.NH4 = (double)reader["NH4"];
                MQ135_2_Object.Toluene = (double)reader["Toluene"];
                MQ135_2_Object.Acetone = (double)reader["Acetone"];
                MQ135_2_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                MQ135_2_List.Add(MQ135_2_Object);
            }
            reader.Close();
            if (MQ135_2_List.Count != 100)
            {
                TempData["Message"] = "Nu sunt suficiente date";
                return RedirectToAction("Errors");
            }


            //----------------------------------------------------- DHT_2----------------------------------------------




            query = "SELECT * FROM DHT_2 ORDER BY TimeStamp DESC LIMIT 100";

            command = new(query, connection);

            reader = command.ExecuteReader();


            List<DHT_2> DHT_2_List = new();
            while (reader.Read())
            {
                DHT_2 DHT_2_Object = new();
                DHT_2_Object.Temperature = (double)reader["Temperature"];
                DHT_2_Object.Humidity = (double)reader["Humidity"];
                DHT_2_Object.TimeStamp = (DateTime)reader["TimeStamp"];
                DHT_2_List.Add(DHT_2_Object);
            }

            reader.Close();
            if (DHT_2_List.Count != 100)
            {
                TempData["Message"] = "Nu sunt suficiente date";
                return RedirectToAction("Errors");
            }


            List<AllModel> AllModelList = new();
            AllModel AllModelAvg = new();
            AllModelAvg.H2 = 0;
            AllModelAvg.LPG = 0;
            AllModelAvg.Methane = 0;
            AllModelAvg.CO = 0;
            AllModelAvg.Alcohol = 0;
            AllModelAvg.Smoke = 0;
            AllModelAvg.Propane = 0;
            AllModelAvg.CO2 = 0;
            AllModelAvg.NH4 = 0;
            AllModelAvg.Toluene = 0;
            AllModelAvg.Acetone = 0;
            AllModelAvg.Temperature = 0;
            AllModelAvg.Humidity = 0;


            
            for (int i = 0; i < 100; i++)
            {
                AllModel AllModelObject = new();
                AllModelObject.H2 = (MQ2_1_List[i].H2 + MQ2_2_List[i].H2) / 2;
                AllModelAvg.H2 += AllModelObject.H2;

                AllModelObject.LPG = (MQ2_1_List[i].LPG + MQ2_2_List[i].LPG + MQ9_1_List[i].LPG + MQ9_2_List[i].LPG) / 4;
                AllModelAvg.LPG += AllModelObject.LPG;

                AllModelObject.Methane = (MQ2_1_List[i].Methane + MQ2_2_List[i].Methane + MQ9_1_List[i].Methane + MQ9_2_List[i].Methane) / 4;
                AllModelAvg.Methane += AllModelObject.Methane;

                AllModelObject.CO = (MQ2_1_List[i].CO + MQ2_2_List[i].CO + MQ9_1_List[i].CO + MQ9_2_List[i].CO + MQ135_1_List[i].CO + MQ135_2_List[i].CO) / 6;
                AllModelAvg.CO += AllModelObject.CO;

                AllModelObject.Alcohol = (MQ2_1_List[i].Alcohol + MQ2_2_List[i].Alcohol + MQ135_1_List[i].Alcohol + MQ135_2_List[i].Alcohol) / 4;
                AllModelAvg.Alcohol += AllModelObject.Alcohol;

                AllModelObject.Smoke = (MQ2_1_List[i].Smoke + MQ2_2_List[i].Smoke) / 2;
                AllModelAvg.Smoke += AllModelObject.Smoke;

                AllModelObject.Propane = (MQ2_1_List[i].Propane + MQ2_2_List[i].Propane) / 2;
                AllModelAvg.Propane += AllModelObject.Propane;

                AllModelObject.CO2 = (MQ135_1_List[i].CO2 + MQ135_2_List[i].CO2) / 2;
                AllModelAvg.CO2 += AllModelObject.CO2;

                AllModelObject.NH4 = (MQ135_1_List[i].NH4 + MQ135_2_List[i].NH4) / 2;
                AllModelAvg.NH4 += AllModelObject.NH4;

                AllModelObject.Toluene = (MQ135_1_List[i].Toluene + MQ135_2_List[i].Toluene) / 2;
                AllModelAvg.Toluene += AllModelObject.Toluene;

                AllModelObject.Acetone = (MQ135_1_List[i].Acetone + MQ135_2_List[i].Acetone) / 2;
                AllModelAvg.Acetone += AllModelObject.Acetone;

                AllModelObject.Temperature = (DHT_1_List[i].Temperature + DHT_2_List[i].Temperature) / 2;
                AllModelAvg.Temperature += AllModelObject.Temperature;

                AllModelObject.Humidity = (DHT_1_List[i].Humidity + DHT_2_List[i].Humidity) / 2;
                AllModelAvg.Humidity += AllModelObject.Humidity;

                AllModelList.Add(AllModelObject);

            }
            AllModelAvg.H2 /= 100;
            AllModelAvg.LPG /= 100;
            AllModelAvg.Methane /= 100;
            AllModelAvg.CO /= 100;
            AllModelAvg.Alcohol /= 100;
            AllModelAvg.Smoke /= 100;
            AllModelAvg.Propane /= 100;
            AllModelAvg.CO2 /= 100;
            AllModelAvg.NH4 /= 100;
            AllModelAvg.Toluene /= 100;
            AllModelAvg.Acetone /= 100;
            AllModelAvg.Temperature /= 100;
            AllModelAvg.Humidity /= 100;


            List<DataStats> H2 = new();
            List<DataStats> LPG = new();
            List<DataStats> Methane = new();
            List<DataStats> CO = new();
            List<DataStats> Alcohol = new();
            List<DataStats> Smoke = new();
            List<DataStats> Propane = new();
            List<DataStats> CO2 = new();
            List<DataStats> NH4 = new();
            List<DataStats> Toluene = new();
            List<DataStats> Acetone = new();
            List<DataStats> Temperature = new();
            List<DataStats> Humidity = new();

            for (int i= 0;i < AllModelList.Count;i++)
            {
                H2.Add(new DataStats(i, AllModelList[i].H2));
                LPG.Add(new DataStats(i, AllModelList[i].LPG));
                Methane.Add(new DataStats(i, AllModelList[i].Methane));
                CO.Add(new DataStats(i, AllModelList[i].CO));
                Alcohol.Add(new DataStats(i, AllModelList[i].Alcohol));
                Smoke.Add(new DataStats(i, AllModelList[i].Smoke));
                Propane.Add(new DataStats(i, AllModelList[i].Propane));
                CO2.Add(new DataStats(i, AllModelList[i].CO2));
                NH4.Add(new DataStats(i, AllModelList[i].NH4));
                Toluene.Add(new DataStats(i, AllModelList[i].Toluene));
                Acetone.Add(new DataStats(i, AllModelList[i].Acetone));
                Temperature.Add(new DataStats(i, AllModelList[i].Temperature));
                Humidity.Add(new DataStats(i, AllModelList[i].Humidity));
            }

            ViewBag.H2 = JsonConvert.SerializeObject(H2);
            ViewBag.LPG = JsonConvert.SerializeObject(LPG);
            ViewBag.Methane = JsonConvert.SerializeObject(Methane);
            ViewBag.CO = JsonConvert.SerializeObject(CO);
            ViewBag.Alcohol = JsonConvert.SerializeObject(Alcohol);
            ViewBag.Smoke = JsonConvert.SerializeObject(Smoke);
            ViewBag.Propane = JsonConvert.SerializeObject(Propane);
            ViewBag.CO2 = JsonConvert.SerializeObject(CO2);
            ViewBag.NH4 = JsonConvert.SerializeObject(NH4);
            ViewBag.Toluene = JsonConvert.SerializeObject(Toluene);
            ViewBag.Acetone = JsonConvert.SerializeObject(Acetone);
            ViewBag.Temperature = JsonConvert.SerializeObject(Temperature);
            ViewBag.Humidity = JsonConvert.SerializeObject(Humidity);


            ViewBag.AllModelAvg = AllModelAvg;


            return View();
        }



        public IActionResult PermissionError()
        {
            return View();
        }

        public IActionResult Errors()
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
