using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataProducer
{
    class Program
    {
        static void Main(string[] args)
        {
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
                }
            }
        }
    }
}
