using GeoLib.Services;
using GeoLib.WindowsHosting.Contracts;
using GeoLib.WindowsHosting.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
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

namespace GeoLib.WindowsHosting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow MainUI { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
            MainUI = this;
            this.Title = "UI running on thread " + Thread.CurrentThread.ManagedThreadId;
            _sync = SynchronizationContext.Current;
        }

        ServiceHost _serviceHost = new ServiceHost(typeof(GeoManager));
        ServiceHost _serviceHostMessage = new ServiceHost(typeof(MessageManager));

        SynchronizationContext _sync;
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            _serviceHost.Open();
            _serviceHostMessage.Open();
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            _serviceHost.Close();
            _serviceHostMessage.Close();
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        internal void ShowMessage(string message)
        {
            string threadId = Thread.CurrentThread.ManagedThreadId.ToString();
            SendOrPostCallback callback = new SendOrPostCallback(arg =>
            {
                lblMessage.Content = message + "Thread ID :" + threadId
                    + "| Process ID: " + Process.GetCurrentProcess().Id.ToString();
            });

            _sync.Send(callback, null);
            
        }

        private void btnInProcCall_Click(object sender, RoutedEventArgs e)
        {
            ChannelFactory<IMessageService> factory = new ChannelFactory<IMessageService>("");
            IMessageService proxy = factory.CreateChannel();
            string threadId = Thread.CurrentThread.ManagedThreadId.ToString();
            string processId = Process.GetCurrentProcess().Id.ToString();
            Thread thread = new Thread(() =>
            {
                string message = Environment.NewLine + "Thread ID :" + threadId
                + " has been marshalled to Thread with ID :"
                + Thread.CurrentThread.ManagedThreadId.ToString()
                + "| Process ID: " + processId
                + " has been marshalled to Process with ID :"
                + Process.GetCurrentProcess().Id.ToString();
                proxy.ShowMessage(message);
            });

            thread.Start();
            
        }
    }
}
