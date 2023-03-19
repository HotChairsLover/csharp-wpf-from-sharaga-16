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
using Furniture_Store.Classes;

namespace Furniture_Store.Pages
{
    /// <summary>
    /// Логика взаимодействия для CategoryChose.xaml
    /// </summary>
    public partial class CategoryChose : Page
    {
        private MainWindow main;
        private List<Item> items = new List<Item>();
        private List<string> categories = new List<string>();
        public CategoryChose(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            box.Content = String.Format("Корзина ({0})", Main.inBoxCount);
            foreach (Item item in Main.items)
            {
                if(!categories.Contains(item.category))
                {
                    categories.Add(item.category);
                    items.Add(item);
                }
            }
            LoadItems();            
        }

        public void LoadItems()
        {
            parent.Children.Clear();

            foreach (Item item in items)
            {
                parent.Children.Add(new Elements.Category(item, main));
            }
        }

        private void box_Click(object sender, RoutedEventArgs e)
        {
            main.frame.Navigate(new Box(main, ""));
        }
    }
}
