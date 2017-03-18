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

namespace RSSMachine
{
	public partial class UpdateControl : UserControl
	{
		public UpdateControl()
		{
			// Требуется для инициализации переменных
			InitializeComponent();
            //RepeatBehavior="Forever"
            sb = this.FindResource("StoryboardUnchecked") as Storyboard;
            //sb.Stop(this);
        }

        Storyboard sb;

        /// <summary>
        /// Запуск анимации.
        /// </summary>
        public void Start()
        {
            sb.Begin(this, true);
            //sb.RepeatBehavior = RepeatBehavior.Forever;
        }

        /// <summary>
        /// Останов анимации.
        /// </summary>
        public void Stop()
        {
            //((Storyboard)this.Resources["StoryboardUnchecked"]).Stop();
            sb.Stop(this);
        }

        private void UpdateControl_Loaded(object sender, RoutedEventArgs e)
        {
           // Stop();
            if (DesignerProperties.GetIsInDesignMode(this)) return;
            //VisualStateManager.GoToState(this, "ControlUnchecked", true);
            /*if (StoryboardUnchecked.GetCurrentState() != ClockState.Active)
                StoryboardUnchecked.Begin();
            */
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this)) return;

            if (Visibility == Visibility.Visible)
                Start();
            else
                Stop();
        }
    }
}