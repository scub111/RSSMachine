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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RSSMachine
{
    /// <summary>
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : ViewBase
    {
        public StartView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Собыитие на нажатие центрально кнопки.
        /// </summary>
        public event EventHandler PressButtonClicked = delegate {};

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string puth = Environment.CurrentDirectory + "\\3Dpin.gif";
            GIF.Source = new Uri(puth);
            GIF.Play();
            btnStart.Visibility = Visibility.Hidden;
            btnStop.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Продолжение вопросроизведения GIF-анимации.
        /// </summary>
        void GIFPlay()
        {
            if (Visibility == Visibility.Visible)
            {
                GIF.Position = new TimeSpan(0, 0, 0, 1);
                GIF.Play();
            }
        }

        private void GIF_MediaEnded(object sender, RoutedEventArgs e)
        {
            GIFPlay();
        }

        private void StartView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Hidden)
                GIF.Stop();
            GIFPlay();
        }

        private void GIF_MediaOpened(object sender, RoutedEventArgs e)
        {
            updGIF.Visibility = Visibility.Collapsed;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            updGIF.Start();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            updGIF.Stop();
        }

        private void HMIButton_Click(object sender, EventArgs e)
        {
            PressButtonClicked(this, EventArgs.Empty);
        }
    }
}
