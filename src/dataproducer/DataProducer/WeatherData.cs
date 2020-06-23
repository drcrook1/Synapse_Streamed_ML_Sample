using System;
using System.Collections.Generic;
using System.Text;

namespace DataProducer
{
    public class WeatherData
    {
        public DateTime time { get; set; }
        public float temperature { get; set; }
        public float humidity { get; set; }
        public float wind { get; set; }
    }
}
