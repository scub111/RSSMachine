using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

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
            normalColor = btnAllow.Color;
        }

        Color normalColor;

        Timer timer;

        private void ViewBase_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Visible)
            {
                lblLoopCount.Content = $"Удачи/неудачи: {rssController.LoopSuccessCounter} / {rssController.LoopFaultCounter}";
                lblCycleSpan.Content = $"Время цикла: {rssController.CycleSpan.TotalMilliseconds:0} ms";
                lblQueueCount.Content = $"Кол-во задач: {rssController.QueueCount}";

                btnAllow.Color = rssController.ControlStatus.btnAllow ? Color.FromRgb(0x33, 0xFF, 0x00) : normalColor;
                btnDeny.Color = rssController.ControlStatus.btnDeny ? Color.FromRgb(0xFF, 0x00, 0x66) : normalColor;
            }
        }

        private void btnGetStatus_Click(object sender, RoutedEventArgs e)
        {
            rssController.GetControlStatus();
        }

        private void btnReconnect_Click(object sender, RoutedEventArgs e)
        {
            /*
            Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR", "Start", 4, Microsoft.Win32.RegistryValueKind.DWord);
            await Task.Delay(3000);
            Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR", "Start", 3, Microsoft.Win32.RegistryValueKind.DWord);
            */

            rssController.ReloadLoop();
        }

        private async void btnBeep_Click(object sender, EventArgs e)
        {
            bool result;
            try
            {
                result = await rssController.Beep(3);
            }
            catch
            {

            }
        }

        private void btnAllow_Click(object sender, EventArgs e)
        {
            if (rssController.ControlStatusSim != null)
                rssController.ControlStatusSim.btnAllow = true;
        }

        private void btnAllow_ClickUp(object sender, EventArgs e)
        {
            if (rssController.ControlStatusSim != null)
                rssController.ControlStatusSim.btnAllow = false;
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            if (rssController.ControlStatusSim != null)
                rssController.ControlStatusSim.btnDeny = true;
        }

        private void btnDeny_ClickUp(object sender, EventArgs e)
        {
            if (rssController.ControlStatusSim != null)
                rssController.ControlStatusSim.btnDeny = false;
        }
    }
}
