using System.ComponentModel;
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

    public partial class MainWindow : Window {
        private WeatherViewModel _viewModel;

        public MainWindow() {
            InitializeComponent();

            _viewModel = new WeatherViewModel();
            DataContext = _viewModel;
        }

        public async void ReadAndDeserializeAPIResponse() {
            using HttpClient client = new HttpClient {
                BaseAddress = new Uri("http://www.7timer.info")
            };

            var response = await client.GetAsync("/bin/api.pl?lon=113.17&lat=23.09&product=civil&output=json");

            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                var post = JsonSerializer.Deserialize<Weather>(content);

                _viewModel.TemperatureNow = post?.dataseries.First().temp2m;
                _viewModel.WeatherDescriptionNow = post?.dataseries.First().weather;
                _viewModel.TemperatureTomorrow = post?.dataseries[8].temp2m;
                _viewModel.WeatherDescriptionTomorrow = post?.dataseries[8].weather;

            }
            else {
                _viewModel.WeatherDescriptionNow = "Failed to fetch weather data.";
            }
        }

        private void UpdateWeather_Click(object sender, RoutedEventArgs e) {
            ReadAndDeserializeAPIResponse();
        }
    }

    public class WeatherViewModel : INotifyPropertyChanged {
        private string? _weatherDescriptionNow;
        private int ? _temperatureNow;
        private string? _weatherDescriptionTomorrow;
        private int ? _temperatureTomorrow;
       

        public int? TemperatureNow {
            get => _temperatureNow;
            set {
                _temperatureNow = value;
                OnPropertyChanged(nameof(TemperatureNow));
            }
        }

        public string? WeatherDescriptionNow {
            get => _weatherDescriptionNow;
            set {
                _weatherDescriptionNow = value;
                OnPropertyChanged(nameof(WeatherDescriptionNow));
            }
        }  
        
        public int? TemperatureTomorrow {
            get => _temperatureTomorrow;
            set {
                _temperatureTomorrow = value;
                OnPropertyChanged(nameof(TemperatureTomorrow));
            }
        }

        public string? WeatherDescriptionTomorrow {
            get => _weatherDescriptionTomorrow;
            set {
                _weatherDescriptionTomorrow = value;
                OnPropertyChanged(nameof(WeatherDescriptionTomorrow));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}