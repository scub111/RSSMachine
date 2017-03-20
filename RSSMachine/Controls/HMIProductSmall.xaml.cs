using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RSSMachine
{
    /// <summary>
    /// Interaction logic for HMILabel.xaml
    /// </summary>
    public partial class HMIProductSmall : HMIBase 
    {
        public HMIProductSmall()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this)) return;

            
            exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            recMouse.Fill = new ImageBrush(new BitmapImage(new Uri(exePath + @"\image\back_for_smoke.png")));
        }

        /// <summary>
        /// Расположение программы.
        /// </summary>
        string exePath;

        /// <summary>
        /// Показ продукта.
        /// </summary>
        /// <param name="product">Продукт.</param>
        public void ShowProduct(Product product)
        {
            string[] skus = product.SKU.Split(' ');
            txtSKUBig.Text = skus[0];
            txtSKUSmall.Text = product.SKU.Replace(skus[0], "").TrimStart();
            txtPrice.Text = $"Цена: {product.Price} р.";

            try
            {
                //ImageBrush brushProduct = new ImageBrush(new BitmapImage(new Uri(exePath + $@"\image\733.jpg")));
                ImageBrush brushProduct = new ImageBrush(new BitmapImage(new Uri(exePath + $@"\image\{product.ImageNum}.jpg")));
                brushProduct.Stretch = Stretch.Uniform;
                recProduct.Fill = brushProduct;
            }
            catch
            { }
        }
    }
}
