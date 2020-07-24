using LandmarkAi.Model;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace LandmarkAi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            
            dialog.Filter = "Image files (*.png; *.jpg)|*.png;*.jpg;*jpeg|All files (*.*)|*.*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (dialog.ShowDialog()==true) 
                imgShowImage.Source = new BitmapImage(new Uri(dialog.FileName));

            // MakePredictionAsync(dialog.FileName);
            MakePredictionMockUp(dialog.FileName);
        }

        private void MakePredictionMockUp(string fileName)
        {
            var predictions = new List<Prediction>();
            predictions.Add(new Prediction("01", "Something 1", 80.5));
            predictions.Add(new Prediction("02", "Something 2", 90.5)); 
            predictions.Add(new Prediction("03", "Something 3", 50.7));

            var customVision = new CustomVision("01", "LandmarkAi", "5", DateTime.Now, predictions);
            lstPredictions.ItemsSource = predictions;

        }
        /*
        private async void MakePredictionAsync(string fileName)
        {
            string url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v1.1/Prediction/bf39d301-3888-43cf-91fe-1509ce5ac26a/image?iterationId=2cc8d120-36d9-417c-b3c3-213b910a3f20";
            string prediction_key = "fd63926c323344a0aacaa249ebd73fc6";
            string content_type = "application/octet-stream";
            var file = File.ReadAllBytes(fileName);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Prediction-Key", prediction_key);

                using (var content = new ByteArrayContent(file))
                {
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(content_type);
                    var response = await client.PostAsync(url, content);

                    var responseString = await response.Content.ReadAsStringAsync();

                    List<Prediction> predictions = (JsonConvert.DeserializeObject<CustomVision>(responseString)).Predictions;
                    lstPredictions.ItemsSource = predictions;
                }
            }
        }          
        */
    }
}
