using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherApplication.Model;

namespace WeatherApplication {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        public static void ReadAndDeserializeAPIResponse() {
            HttpClient client = new HttpClient() {
                BaseAddress = new Uri("http://www.7timer.info/bin")
            };

        //http://www.7timer.info/bin/api.pl?lon=113.17&lat=23.09&product=civil&output=json

            var response = client.GetAsync("/api.pl?lon=113.17&lat=23.09&product=civil&output=json").Result;

            var content = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine("Content:");
            Console.WriteLine(content);
            Console.WriteLine();

            var post = JsonSerializer.Deserialize<Root>(content);

            Console.WriteLine("Zufälliger nutzloser Fakt:");
            Console.WriteLine(post);
        }

        private void UpdateWeather_Click(object sender, RoutedEventArgs e) {
            ReadAndDeserializeAPIResponse();
        }
    }
}