using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RSSMachine
{
    /// <summary>
    /// Interaction logic for SelectProductView.xaml
    /// </summary>
    public partial class SelectProductView : ViewBase
    {
        public SelectProductView()
        {
            InitializeComponent();

            hmilProducts = new Collection<HMIProductSmall>();
            hmilProducts.Add(hmiProductSmall1);
            hmilProducts.Add(hmiProductSmall2);
            hmilProducts.Add(hmiProductSmall3);
            hmilProducts.Add(hmiProductSmall4);
            hmilProducts.Add(hmiProductSmall5);
            hmilProducts.Add(hmiProductSmall6);
            hmilProducts.Add(hmiProductSmall7);
            hmilProducts.Add(hmiProductSmall8);
            hmilProducts.Add(hmiProductSmall9);
        }

        /// <summary>
        /// Анализ Excel-файла.
        /// </summary>
        AnalisExcel analisExcel;

        /// <summary>
        /// Коллекция элементов продукции.
        /// </summary>
        Collection<HMIProductSmall> hmilProducts;

        public void SetAnalisExcel(AnalisExcel analisExcel)
        {
            this.analisExcel = analisExcel;
        }

        private void SelectProductView_Loaded(object sender, RoutedEventArgs e)
        {
            //ShowProducts(analisExcel.products.Where(i => i.Price > 100));
            ShowProducts(analisExcel.products);
        }

        private void ShowProducts(IEnumerable<Product> products)
        {
            for (int i = 0; i < hmilProducts.Count; i++)
            {
                if (i <= products.Count() - 1)
                    hmilProducts[i].ShowProduct(products.ElementAt(i));
                else
                    break;
            }
        }

        public void ClearEffect()
        {
        }

        private void btn_sort_mark_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_sort_price_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_sort_form_Click(object sender, RoutedEventArgs e)
        {
        }

        private void right_page_Click(object sender, RoutedEventArgs e)
        {
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Left_page_Click(object sender, RoutedEventArgs e)
        {
        }

        private void do_69_Click(object sender, RoutedEventArgs e)
        {
        }

        private void do_99_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ot_100_Click(object sender, RoutedEventArgs e)
        {
        }

        private void king_size_Click(object sender, RoutedEventArgs e)
        {
        }

        private void kompakt_Click(object sender, RoutedEventArgs e)
        {
        }

        private void king_size_super_Click(object sender, RoutedEventArgs e)
        {
        }

        private void super_slim_Click(object sender, RoutedEventArgs e)
        {
        }

        private void other_Click(object sender, RoutedEventArgs e)
        {
        }

        private void back_form_Click(object sender, RoutedEventArgs e)
        {
        }

        private void back_price_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_back_mark_Click(object sender, RoutedEventArgs e)
        {
        }

        private void other_txt_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void PMI_txt_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void JTI_txt_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void BAT_txt_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        public void All_mark()
        {
        }

    }
}
