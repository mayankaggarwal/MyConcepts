using GeoLib.Client.Contracts;
using GeoLib.Contracts;
using GeoLib.Proxies;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
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
        string endpointName;
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "UI Running on Thread " + Thread.CurrentThread.ManagedThreadId 
                + " | Process " + Process.GetCurrentProcess().Id.ToString();
            LoadComboBox();
            endpointName = cbEndpoint.SelectedValue.ToString();
            _proxy = new GeoClient(endpointName);
        }

        private void LoadComboBox()
        {
            ClientSection clientSettings = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
            List<string> endpointNames = new List<string>();
            foreach(ChannelEndpointElement endpoint in clientSettings.Endpoints)
            {
                endpointNames.Add(endpoint.Name);
            }

            cbEndpoint.ItemsSource = endpointNames;
            cbEndpoint.SelectedIndex = 0;

        }

        GeoClient _proxy = null;

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            if(txtZipCode.Text != "")
            {
                //GeoClient proxy = new GeoClient(endpointName);
                ZipCodeData data = _proxy.GetZipInfo(txtZipCode.Text);
                if(data!=null)
                {
                    lblCity.Content = data.City;
                    lblState.Content = data.State;

                }

                //proxy.Close();
            }
        }

        private void btnGetZipCodes_Click(object sender, RoutedEventArgs e)
        {
            if(txtState.Text != "")
            {
                GeoClient proxy = new GeoClient(endpointName);
                IEnumerable<ZipCodeData> zipCodeData = proxy.GetZips(txtState.Text);
                if (zipCodeData != null)
                {
                    lstZips.ItemsSource = zipCodeData;
                }
                proxy.Close();

                //EndpointAddress endpointAddress = new EndpointAddress("net.tcp://localhost:11001/GeoService");
                //System.ServiceModel.Channels.Binding binding = new NetTcpBinding();
                //GeoClient proxy = new GeoClient(binding, endpointAddress);
                //IEnumerable<ZipCodeData> zipCodeData = proxy.GetZips(txtState.Text);
                //if(zipCodeData!=null)
                //{
                //    lstZips.ItemsSource = zipCodeData;
                //}
                //proxy.Close();
            }
        }

        private void btnMakeCall_Click(object sender, RoutedEventArgs e)
        {
            ChannelFactory<IMessageService> factory = new ChannelFactory<IMessageService>("");
            IMessageService proxy = factory.CreateChannel();

            proxy.ShowMessage(txtMessage.Text);
            factory.Close();
        }

        private void cbEndpoint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            endpointName = cbEndpoint.SelectedValue.ToString();
            lstZips.ItemsSource = null;
            lblCity.Content = "";
            lblState.Content = "";
        }
    }
}
