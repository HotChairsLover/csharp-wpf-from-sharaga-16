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
    /// Логика взаимодействия для Box.xaml
    /// </summary>
    public partial class Box : Page
    {
        public static List<ItemInBox> items = new List<ItemInBox>();
        private MainWindow main;
        private string category;
        public Box(MainWindow main, string category)
        {
            InitializeComponent();
            this.main = main;
            this.category = category;
            LoadItems();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (category != "")
            {
                main.frame.Navigate(new Main(main, category));
            }
            else
            {
                main.frame.Navigate(new CategoryChose(main));
            }
        }

        public void LoadItems()
        {
            parent.Children.Clear();
            int totalPrice = 0;

            foreach (ItemInBox item in items)
            {
                parent.Children.Add(new Elements.ItemInBox(item, this));
                totalPrice += Convert.ToInt32(item.price) * Convert.ToInt32(item.count);
            }

            this.totalPrice.Content = String.Format("Общая цена: {0} руб.", totalPrice);
        }
    }
}
