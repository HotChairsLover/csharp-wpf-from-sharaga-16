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
using System.IO;

namespace Furniture_Store.Elements
{
    /// <summary>
    /// Логика взаимодействия для Category.xaml
    /// </summary>
    public partial class Category : UserControl
    {
        private Classes.Item itm;
        private MainWindow main;

        public Category(Classes.Item item, MainWindow main)
        {
            InitializeComponent();
            if (item != null)
            {
                itm = item;
                this.main = main;
                if (File.Exists(Directory.GetCurrentDirectory() + "/Images/Items/" + item.src))
                {
                    image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/Images/Items/" + item.src));
                }
                else
                {
                    image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/Images/Items/placeholder.png"));
                }

                name.Content = item.category;
            }
        }

        private void category_Click(object sender, RoutedEventArgs e)
        {
            main.frame.Navigate(new Pages.Main(main, itm.category));
        }
    }
}
