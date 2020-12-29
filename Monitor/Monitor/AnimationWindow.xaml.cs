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
using System.Windows.Shapes;

namespace Monitor
{
    /// <summary>
    /// Логика взаимодействия для AnimationWindow.xaml
    /// </summary>
    public partial class AnimationWindow : Window
    {
        public AnimationWindow()
        {
            InitializeComponent();
            AnimatedText();
        }
        private void AnimatedText()
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 1800;
            da.To = -1900;
            da.Duration = TimeSpan.FromSeconds(30);
            da.RepeatBehavior = RepeatBehavior.Forever;
            anim.BeginAnimation(Canvas.LeftProperty, da);
            anim.Text = "Нужно реализовать бегущую строку. Вроде как задача проще не придумаешь, но нарвался на косяк, который не могу разрулить уже два дня, походу все с ним сталкиваются, но адекватного решения в гуге так и не нашел.При запуске строка идет нормально, слегка подергивается, но вполне приемлемо, через десять минут беганий строка начинает дергаться сильнее, через пол часа дергается уже конкретно и давит на глаза. При этом в диспетчере наблюдаю что со временем медленно растет загрузка проца. Увеличил частоту кадров, стало немного лучше, но в принципе та же хрень :(Кто поборол эту проблему, выручайте! Весь проект уже написан, все отлично работает, а из - за этой мелочи никак сдать не могу :(";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desctop = System.Windows.SystemParameters.WorkArea;
            this.Left = 0;
            this.Top = desctop.Bottom - (this.Height);
        }
    }
}
