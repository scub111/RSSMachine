using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }


        Timer timer;

        private void ViewBase_Loaded(object sender, RoutedEventArgs e)
        {
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Visible)
            {
                lblLoopCount.Content = $"{rssController.LoopSuccessCounter} / {rssController.LoopFaultCounter}";
                lblControlStatus.Content = $"{rssController.ControlStatus.btnAllow} {rssController.ControlStatus.btnDeny}";
                lblCycleSpan.Content = $"{rssController.CycleSpan.TotalMilliseconds:0} ms";
                lblQueueCount.Content = $"{rssController.QueueCount}";
            }
        }

        private void btnBeep_Click(object sender, RoutedEventArgs e)
        {
            rssController.Beep(1);
        }

        private void btnGetStatus_Click(object sender, RoutedEventArgs e)
        {
            rssController.GetControlStatus();
        }

        private async void btnReconnect_Click(object sender, RoutedEventArgs e)
        {
            /*
            Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR", "Start", 4, Microsoft.Win32.RegistryValueKind.DWord);
            await Task.Delay(3000);
            Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR", "Start", 3, Microsoft.Win32.RegistryValueKind.DWord);
            */

            rssController.ReloadLoop();
        }
    }
}
