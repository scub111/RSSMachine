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
    /// Interaction logic for TestDevice.xaml
    /// </summary>
    public partial class TestDeviceView : ViewBase
    {
        public TestDeviceView()
        {
            InitializeComponent();
        }

        RSSController rssController;

        /// <summary>
        /// Установка объекта контроллера.
        /// </summary>
        /// <param name="controller"></param>
        public void SetRSSController(RSSController controller)
        {
            rssController = controller;
        }

        private void btnBeep_Click(object sender, RoutedEventArgs e)
        {
            rssController.Beep();
        }

        private void ViewBase_Loaded(object sender, RoutedEventArgs e)
        {
            if (rssController == null)
                MessageBox.Show("Не иниализирован объкт RSS-контроллера.", 
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
