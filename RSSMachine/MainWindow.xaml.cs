using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            rssController = new RSSController("COM13");
        }

        /// <summary>
        /// RSS-контроллер.
        /// </summary>
        RSSController rssController;

        /// <summary>
        /// Стартовый вид.
        /// </summary>
        StartView startView;

        /// <summary>
        /// Вид соглашения.
        /// </summary>
        AgreementView agreementView;

        /// <summary>
        /// Вид тестирования устройста.
        /// </summary>
        TestDeviceView testDeviceView;

        /// <summary>
        /// Последний активный вид.
        /// </summary>
        ViewBase viewLastVisible;

        /// <summary>
        /// Активизации определенного вида.
        /// </summary>
        T ActivateView<T>(ViewBase view, EventHandler initCallback) where T : ViewBase, new()
        {
            if (viewLastVisible != null)
                viewLastVisible.Visibility = Visibility.Hidden;

            if (view == null)
            {
                view = new T();

                if (initCallback != null)
                    initCallback(view, EventArgs.Empty);
            }

            if (LayoutRoot.Children.Contains(view))
                view.Visibility = Visibility.Visible;
            else
                LayoutRoot.Children.Add(view);

            viewLastVisible = view;
            return (T)view;
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Title += $" {Assembly.GetExecutingAssembly().GetName().Version.ToString()}";

            startView = ActivateView<StartView>(startView,
                (s, a) =>
                {
                    ((StartView)s).PressButtonClicked += StartView_PressButtonClicked;
                }
            );
        }

        private void StartView_PressButtonClicked(object sender, EventArgs e)
        {
            agreementView = ActivateView<AgreementView>(agreementView,
                (s, a) =>
                {
                    ((AgreementView)s).ContinueButtonClicked += AgreementView_ContinueButtonClicked;
                }
            );
        }

        private void AgreementView_ContinueButtonClicked(object sender, EventArgs e)
        {
            //startView = ActivateView<StartView>(startView, null);
            testDeviceView = ActivateView<TestDeviceView>(testDeviceView, 
                (s, a) =>
                {
                    ((TestDeviceView)s).SetRSSController(rssController);
                }
            );
        }
    }
}
