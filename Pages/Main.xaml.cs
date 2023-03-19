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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public static List<Item> items = new List<Item>();
        private MainWindow main;
        private string category;
        public static int inBoxCount = 0;
        public Main(MainWindow main, string category)
        {
            InitializeComponent();           
            this.main = main;
            this.category = category;
            box.Content = String.Format("Корзина ({0})", inBoxCount);
            LoadItems();
        }


        public void LoadItems()
        {
            parent.Children.Clear();
            
            foreach(Item item in items)
            {
                if (item.category == category)
                {
                    parent.Children.Add(new Elements.Item(item, this));
                }
            }
        }

        private void box_Click(object sender, RoutedEventArgs e)
        {
            main.frame.Navigate(new Box(main, category));
        }

        private void category_Click(object sender, RoutedEventArgs e)
        {
            main.frame.Navigate(new CategoryChose(main));
        }

    }
}
