using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Synthesis;



namespace SpeakOut
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

        private void Grid_Initialized(object sender, EventArgs e)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            string date = today.ToString();
            DateLab.Content = date;
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                // Create the greeting text
                string Name = NameBox.Text;
                string Greeting = $"Hello {Name} I hope you are having a good day. ";

                // Create a prompt builder and append the greeting text to it
                PromptBuilder promptBuilder = new PromptBuilder();
                promptBuilder.AppendText(Greeting);

                //Speak the greeting
                synth.Speak(promptBuilder);
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}