using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataProducer
{
    class Program
    {
        private static string DWConnStr = Environment.GetEnvironmentVariable("SQLDWCONN");

        static void Main(string[] args)
        {

            InsertWeather();
            InsertWeatherView();

            /*
            var sqlDWConnection = new SqlConnection(DWConnStr);
            sqlDWConnection.Open();

            var dataCollectors = new List<DataCollector>();
            for(int i = 0; i < 100; i++)
            {
                dataCollectors.Add(new DataCollector($"Collector {i}", $"Tenant {i}"));
            }
            while(true){
            foreach(DataCollector collector in dataCollectors){
                collector.CollectWeather();
                collector.CurrentWeather.temperature;

                collector.CollectWeatherViews();
                    
                var collectorJson = JsonConvert.SerializeObject(collector, Formatting.Indented);
                Console.WriteLine(collectorJson);

                var cmd = new SqlCommand("insert weather into weather", sqlDWConnection);
                cmd.ExecuteNonQuery();

                var cmdtwo = new SqlCommand("insert weatherview into weatherview", sqlDWConnection);
                cmdtwo.ExecuteNonQuery();
            }
            }
            sqlDWConnection.Close();
            */
        }

        private static void InsertEmployee()
        {
            string connstr = Environment.GetEnvironmentVariable("SQLDWCONN");
            SqlConnection sqlConnection = new SqlConnection(connstr);
            string query = "INSERT INTO dbo.SampleTable " +
                            "(firstname, lastname,gender,location,subscription_type) " +
                            "VALUES (@firstname,  @lastname, @gender, @location, @subtype) ";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.Add("@firstname", SqlDbType.VarChar, 100).Value = "Name6";
            cmd.Parameters.Add("@lastname", SqlDbType.VarChar, 100).Value = "Name6";
            cmd.Parameters.Add("@gender", SqlDbType.VarChar, 100).Value = "Male";
            cmd.Parameters.Add("@location", SqlDbType.VarChar, 100).Value = "NY";
            cmd.Parameters.Add("@subtype", SqlDbType.VarChar, 100).Value = "Paid";
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private static void InsertWeather()
        {
            SqlConnection sqlConnection = new SqlConnection(DWConnStr);

            var dataCollectors = new List<DataCollector>();
            for (int i = 0; i < 100; i++)
            {
                dataCollectors.Add(new DataCollector($"Collector {i}", $"Tenant {i}"));
            }

            foreach (DataCollector collector in dataCollectors)
            {
                collector.CollectWeather();
                


                string query = "INSERT INTO dbo.Weather " +
                            "(ReportTime, temperature, humidity) " +
                            "VALUES (@time,  @temperature, @humidity) ";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.Add("@time", SqlDbType.DateTime, 100).Value = collector.CurrentWeather.time;
                cmd.Parameters.Add("@temperature", SqlDbType.Float, 100).Value = collector.CurrentWeather.temperature;
                cmd.Parameters.Add("@humidity", SqlDbType.Float, 100).Value = collector.CurrentWeather.humidity;

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        private static void InsertWeatherView()
        {
            SqlConnection sqlConnection = new SqlConnection(DWConnStr);

            var dataCollectors = new List<DataCollector>();
            for (int i = 0; i < 100; i++)
            {
                dataCollectors.Add(new DataCollector($"Collector {i}", $"Tenant {i}"));
            }

            foreach (DataCollector collector in dataCollectors)
            {
                collector.CollectWeather();



                string query = "INSERT INTO dbo.WeatherView " +
                            "(ReportTime, userMessage, userHandle) " +
                            "VALUES (@time,  @userMessage, @userHandle) ";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.Add("@time", SqlDbType.DateTime, 100).Value = collector.CurrentViews.time;
                cmd.Parameters.Add("@userMessage", SqlDbType.VarChar, 100).Value = collector.CurrentViews.message;
                cmd.Parameters.Add("@userHandle", SqlDbType.VarChar, 100).Value = collector.CurrentViews.userHandle;

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
