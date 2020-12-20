using Monitor.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Monitor
{
    /// <summary>
    /// Логика взаимодействия для Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        MediaElement elemnet;
        public Message(ref MediaElement obj, string klient, string okno)
        {
            InitializeComponent();
            KLIENT.Text = klient;
            OKNO.Text = okno;
            elemnet = obj;
            elemnet.Volume = 0.1;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += Time;
            timer.Start();

        }
        public void Time(object sender, EventArgs e)
        {
            elemnet.Volume = 0.5;
            this.Close();
        }
    }
}