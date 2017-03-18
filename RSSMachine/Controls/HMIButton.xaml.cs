using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Media.Animation;

namespace RSSMachine
{
    /// <summary>
    /// Interaction logic for HMILabel.xaml
    /// </summary>
    public partial class HMIButton : HMIBase 
    {
        public HMIButton()
        {
            InitializeComponent();
            //"#FFA2A2A2"
            //((LinearGradientBrush)recMouse.Fill).GradientStops[1].Color = Color.FromArgb(100, 255, 0, 0);
            //((LinearGradientBrush)recMouse.Fill).GradientStops[1].Color = Color.FromArgb(100, 255, 0, 0);
        }

        public string Text
        {
            get { return txtCaption.Text; }
            set { txtCaption.Text = value; }
        }

        /// <summary>
        /// Цвет кнопки.
        /// </summary>
        public Color Color
        {
            get { return ((LinearGradientBrush)recMouse.Fill).GradientStops[1].Color; }
            set { ((LinearGradientBrush)recMouse.Fill).GradientStops[1].Color = value; }
        }


        /// <summary>
        /// Размер шрифта.
        /// </summary>
        public double CaptionFontSize
        {
            get { return txtCaption.FontSize; }
            set { txtCaption.FontSize = value; }
        }

        /// <summary>
        /// Радиус скругления.
        /// </summary>
        public double RectangleRadius
        {
            get { return recMouse.RadiusX; }
            set { recMouse.RadiusX = recMouse.RadiusY = value; }
        }
    }
}
