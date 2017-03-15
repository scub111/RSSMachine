﻿using System;
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
    /// Interaction logic for AgreementView.xaml
    /// </summary>
    public partial class AgreementView : ViewBase
    {
        public AgreementView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Собыитие на нажатие кнопки "Продолжить".
        /// </summary>
        public event EventHandler ContinueButtonClicked = delegate { };

        private async void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ContinueButtonClicked(this, EventArgs.Empty);
        }
    }
}
