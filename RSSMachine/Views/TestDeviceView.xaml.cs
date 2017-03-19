﻿using System;
using System.Windows;
using System.Windows.Forms;

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

        private async void btnBeep_Click(object sender, RoutedEventArgs e)
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
    }
}
