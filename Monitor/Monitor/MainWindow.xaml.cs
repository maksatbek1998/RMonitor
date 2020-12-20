using Monitor.Models;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WpfAnimatedGif;
using System.Collections.ObjectModel;

namespace Monitor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel.MainViewModel vm;
        DataBase.BaseData dataBase;
        ListBox tar = new ListBox();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        string number, opera, langu;
        static int mediavol = 0;
        static int ss = 0;
        Thread myThread;
        public MainWindow()
        {
            InitializeComponent();

            #region Timer
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            #endregion
            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            buttonClickMain_Click(sender, e);
            UpdateQ();
            if (mediavol == 1) 
            {
                ss++;
                if (ss == 12)
                {
                    mediaReclam.Volume = 0.5;
                    mediavol = 0;
                    ss = 0;                                                   
                }
            }
        }

        private void buttonClickMain_Click(object sender, EventArgs e)
        {
            vm = new ViewModel.MainViewModel();
            vm.timeDelation(ref mediaReclam);
        }

        #region Анимация

        public void Personto_to_walk()
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("Image/GIF/Person.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(imageAwesome, image);
            ImageBehavior.SetRepeatBehavior(imageAwesome, new System.Windows.Media.Animation.RepeatBehavior(15));
        }

        #endregion


        public void UpdateQ()
        {
            if (List.Items.Count > 0)
            {
                List.Items.Clear();
            }
            else if (List.Items.Count == 0)
            {
                NumberTxt.Text = "";
                OperTxt.Text = "";
            }
            dataBase = new DataBase.BaseData();
            dataBase.del += db =>
            {
                if (db.Rows.Count > 0)
                {
                    for (int i = 0; i < db.Rows.Count; i++)
                    {
                        List.Items.Add
                         (
                             new Turns
                             {
                                 number = db.Rows[i][0].ToString(),
                                 oper = db.Rows[i][1].ToString()
                             });
                    }
                  OperTxt.Text= opera = db.Rows[0][1].ToString();
                  langu = db.Rows[0][2].ToString();
                  NumberTxt.Text = number = db.Rows[0][0].ToString();
                }
            };
            dataBase.SoursData("SELECT t.number,t.operator_window,t.locale from current_turns AS t ORDER BY t.id DESC");
        }
        private void NumberTxt_TextChanged(object sender, TextChangedEventArgs e)
        {            
            if (List.Items.Count > 0)
            {
                Message numberWindow = new Message(ref mediaReclam, NumberTxt.Text, OperTxt.Text);
                numberWindow.Show();
                mediaReclam.Volume = 0.1;
                mediavol = 1;
                Personto_to_walk();
                myThread = new Thread(new ThreadStart(asyncMuz));
                myThread.Start();
            }           
        }

        #region AsyncMuzic

         private void asyncMuz()
         {
           Naudio.MusicPlay(number, opera, langu);
         }
        
        #endregion

        private void mediaReclam_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaReclam.Stop();
            mediaReclam.Play();
        }     
       
    }
}
