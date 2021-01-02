using Monitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WpfAnimatedGif;
using System.Windows.Documents;
using System.Windows.Media;

namespace Monitor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBase.BaseData dataBase;
        List<string> videolist;
        static int media = 0, mediatime = 0,time =0,text = 0;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        string number, opera, langu;
        Thread myThread;
        static int ads_time = 0;

        public MainWindow()
        {
            InitializeComponent();

            timeDelation();
            try
            {
                dataBase = new DataBase.BaseData();
                dataBase.del += db =>
                {
                    if (db.Rows.Count > 0)
                    {
                        MainText.Text = db.Rows[0][0].ToString();
                        marquee.Text = db.Rows[0][1].ToString();
                        ads_time = int.Parse(db.Rows[0][2].ToString());
                        time = marquee.Text.Length;
                    }
                };
                dataBase.SoursData("select name_b,(SELECT tvtablo_text FROM tvtablos_ticker),(SELECT rskbank.options.value FROM rskbank.options WHERE rskbank.options.`key` = 'Ads_time') from branches");

            }
            catch
            {

            }
            #region Timer
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            #endregion

            MediaStart();

            Personto_to_walk();

            this.MaximizeToSecondaryMonitor();
        }

        public void MaximizeToSecondaryMonitor()
        {
            var secondaryScreen = Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();

            if (secondaryScreen != null)
            {
                var workingArea = secondaryScreen.WorkingArea;
                this.Left = workingArea.Left;
                this.Top = workingArea.Top;
                this.Width = workingArea.Width;
                this.Height = workingArea.Height;

                if (this.IsLoaded)
                {
                    this.WindowState = WindowState.Maximized;
                }
            }
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            text++;
            mediatime++;
            UpdateQ();
            if (mediatime == ads_time && GridWidth.Width==600)
            {
                Animation_For_Video();
                mediatime = 0;
            }
            if (text == marquee.Text.Length * 9) 
            {
                dataBase = new DataBase.BaseData();
                text = 0;
                marquee.Text = dataBase.DisplayReturnOne("SELECT tvtablo_text FROM tvtablos_ticker");
                LeftToRightMarqueeOnTextBox();
            }
        }

        public void MediaStart()
        {
            if (videolist.Count > 0)
            {
                mediaReclam.Source = new Uri(videolist[media].ToString(), UriKind.RelativeOrAbsolute);
                mediaReclam.Play();
            }
            else
            {

            }
        }

        public void timeDelation()
        {
            try
            {
                videolist = new List<string>();
                dataBase = new DataBase.BaseData();
                dataBase.del += bd =>
                {
                    if (bd.Rows.Count > 0)
                    {
                        for (int i = 0; i < bd.Rows.Count; i++)
                        {
                            videolist.Add(bd.Rows[i][2].ToString());
                        }
                    }

                };
                dataBase.SoursData("SELECT a.start_date,a.end_date,d.video_url FROM ads_schedules AS a INNER JOIN ads AS d ON a.ads_id = d.id");
            }
            catch
            {

            }

        }

        private void buttonClickMain_Click(object sender, EventArgs e)
        {
            Animation_For_Video();
        }

        #region Анимация

        public void Personto_to_walk()
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("Image/GIF/Person.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(imageAwesome, image);
            ImageBehavior.SetRepeatBehavior(imageAwesome, new System.Windows.Media.Animation.RepeatBehavior());
        }

        #endregion

        public void UpdateQ()
        {
            try
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
                                     number = db.Rows[i][1].ToString(),
                                     oper = db.Rows[i][2].ToString()
                                 });
                        }

                        OperTxt.Text = opera = db.Rows[0][2].ToString();
                        langu = db.Rows[0][3].ToString();
                        NumberTxt.Text = number = db.Rows[0][1].ToString();
                        IDText.Text = db.Rows[0][0].ToString();
                    }
                };
                dataBase.SoursData("SELECT t.id,t.turn_nomer,t.window_nomer,t.lang from tvtablos_current_turns AS t ORDER BY t.id DESC limit 10");
            }
            catch
            {

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LeftToRightMarqueeOnTextBox();
        }

        private void LeftToRightMarqueeOnTextBox()
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = this.ActualWidth;
            doubleAnimation.To = -marquee.ActualWidth;
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(time/3+1)); // provide an appropriate  duration 
            marquee.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
        }
        private void NumberTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (List.Items.Count > 0)
            {
                if (imageAwesome.Visibility == Visibility.Hidden)
                { imageAwesome.Visibility = Visibility.Visible; }

                Message numberWindow = new Message(NumberTxt.Text, OperTxt.Text);
                numberWindow.Owner = this;
                numberWindow.Show();
                if (GridWidth.Width != 600)
                {
                    Animation_For_Video();
                    mediatime = 0;
                }
                else
                {
                    mediatime = 0;
                }
                myThread = new Thread(new ThreadStart(asyncMuz));
                myThread.Start();
            }
            else
            {
                if (imageAwesome.Visibility == Visibility.Visible)
                {
                    imageAwesome.Visibility = Visibility.Hidden;
                }

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
            if (media < videolist.Count - 1)
            {
                media++;
                mediaReclam.Stop();
                mediaReclam.Source = new Uri(videolist[media].ToString(), UriKind.RelativeOrAbsolute);
                mediaReclam.Play();
            }
            else
            {
                media = 0;
                mediaReclam.Stop();
                timeDelation();
                MediaStart();
            }
        }

        public void Animation_For_Video()
        {
            if (GridWidth.Width == 600)
            {
                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = GridWidth.Width;
                myDoubleAnimation.To = 0;
                myDoubleAnimation.Duration = TimeSpan.FromMilliseconds(700);
                GridWidth.BeginAnimation(Grid.WidthProperty, myDoubleAnimation);
                DoubleAnimation myDoubleAnimation1 = new DoubleAnimation();
                myDoubleAnimation1.From = Title.Height;
                myDoubleAnimation1.To = 0;
                myDoubleAnimation1.Duration = TimeSpan.FromMilliseconds(650);
                Title.BeginAnimation(Grid.HeightProperty, myDoubleAnimation1);
            }
            else
            {
                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = 0;
                myDoubleAnimation.To = 600;
                myDoubleAnimation.Duration = TimeSpan.FromMilliseconds(1);
                GridWidth.BeginAnimation(Grid.WidthProperty, myDoubleAnimation);
                DoubleAnimation myDoubleAnimation1 = new DoubleAnimation();
                myDoubleAnimation1.From = 0;
                myDoubleAnimation1.To = 162;
                myDoubleAnimation1.Duration = TimeSpan.FromMilliseconds(1);
                Title.BeginAnimation(Grid.HeightProperty, myDoubleAnimation1);
            }

        }

    }
}
