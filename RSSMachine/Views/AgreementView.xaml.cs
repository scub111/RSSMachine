using System;

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

        private void btnContinue_Click(object sender, EventArgs e)
        {
            ContinueButtonClicked(this, EventArgs.Empty);
        }
    }
}
