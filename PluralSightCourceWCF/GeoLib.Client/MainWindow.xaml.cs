using GeoLib.Contracts;
using GeoLib.Proxies;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace GeoLib.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "UI Running on Thread " + Thread.CurrentThread.ManagedThreadId 
                + " | Process " + Process.GetCurrentProcess().Id.ToString();
        }

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            if(txtZipCode.Text != "")
            {
                GeoClient proxy = new GeoClient("eptcp");
                ZipCodeData data = proxy.GetZipInfo(txtZipCode.Text);
                if(data!=null)
                {
                    lblCity.Content = data.City;
                    lblState.Content = data.State;

                }

                proxy.Close();
            }
        }

        private void btnGetZipCodes_Click(object sender, RoutedEventArgs e)
        {
            if(txtState.Text != "")
            {
                GeoClient proxy = new GeoClient("ephttp");
                IEnumerable<ZipCodeData> zipCodeData = proxy.GetZips(txtState.Text);
                if(zipCodeData!=null)
                {
                    lstZips.ItemsSource = zipCodeData;
                }
                proxy.Close();
            }
        }

        private void btnMakeCall_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
