using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAnimatedGif;

namespace Monitor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

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
            if (GridWidth.Width==600)
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
            Personto_to_walk();
        }
    }
}
