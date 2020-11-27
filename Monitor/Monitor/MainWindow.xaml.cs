using Monitor.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        DataBase.BaseData dataBase;

        DispatcherTimer dispatcherTimer = new DispatcherTimer();
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

        }

        private void buttonClickMain_Click(object sender, EventArgs e)
        {
            ViewModel.MainViewModel vm = new ViewModel.MainViewModel();
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
            ImageBehavior.SetRepeatBehavior(imageAwesome, new System.Windows.Media.Animation.RepeatBehavior(20));
        }

        public void Animation_For_Video()
        {
            if (GridWidth.Width == 600)
            {
                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = GridWidth.Width;
                myDoubleAnimation.To = 0;
                myDoubleAnimation.Duration = TimeSpan.FromMilliseconds(500);
                GridWidth.BeginAnimation(Grid.WidthProperty, myDoubleAnimation);
            }
            else
            {
                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = 0;
                myDoubleAnimation.To = 600;
                myDoubleAnimation.Duration = TimeSpan.FromMilliseconds(500);
                GridWidth.BeginAnimation(Grid.WidthProperty, myDoubleAnimation);
            }

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation_For_Video();
        }
        #endregion

        #region Колекция Очереди

        #endregion

        public void UpdateQ()
        {
            if (List.Items.Count > 0)
            {
                List.Items.Clear();
            }
           else if(List.Items.Count == 0)
            {
                NumberTxt.Text ="";
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
                            }) ;
                    }
                    OperTxt.Text = db.Rows[0][2].ToString();
                    NumberTxt.Text = db.Rows[0][1].ToString();
                                       
                }
            };
            dataBase.SoursData("SELECT * from turns ORDER BY number desc");
        }
        private void NumberTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(List.Items.Count > 0)
            {
                Message numberWindow = new Message( NumberTxt.Text,OperTxt.Text) ;
                numberWindow.Show();
                Personto_to_walk();
              
            }

        }           
    }
}
