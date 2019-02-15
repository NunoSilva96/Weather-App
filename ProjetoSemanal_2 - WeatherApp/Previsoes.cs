using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSemanal_2___WeatherApp
{
    class Previsoes
    {
        public class Datum
        {
            public double precipitaProb { get; set; }
            public double tMin { get; set; }
            public double tMax { get; set; }
            public string predWindDir { get; set; }
            public int idWeatherType { get; set; }
            public int classWindSpeed { get; set; }
            public string longitude { get; set; }
            public int globalIdLocal { get; set; }
            public string latitude { get; set; }
            public int? classPrecInt { get; set; }
        }

        public class RootObject
        {
            public string owner { get; set; }
            public string country { get; set; }
            public string forecastDate { get; set; }

            public List<Datum> data { get; set; }
            public DateTime dataUpdate { get; set; }
        }
    }
}
