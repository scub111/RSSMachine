using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WebControl
{
	public partial class UpdateControl : UserControl
	{
		public UpdateControl()
		{
			// Требуется для инициализации переменных
			InitializeComponent();            
		}

        private bool _checked;
        public bool Checked
        {
            get { return _checked;}
            set
            {
                if (_checked == value) return;
                _checked = value;
                if (_checked)
                {
                    /*
                    VisualStateManager.GoToState(this, "ControlChecked", true);
                    if (StoryboardUnchecked.GetCurrentState() != ClockState.Active)
                        StoryboardUnchecked.Begin();
                    */
                }
                else
                {
                    VisualStateManager.GoToState(this, "ControlUnchecked", true);
                    //StoryboardUnchecked.Stop();
                }
            }
        }

        private void UpdateControl_Loaded(object sender, RoutedEventArgs e)
        {
            _checked = false;
            if (DesignerProperties.GetIsInDesignMode(this)) return;
            VisualStateManager.GoToState(this, "ControlUnchecked", true);
            /*if (StoryboardUnchecked.GetCurrentState() != ClockState.Active)
                StoryboardUnchecked.Begin();
            */
        }
	}
}