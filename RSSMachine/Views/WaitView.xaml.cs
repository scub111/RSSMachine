namespace RSSMachine
{
    /// <summary>
    /// Interaction logic for WaitView.xaml
    /// </summary>
    public partial class WaitView : ViewBase
    {
        public WaitView()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            txtCaption.Text = text;
        }
    }
}
