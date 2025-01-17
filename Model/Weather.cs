namespace WeatherApplication.Model {
    internal class Weather {
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Dataseries {
        public int timepoint { get; set; }
        public int cloudcover { get; set; }
        public int lifted_index { get; set; }
        public string prec_type { get; set; }
        public int prec_amount { get; set; }
        public int temp2m { get; set; }
        public string rh2m { get; set; }
        public Wind10m wind10m { get; set; }
        public string weather { get; set; }
    }

    public class Root {
        public string product { get; set; }
        public string init { get; set; }
        public List<Dataseries> dataseries { get; set; }
    }

    public class Wind10m {
        public string direction { get; set; }
        public int speed { get; set; }
    }


}
