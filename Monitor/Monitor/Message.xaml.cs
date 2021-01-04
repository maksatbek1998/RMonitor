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
        static int diration = 7;
        public Message(string klient, string okno,int dur =7)
        {
            InitializeComponent();
            KLIENT.Text = klient;
            OKNO.Text = okno;
            diration = dur;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(diration);
            timer.Tick += Time;
            timer.Start();
        }
        public void Time(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DataBase.BaseData data = new DataBase.BaseData();
            data.Registr("UPDATE tvtablos_current_turns AS t SET t.is_say = '1' WHERE t.turn_nomer = '"+KLIENT.Text+"' AND t.window_nomer = '"+OKNO.Text+"'");
            MainWindow.soundBool = true;
        }
    }
}