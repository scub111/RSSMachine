using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSMachine
{
    public enum Companies
    {
        NaN,
        BAT
    }

    public enum Segments
    {
        NaN,
        Premium,
        VFM,
        Low
    }

    public enum MRPGroups
    {
        NaN,
        Above100,
        Between76and99,
        Below75
    }   

    public enum FilterFormats
    {
        NaN,
        Default,
        Demi,
        Slim
    }

    public enum Exists
    {
        NaN,
        Yes,
        No
    }

    public class Product
    {
        public Product()
        {
            Company = Companies.NaN;
            Segment = Segments.NaN;
            MRPGroup = MRPGroups.NaN;
            FilterFormat = FilterFormats.NaN;
        }

        /// <summary>
        /// Номер ячейки.
        /// </summary>
        public int CellNum { get; set; }

        /// <summary>
        /// Номер изображения.
        /// </summary>
        public string ImageNum { get; set; }

        /// <summary>
        /// SKU-наименование.
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// Компания.
        /// </summary>
        public Companies Company { get; set; }

        /// <summary>
        /// Сегмент.
        /// </summary>
        public Segments Segment { get; set; }
        
        /// <summary>
        /// Цена.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// MRP группа.
        /// </summary>
        public MRPGroups MRPGroup { get; set; }

        /// <summary>
        /// Формат фильтра.
        /// </summary>
        public FilterFormats FilterFormat { get; set; }

        /// <summary>
        /// Количество смол.
        /// </summary>
        public double Tar { get; set; }

        /// <summary>
        /// Количество сигарет в пачке.
        /// </summary>
        public int SticksPerPack { get; set; }

        /// <summary>
        /// Наименование Нейласана.
        /// </summary>
        public string NielsenName { get; set; }

        /// <summary>
        /// Наличие товара.
        /// </summary>
        public Exists Exist { get; set; }
    }

    /// <summary>
    /// Анализ Excel-файла.
    /// </summary>
    public class AnalisExcel
    {
        public AnalisExcel(string fileName)
        {
            products = new Collection<Product>();

            FileInfo fileInfo = new FileInfo(fileName);
            ExcelPackage excelPackage = new ExcelPackage(fileInfo);
            ExcelWorksheet totalSheet = excelPackage.Workbook.Worksheets[1];

            string company;
            string segment;
            string mrpGroup;
            string filterFormat;
            string exist;

            for (int i = 4; i <= totalSheet.Dimension.Rows; i++)
            {
                try
                {
                    Product product = new Product();
                    product.CellNum = int.Parse(totalSheet.Cells[i, 1].Text);
                    product.ImageNum = totalSheet.Cells[i, 2].Text;
                    product.SKU = totalSheet.Cells[i, 3].Text;

                    //product.Company = (Companies)Enum.Parse(typeof(Companies), totalSheet.Cells[i, 4].Text);
                    company = totalSheet.Cells[i, 4].Text;
                    if (company.Contains("BAT"))
                        product.Company = Companies.BAT;

                    segment = totalSheet.Cells[i, 5].Text;
                    if (segment.Contains("Premium"))
                        product.Segment = Segments.Premium;
                    else if (segment.Contains("VFM"))
                        product.Segment = Segments.VFM;
                    else if (segment.Contains("Low"))
                        product.Segment = Segments.Low;

                    product.Price = double.Parse(totalSheet.Cells[i, 6].Text);

                    mrpGroup = totalSheet.Cells[i, 7].Text;
                    if (mrpGroup.Contains("Больше 100 Р"))
                        product.MRPGroup = MRPGroups.Above100;
                    else if (mrpGroup.Contains("От 76 Р до 99 Р"))
                        product.MRPGroup = MRPGroups.Between76and99;
                    else if (mrpGroup.Contains("До 75 Р"))
                        product.MRPGroup = MRPGroups.Below75;

                    filterFormat = totalSheet.Cells[i, 8].Text;
                    if (filterFormat.Contains("Обычные"))
                        product.FilterFormat = FilterFormats.Default;
                    else if (filterFormat.Contains("Деми"))
                        product.FilterFormat = FilterFormats.Demi;
                    else if (filterFormat.Contains("Тонкие короткие"))
                        product.FilterFormat = FilterFormats.Slim;

                    product.Tar = double.Parse(totalSheet.Cells[i, 9].Text);

                    product.SticksPerPack = int.Parse(totalSheet.Cells[i, 10].Text);

                    product.NielsenName = totalSheet.Cells[i, 11].Text;

                    exist = totalSheet.Cells[i, 12].Text;
                    if (exist.Contains("в наличии"))
                        product.Exist = Exists.Yes;
                    else if (exist.Contains("отсутствует"))
                        product.Exist = Exists.No;

                    products.Add(product);
                }
                catch
                {
                }
            }

        }

        /// <summary>
        /// Коллекция продуктов.
        /// </summary>
        private Collection<Product> products;

    }
}
