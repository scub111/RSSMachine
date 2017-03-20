using System;
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
    /// Interaction logic for SetControllerView.xaml
    /// </summary>
    public partial class SetControllerView : ViewBase
    {
        public SetControllerView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие на выбор реального RSS-контроллера.
        /// </summary>
        public event EventHandler RealRSSClick = delegate { };

        /// <summary>
        /// Событие на выбор симуляционного RSS-контроллера.
        /// </summary>
        public event EventHandler SimRSSClick = delegate { };

        private void btnRealRSS_Click(object sender, EventArgs e)
        {
            RealRSSClick(this, EventArgs.Empty);
        }

        private void btnSimRSS_Click(object sender, EventArgs e)
        {
            SimRSSClick(this, EventArgs.Empty);
        }

        /// <summary>
        /// Скрыть компонент объновления кнопки реального RSS-контроллера.
        /// </summary>
        public void HideUpdateRealRSS()
        {
            updRealRSS.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Задание текста кнопи реального RSS-контроллера.
        /// </summary>
        /// <param name="text">Текст.</param>
        public void SetRealRSSCaption(string text)
        {
            btnRealRSS.Text = text;
        }
    }
}
