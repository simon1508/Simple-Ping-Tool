using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
using System.Timers;
using System.Data;


namespace PingTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static bool DarkModeisEnabled = true;

        public MainWindow()
        {
            InitializeComponent();


            var eingabe = lblEingabe.Text;

            List<string> adresses = new List<string>();

            
            IsSucessfull(eingabe,adresses);


        }

        private void addAdress(object sender, RoutedEventArgs e)
        {

            

            var eingabe = lblEingabe.Text;

            List<string> adresses = new List<string>();



            foreach (var _eingabe in adresses)
            {
                eingabe = _eingabe; 

                adresses.Add(_eingabe);

                MessageBox.Show(_eingabe.ToString());
            }

            


            if (isUrl(eingabe, lblMeldung))
            {
                SaveinLabel(eingabe);
                IsSucessfull(eingabe, adresses);
            }
            else
            {
                lblMeldung.Content = "Error with the URL";
            }


        }

        private void IsSucessfull(string eingabe, List<string> adresses)
        {
            Ping ping = new Ping();



            try
            {
                


                if (true)
                {
                    var send = ping.Send(eingabe, 1000);
                    PingReply reply = send;

                    lblMeldung.Content = "Sucessfully added";

                    lblAusgabe_Erfolgreich.Content = send.Status;
                    lblAusgabe_Time.Content = send.RoundtripTime;
                    lblAusgabe_Adresse.Content = send.Address;
 
                    
                }

                
            }
            catch (Exception)
            {
                lblAusgabe_Erfolgreich.Content = "Error";
                
            }
            

        }

        public void SaveinLabel(string eingabe)
        {
            
            lblAusgabe_Url.Content = eingabe;
        }


        public static Boolean isUrl(string _eingabe, Label lblMeldung)
        {
            //Regex filter = new Regex(@"[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)");

            string pattern = @"[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)";

            Match match = Regex.Match(_eingabe, pattern);

           

            try
            {
                if (match.Success)
                {
                    //lblMeldung.Content = "No valid URL";
                    return true;
                }
                else
                {
                    return false;
                }

                


            }
            catch (Exception)
            {
                
                //lblMeldung.Content = "There was an error with the URL";

                return false;
                
            }


        }

        private void DarkMode(object sender, RoutedEventArgs e)
        {


                Brush darkBackground = new SolidColorBrush(Color.FromRgb(30,30,36));
                Brush darkTextColour = new SolidColorBrush(Color.FromRgb(248,249,250));

                Brush lightBackground = new SolidColorBrush(Color.FromRgb(233, 236, 239));
                Brush lightTextColour = new SolidColorBrush(Color.FromRgb(36, 36, 35));


            if (DarkModeisEnabled)
                {
                    lblBackground.Background = lightBackground;

                    Header_PingTool.Foreground = lightTextColour;
                    Header_Adress.Foreground = lightTextColour;
                    Header_Adress2.Foreground = lightTextColour;
                    lblUrl.Foreground = lightTextColour;
                    lblUrl.Foreground = lightTextColour;
                    Header_Status.Foreground = lightTextColour;
                    lblTime.Foreground = lightTextColour;


                    lblAusgabe_Url.Foreground = lightTextColour;
                    lblAusgabe_Adresse.Foreground = lightTextColour;
                    lblAusgabe_Time.Foreground = lightTextColour;
                    lblAusgabe_Erfolgreich.Foreground = lightTextColour;
                    lblMeldung.Foreground = lightTextColour;


                    btnDarkMode.Content = "Dark Mode";
                        

                    DarkModeisEnabled = false;
                }

                else
                {
                    lblBackground.Background = darkBackground;
                

                    Header_PingTool.Foreground = darkTextColour;
                    Header_Adress.Foreground = darkTextColour;
                    Header_Adress2.Foreground = darkTextColour;
                    lblUrl.Foreground = darkTextColour;
                    lblUrl.Foreground = darkTextColour;
                    Header_Status.Foreground = darkTextColour;
                    lblTime.Foreground = darkTextColour;

                    
                    lblAusgabe_Url.Foreground = darkTextColour;
                    lblAusgabe_Adresse.Foreground = darkTextColour;
                    lblAusgabe_Time.Foreground = darkTextColour;
                    lblAusgabe_Erfolgreich.Foreground = darkTextColour;
                    lblMeldung.Foreground= darkTextColour;



                    btnDarkMode.Content = "White Mode";

                    DarkModeisEnabled = true;
                }
            

            

            


        }
    }
}
