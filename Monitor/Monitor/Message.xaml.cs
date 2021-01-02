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

        public Message(string klient, string okno)
        {
            InitializeComponent();
            KLIENT.Text = klient;
            OKNO.Text = okno;
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
            this.Close();
        }
    }
}