using System;
using System.Diagnostics;
using System.Windows;

namespace csharpRestClient
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

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            RestClient rClient = new RestClient();
            rClient.EndPoint = txtRestURI.Text;
            DebugOutput("Rest Client Created");
            string stringResponse = string.Empty;
            stringResponse = rClient.MakeRequest();
            DebugOutput(stringResponse);
        }
        public void DebugOutput(string stringDebugOutput)
        {
            try
            {
                Debug.Write(stringDebugOutput + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + stringDebugOutput + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.CaretIndex;
                txtResponse.ScrollToEnd();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
    }
}
