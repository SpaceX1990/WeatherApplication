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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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

                // Assuming the API has a "temperature" field
                _viewModel.WeatherContent = post?.product ?? "No data available";
            }
            else {
                _viewModel.WeatherContent = "Failed to fetch weather data.";
            }
        }

        private void UpdateWeather_Click(object sender, RoutedEventArgs e) {
            ReadAndDeserializeAPIResponse();
        }
    }

    public class WeatherViewModel : INotifyPropertyChanged {
        private string? _weatherContent;

        public string? WeatherContent {
            get => _weatherContent;
            set {
                _weatherContent = value;
                OnPropertyChanged(nameof(WeatherContent));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}