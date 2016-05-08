﻿using GeoLib.Services;
using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;

            this.Title = "UI running on thread " + Thread.CurrentThread.ManagedThreadId;
        }

        ServiceHost _serviceHost = new ServiceHost(typeof(GeoManager));

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            _serviceHost.Open();
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            _serviceHost.Close();
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }
    }
}
