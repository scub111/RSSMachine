using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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

            rssController = new RSSController();
        }

        /// <summary>
        /// RSS-контроллер.
        /// </summary>
        RSSController rssController;

        /// <summary>
        /// Реальный порт RSS-контроллера.
        /// </summary>
        string realPortName;

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
        /// Вид окна ожидания.
        /// </summary>
        WaitView waitView;

        /// <summary>
        /// Вид выбора товара.
        /// </summary>
        SelectProductView selectProductView;

        /// <summary>
        /// Вид выбора устройства.
        /// </summary>
        SetControllerView setControllerView;

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

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Title += $" {Assembly.GetExecutingAssembly().GetName().Version.ToString()}";

            SetControllerViewCall();
            //StartViewCall();

            InfoWindow info = new InfoWindow(typeof(TestDeviceView));
            info.Title = "RSS-контроллер";
            info.Initializing += (s, a) =>
            {
                ((TestDeviceView)s).PostConstructor(rssController);
            };
            info.Show();
            realPortName = await FindPortName();

            if (!string.IsNullOrEmpty(realPortName))
                setControllerView.SetRealRSSCaption(realPortName);
            else
                setControllerView.SetRealRSSCaption("Не найдено устройство");

            setControllerView.HideUpdateRealRSS();
        }

        private Task<string> FindPortName()
        {
            Task<string> task = new Task<string>(() => 
                {
                    //return "";
                    return RSSController.FindPortName();
                });
            task.Start();
            return task;
        }

        #region Call views
        private void StartViewCall()
        {
            startView = ActivateView<StartView>(startView,
                (s, a) =>
                {
                    ((StartView)s).PostConstructor(rssController);
                    ((StartView)s).PressButtonClick += StartView_PressButtonClick;
                }
            );
        }

        private void AgreementViewCall()
        {
            agreementView = ActivateView<AgreementView>(agreementView,
                (s, a) =>
                {
                    ((AgreementView)s).PostConstructor(rssController);
                    ((AgreementView)s).ContinueButtonClick += AgreementView_ContinueButtonClick;
                }
            );
        }

        private void TestDeviceViewCall()
        {
            testDeviceView = ActivateView<TestDeviceView>(testDeviceView,
                (s, a) =>
                {
                    ((TestDeviceView)s).PostConstructor(rssController);
                }
            );
        }

        private void WaitViewCall()
        {
            waitView = ActivateView<WaitView>(waitView,
                (s, a) =>
                {
                    ((WaitView)s).PostConstructor(rssController);
                    ((WaitView)s).SetText("Ожидайте подтверждения от кассира...");
                }
            );
        }
        private void SelectProductViewCall()
        {
            selectProductView = ActivateView<SelectProductView>(selectProductView,
                (s, a) =>
                {
                    ((SelectProductView)s).PostConstructor(rssController);
                }
            );
        }        
        private void SetControllerViewCall()
        {
            setControllerView = ActivateView<SetControllerView>(setControllerView,
                (s, a) =>
                {
                    ((SetControllerView)s).PostConstructor(rssController);
                    ((SetControllerView)s).RealRSSClick += MainWindow_RealRSSClick;
                    ((SetControllerView)s).SimRSSClick += MainWindow_SimRSSClick;
                }
            );
        }
        #endregion
        
        private void MainWindow_RealRSSClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(realPortName))
            {
                rssController.PostContructor(realPortName);
                rssController.Start();
                StartViewCall();
            }
        }

        private void MainWindow_SimRSSClick(object sender, EventArgs e)
        {
            rssController.PostContructor(simulation: true);
            rssController.Start();
            StartViewCall();
        }

        private void StartView_PressButtonClick(object sender, EventArgs e)
        {
            AgreementViewCall();
        }

        /// <summary>
        /// Ожидание подтверждения от кассира.
        /// </summary>
        private async void WaitAnswer()
        {

        }

        private async void AgreementView_ContinueButtonClick(object sender, EventArgs e)
        {
            WaitViewCall();

            //Task taskWait = new Task(WaitAnswer);
            //taskWait.Start();

            try
            {
                await rssController.Beep();
                await rssController.WaitControlStatusChanged();
            }
            catch (Exception ex)
            {
                StartViewCall();
            }

            if (rssController.ControlStatus.btnDeny)
            {
                StartViewCall();
                await rssController.Beep(1);
            }
            else
            {
                if (rssController.ControlStatus.btnAllow)
                {
                    SelectProductViewCall();
                    await rssController.Beep(1);
                }
            }
        }

        private void MainWindow1_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
