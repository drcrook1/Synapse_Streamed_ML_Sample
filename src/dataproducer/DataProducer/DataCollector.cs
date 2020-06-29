using System;
using System.Collections.Generic;
using System.Text;

namespace DataProducer
{
    public class DataCollector
    {
        public WeatherData CurrentWeather {get;set;}
        public WeatherTextData CurrentViews {get;set;}
        public String CollectorId {get;set;}
        public String TenantId {get;set;}

        public DataCollector(String tenantId, String collectorId){
            this.TenantId = tenantId;
            this.CollectorId = collectorId;
            this.CurrentWeather = new WeatherData();
            this.CurrentViews = new WeatherTextData();
            this.CollectWeather();
            this.CollectWeatherViews();
        }

        public void CollectWeather(){
            var rand = new Random();
            this.CurrentWeather.temperature = (float)rand.NextDouble() * 100;
            this.CurrentWeather.humidity = (float)rand.NextDouble() * 100;
            this.CurrentWeather.time = DateTime.UtcNow;
        }

        public void CollectWeatherViews()
        {
            var rand = new Random();
            var handles = new List<String>() {"SurferPro1000", "FisherD", "ZaneyJim", "Jill"};
            var adjectives = new List<String>() {"great", "horrible", "rough", "incredible", "crazy"};
            var nouns = new List<String>() {"rain", "kite", "wind", "boardwalk", "board", "raining"};
            var verbs = new List<String>() {"surfing", "kiting", "crafting", "fishing", "hiking", "watching"};

            this.CurrentViews.time = DateTime.UtcNow;
            this.CurrentViews.userHandle = handles[rand.Next(0,3)];
            this.CurrentViews.message = adjectives[rand.Next(0,4)] + " " + verbs[rand.Next(0,5)] + " " + nouns[rand.Next(0,5)];
        }
    }
}
