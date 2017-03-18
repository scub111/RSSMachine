using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RSSMachine
{
    public abstract class ViewBase : UserControlEx
    {
        public ViewBase()
        {
            this.Loaded += ViewBase_Loaded;
        }

        public RSSController rssController;

        /// <summary>
        /// Пост-конструктор.
        /// </summary>
        /// <param name="controller"></param>
        public void PostConstructor(RSSController controller)
        {
            rssController = controller;
        }

        private void ViewBase_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            string typeName = GetType().Name;
            if (!typeName.Contains("ViewBase"))
                if (rssController == null)
                    MessageBox.Show($"В окне {typeName} не иниализирован объкт RSS-контроллера.",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
