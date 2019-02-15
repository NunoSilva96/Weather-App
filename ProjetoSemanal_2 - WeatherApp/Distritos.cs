using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSemanal_2___WeatherApp
{
    class Distritos
    {
        public class Datum
        {
            public int idRegiao { get; set; }
            public string idAreaAviso { get; set; }
            public int idConcelho { get; set; }
            public int globalIdLocal { get; set; }
            public string latitude { get; set; }
            public int idDistrito { get; set; }
            public string local { get; set; }
            public string longitude { get; set; }
        }

        public class RootObject
        {
            public string owner { get; set; }
            public string country { get; set; }
            public List<Datum> data { get; set; }
        }
    }
}
