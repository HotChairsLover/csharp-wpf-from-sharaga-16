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
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        private Classes.Item itm;
        private Pages.Main main;
        public Item(Classes.Item item, Pages.Main main)
        {
            InitializeComponent();          

            if(item != null)
            {
                itm = item;
                this.main = main;
                if(File.Exists(Directory.GetCurrentDirectory() + "/Images/Items/" + item.src))
                {
                    image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/Images/Items/" + item.src));
                }
                else
                {
                    image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/Images/Items/placeholder.png"));
                }

                price.Content = item.price;
                name.Content = item.name;
            }
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if(Convert.ToInt32(count.Text) > 0)
            {
                int myCount = Convert.ToInt32(count.Text);
                count.Text = (myCount - 1).ToString();
            }
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(count.Text) < 10)
            {
                int myCount = Convert.ToInt32(count.Text);
                count.Text = (myCount + 1).ToString();
            }
        }

        private void inBox_Click(object sender, RoutedEventArgs e)
        {
            if (count.Text == "0")
            {
                MessageBox.Show("Нельзя добавить 0 предметов");
            }
            else if (Convert.ToInt32(count.Text) > 10)
            {
                MessageBox.Show("Нельзя добавить больше 10 предметов");
            }
            else
            {
                bool toAdd = true;
                Classes.ItemInBox newItem = new Classes.ItemInBox(itm.name, itm.price, itm.src, count.Text);
                foreach(Classes.ItemInBox item in Pages.Box.items)
                {
                    if(item.name == newItem.name & item.price == newItem.price & item.name == newItem.name)
                    {
                        MessageBox.Show("Предмет уже находится в корзине");
                        toAdd = false;
                        break;
                    }
                }
                if (toAdd)
                {
                    Pages.Box.items.Add(newItem);
                    Pages.Main.inBoxCount += 1;
                    main.box.Content = String.Format("Корзина ({0})", Pages.Main.inBoxCount);
                }
                
            }
        }
    }
}
