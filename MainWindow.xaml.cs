using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace PingTool
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

        private void addAdress(object sender, RoutedEventArgs e)
        {
            var eingabe = lblEingabe.Text;


            SaveinLabel(eingabe);
            IsSucessfull(eingabe);
        }

        private void IsSucessfull(string eingabe)
        {
            Ping ping = new Ping();

            

            var send =  ping.Send(eingabe,1000);


            PingReply reply = send;


            try
            {
               
                    lblAusgabe_Erfolgreich.Content = send.Status;
                    lblAusgabe_Time.Content = send.RoundtripTime;
                    lblAusgabe_Adresse.Content = send.Address;
               
            }
            catch (Exception)
            {
                lblAusgabe_Erfolgreich.Content = "Fehler beim Pingen";
                
            }
            

        }

        public void SaveinLabel(string eingabe)
        {
            
            lblAusgabe_Url.Content = eingabe;
        }
    }
}
