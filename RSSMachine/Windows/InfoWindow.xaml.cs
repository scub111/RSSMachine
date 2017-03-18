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
using System.Windows.Shapes;

namespace RSSMachine
{
    /// <summary>
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow(Type typeComponent)
        {
            InitializeComponent();

            this.typeComponent = typeComponent;
            Loaded += InfoWindow_Loaded;
        }

        Type typeComponent;

        public InfoWindow(UserControlEx component)
        {
            InitializeComponent();

            LayoutRoot.Children.Add(component);
        }

        private void InfoWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UIElement componet = Activator.CreateInstance(typeComponent) as UIElement;

            Initializing(componet, EventArgs.Empty);

            if (componet != null)
                LayoutRoot.Children.Add(componet);
        }

        /// <summary>
        /// Событие перед инициализацией объекта.
        /// </summary>
        public event EventHandler Initializing = delegate { };
    }
}
