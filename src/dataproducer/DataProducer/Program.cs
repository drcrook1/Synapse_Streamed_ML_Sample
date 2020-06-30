using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataProducer
{
    class Program
    {
        private const string DWConnStr = "";
        static void Main(string[] args)
        {
            //
            // Create SQL Synapse DW Connection
            //
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
                    collector.CollectWeatherViews();
                    
                    var collectorJson = JsonConvert.SerializeObject(collector, Formatting.Indented);
                    Console.WriteLine(collectorJson);

                    var cmd = new SqlCommand("insert weather into weather", sqlDWConnection);
                    cmd.ExecuteNonQuery();

                    var cmdtwo = new SqlCommand("insert weatherview into weatherview", sqlDWConnection);
                    cmdtwo.ExecuteNonQuery();
                }
            }
        }
    }
}
