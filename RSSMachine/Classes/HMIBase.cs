using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RSSMachine
{
    [DefaultEvent("Click")]
    public abstract class HMIBase : UserControlEx
    {
        public HMIBase()
        {
            _Actual = true;
            Loaded += HMIBase_Loaded;
            MouseEnter += HMIBase_MouseEnter;
            MouseLeave += HMIBase_MouseLeave;
            ActualChanged += HMIBase_ActualChanged;
            MouseLeftButtonDown += HMIBase_MouseLeftButtonDown;
        }

        bool _Actual;
        /// <summary>
        /// Актуальность данных.
        /// </summary>
        public bool Actual
        {
            get { return _Actual; }
            set
            {
                if (_Actual == value) return;
                _Actual = value;
                ActualChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Событие на изменение актуальности.
        /// </summary>
        public event EventHandler ActualChanged = delegate { };

        /// <summary>
        /// Событие на нажатие кнопки.
        /// </summary>
        public event EventHandler Click = delegate { };

        private void HMIBase_Loaded(object sender, RoutedEventArgs e)
        {
            //Actual = true;
        }

        private void HMIBase_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "ControlMouseEnter", true);
        }

        private void HMIBase_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "ControlMouseLeave", true);
        }

        private void HMIBase_ActualChanged(object sender, EventArgs e)
        {
            if (Actual)
                VisualStateManager.GoToState(this, "ControlActualTrue", true);
            else
                VisualStateManager.GoToState(this, "ControlActualFalse", true);
        }

        private void HMIBase_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Click(this, EventArgs.Empty);
        }
    }
}
