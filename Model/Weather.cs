using System.Text.Json.Serialization;

namespace WeatherApplication.Model {
    internal class Weather {
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Dataseries {
        [JsonPropertyName("timepoint")]
        public int timepoint { get; set; }

        [JsonPropertyName("cloudcover")]
        public int cloudcover { get; set; }

        [JsonPropertyName("lifted_index")]
        public int lifted_index { get; set; }

        [JsonPropertyName("prec_type")]
        public string prec_type { get; set; }

        [JsonPropertyName("prec_amount")]
        public int prec_amount { get; set; }

        [JsonPropertyName("temp2m")]
        public int temp2m { get; set; }

        [JsonPropertyName("rh2m")]
        public string rh2m { get; set; }

        [JsonPropertyName("wind10m")]
        public Wind10m wind10m { get; set; }

        [JsonPropertyName("weather")]
        public string weather { get; set; }
    }

    public class Root {
        [JsonPropertyName("product")]
        public string product { get; set; }

        [JsonPropertyName("init")]
        public string init { get; set; }

        [JsonPropertyName("dataseries")]
        public List<Dataseries> dataseries { get; set; }
    }

    public class Wind10m {
        [JsonPropertyName("direction")]
        public string direction { get; set; }

        [JsonPropertyName("speed")]
        public int speed { get; set; }
    }


}
