using Monitor.Models;
using System;
using System.Windows;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace Monitor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>  
    public partial class MainWindow : Window
    {
        #region переменные

        SerialPort port1 = new SerialPort("COM10", 9600, Parity.None, 8, StopBits.One);
        DataBase.BaseData dataBase;
        List<ImageListVar> videolist;
        List<Turns> gridList = new List<Turns>();
        Stack<SoundTurn> soundTurns = new Stack<SoundTurn>();
        static int media = 0, mediatime = 0,time = 0, text = 0, imagetime = 0, imageduration = 0;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public static bool soundBool = true;
        static int ads_time = 0;


        #endregion

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
                dataBase.SoursData("select name_b,(SELECT tvtablo_text FROM tvtablos_ticker),(SELECT rskbank.options.value FROM rskbank.options WHERE rskbank.options.`key` = 'Ads_time') from branches limit 1");
            }
            catch
            {
                //System.Windows.MessageBox.Show("mainwindow");
            }
            #region Timer
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            #endregion

            Personto_to_walk();

            this.MaximizeToSecondaryMonitor();
        }

        #region Переход на другое окно

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LeftToRightMarqueeOnTextBox();
        }

        #endregion

        #region Timer

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                text++;
                mediatime++;
                UpdateQ();
                if (soundTurns.Count==0 && gridList.Count>0) 
                {
                    NumberTxt.Text = gridList[0].number;
                    OperTxt.Text = gridList[0].oper;
                }
                if (imagetime > 0)
                {
                    imagetime++;
                    if (imagetime == imageduration * 60)
                    {
                        media++;
                        imagetime = 0; 
                        MediaStart();
                    }
                }
                if (mediatime == ads_time && GridWidth.Width == 600)
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
                if (soundTurns.Count > 0 && soundBool)
                {
                    NumberTxt_TextChanged();
                }
                else
                {
                    soundTurns = new Stack<SoundTurn>();
                }
            }
            catch
            {
                //System.Windows.MessageBox.Show("timer");
            }
        }

        #endregion

        #region Video

        public void MediaStart()
        {
            try
            {
                if (videolist.Count > 0)
                {
                    if (media < videolist.Count)
                    {
                        if (videolist.Count > 0 && videolist[media].type == "video")
                        {
                            mediaReclam.Visibility = Visibility.Visible;
                            ReclamImage.Visibility = Visibility.Hidden;
                            mediaReclam.Source = new Uri(videolist[media].uri.ToString());
                            mediaReclam.Play();
                        }
                        else/* if (videolist.Count > 0 && videolist[media].type == "image")*/
                        {
                            mediaReclam.Visibility = Visibility.Hidden;
                            ReclamImage.Visibility = Visibility.Visible;
                            ReclamImage.Source = new BitmapImage(new Uri(videolist[media].uri));
                            imageduration = int.Parse(videolist[media].duration.ToString());
                            imagetime = 1;
                        }
                    }
                    else
                    {
                        timeDelation();
                    }
                }
                else
                {
                    mediaReclam.Visibility = Visibility.Hidden;
                    ReclamImage.Visibility = Visibility.Visible;
                    DataBase.BaseData data = new DataBase.BaseData();
                    ReclamImage.Source = new BitmapImage(new Uri(data.DisplayReturnOne("SELECT o.value FROM rskbank.options AS o WHERE o.`key` = 'Tv_Default_Image'")));
                }
            }
            catch
            {
                //System.Windows.MessageBox.Show("mediastart");
            }

        }
        public void timeDelation()
        {
            try
            {
                videolist = new List<ImageListVar>();
                dataBase = new DataBase.BaseData();
                dataBase.del += bd =>
                {
                    if (bd.Rows.Count > 0)
                    {
                        for (int i = 0; i < bd.Rows.Count; i++)
                        {
                            videolist.Add(new ImageListVar { uri = bd.Rows[i][1].ToString(), type = bd.Rows[i][0].ToString(), duration = bd.Rows[i][2].ToString() });
                        }
                    }
                };
                dataBase.SoursData("SELECT t.`type`,t.file_path,a.duration FROM ads_schedules AS a INNER JOIN ads AS t ON a.ads_id = t.id");
                media = 0;
                MediaStart();
            }
            catch
            {
                //System.Windows.MessageBox.Show("timedelation");
            }

        }

        private void mediaReclam_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (media < videolist.Count - 1)
            {
                mediaReclam.Stop();
                media++;
                MediaStart();
            }
            else
            {
                mediaReclam.Stop();
                timeDelation();
            }
        }

        #endregion

        #region Анимация

        private void buttonClickMain_Click(object sender, EventArgs e)
        {
            Animation_For_Video();
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

        public void Personto_to_walk()
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("Image/GIF/Person.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(imageAwesome, image);
            ImageBehavior.SetRepeatBehavior(imageAwesome, new System.Windows.Media.Animation.RepeatBehavior());
        }

        private void LeftToRightMarqueeOnTextBox()
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = this.ActualWidth;
            doubleAnimation.To = -marquee.ActualWidth;
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(time / 4 + 1)); // provide an appropriate  duration 
            marquee.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
        }

        #endregion

        #region Обновление

        public void UpdateQ()
        {
            try
            {
                if (gridList.Count < 0 )
                {
                    NumberTxt.Text = "";
                    OperTxt.Text = "";
                }
                dataBase = new DataBase.BaseData();
                dataBase.del += db =>
                {
                    if (db.Rows.Count > 0)
                    {
                        gridList = new List<Turns>();
                        for (int i = 0; i < db.Rows.Count; i++)
                        {
                            if (db.Rows[i][1].ToString() == "----" && db.Rows[i][4].ToString() == "0")
                            {
                                COMWriteAsync("----", db.Rows[i][2].ToString());
                                DataBase.BaseData data = new DataBase.BaseData();
                                data.Registr("UPDATE tvtablos_current_turns AS t SET t.is_say ='1' WHERE t.turn_nomer = '----' AND t.window_nomer ='" + db.Rows[i][2].ToString() + "'");
                            }
                            if (db.Rows[i][1].ToString() != "----")
                            {
                                gridList.Add
                                 (
                                     new Turns
                                     {                                        
                                         number = db.Rows[i][1].ToString(),
                                         oper = db.Rows[i][2].ToString()
                                     });
                                System.Windows.MessageBox.Show(i.ToString());
                            }
                            if (db.Rows[i][4].ToString() == "0" && db.Rows[i][1].ToString() != "----")
                            {
                                soundTurns.Push(new SoundTurn
                                {
                                    soundnumber = db.Rows[i][1].ToString(),
                                    sountoper = db.Rows[i][2].ToString(),
                                    soundlang = db.Rows[i][3].ToString()
                                });
                            }
                        }
                        List.ItemsSource = gridList;

                    }
                    else 
                    {
                        gridList = new List<Turns>();
                        List.ItemsSource = gridList;
                        NumberTxt.Text = "";
                        OperTxt.Text = "";
                    }
                };
                dataBase.SoursData("SELECT t.id,t.turn_nomer,t.window_nomer,t.lang,t.is_say from tvtablos_current_turns AS t ORDER BY t.id desc limit 10");
                //}
            }
            catch 
            {
                //System.Windows.MessageBox.Show("updateq");
            }
        }

        #endregion

        #region Sound

        private void NumberTxt_TextChanged()
        {
            if (soundBool)
            {
                SoundLi(soundTurns.Pop());
                soundBool = false;
            }
        }

        private void SoundLi(SoundTurn sound)
        {
            try
            {
                if (List.Items.Count > 0)
                {

                    if (imageAwesome.Visibility == Visibility.Hidden)
                    {
                        imageAwesome.Visibility = Visibility.Visible;
                    }
                    if (sound.soundlang == "RU" || sound.soundlang == "KG" || sound.soundlang == "EN")
                    {
                        Message numberWindow = new Message(sound.soundnumber, sound.sountoper);
                        numberWindow.Owner = this;
                        numberWindow.Show();
                    }
                    else
                    {
                        Message numberWindow = new Message(sound.soundnumber, sound.sountoper, 4);
                        numberWindow.Owner = this;
                        numberWindow.Show();
                    }
                    NumberTxt.Text = sound.soundnumber;
                    OperTxt.Text = sound.sountoper;

                    if (GridWidth.Width != 600)
                    {
                        Animation_For_Video();
                        mediatime = 0;
                    }
                    else
                    {
                        mediatime = 0;
                    }
                    AsyncMuz(sound.soundnumber, sound.sountoper, sound.soundlang);
                    COMWriteAsync(sound.soundnumber, sound.sountoper);
                }

                else
                {
                    if (imageAwesome.Visibility == Visibility.Visible)
                    {
                        imageAwesome.Visibility = Visibility.Hidden;
                    }

                }
            }
            catch
            {
              //  System.Windows.MessageBox.Show("soundli");
            }
        }

        #endregion

        #region AsyncMetods

        public async void AsyncMuz(string n, string o, string l)
        {
            await Task.Run(() => asyncMuz(n, o, l));
        }

        private void asyncMuz(string n, string o, string l)
        {
            Naudio.MusicPlay(n, o, l);
        }

        private void AsyncWrite(string n, string o)
        {
            try
            {
                port1.Open();
                string textw = o + " " + ArduinoConverter(n);
                port1.WriteLine(textw);
                port1.Close();
            }
            catch
            {
               // System.Windows.MessageBox.Show("AsyncWrite");
            }
        }

        private static string ArduinoConverter(string str)
        {
            string rus = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string eng = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefg";
            string ready = "";
            for (int y = 0; y < rus.Length; y++)
                if (str[0] == rus[y])
                {
                    ready = ready + eng[y].ToString();
                }
            return ready + str.Remove(0, 1);
        }

        private async void COMWriteAsync(string n, string o)
        {
            Thread.Sleep(100);
            await Task.Run(() => AsyncWrite(n, o));
        }
        #endregion

    }
}
