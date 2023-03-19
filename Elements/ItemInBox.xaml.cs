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
    /// Логика взаимодействия для ItemInBox.xaml
    /// </summary>
    public partial class ItemInBox : UserControl
    {
        private Classes.ItemInBox itm;
        private Pages.Box inBox;
        public ItemInBox(Classes.ItemInBox item, Pages.Box inBox)
        {
            InitializeComponent();

            if (item != null)
            {
                itm = item;
                this.inBox = inBox;
                if (File.Exists(Directory.GetCurrentDirectory() + "/Images/Items/" + item.src))
                {
                    image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/Images/Items/" + item.src));
                }
                else
                {
                    image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/Images/Items/placeholder.png"));
                }

                price.Content = item.price + " руб";
                name.Content = item.name;
                count.Content = item.count + " штук(а)";
                totalPrice.Content = String.Format("{0} руб", Convert.ToInt32(item.price) * Convert.ToInt32(item.count));
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Pages.Box.items.Remove(itm);
            Pages.Main.inBoxCount -= 1;
            inBox.LoadItems();
        }
    }
}
