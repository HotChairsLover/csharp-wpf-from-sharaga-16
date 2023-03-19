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

namespace Furniture_Store
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Pages.Main.items.Add(new Item("Шкаф", 20000, "", "Шкафы"));
            Pages.Main.items.Add(new Item("Вк", 40000, "vk.png", "Стулья"));
            Pages.Main.items.Add(new Item("Инстаграм", 30000, "instagram.png", "Туалеты"));
            Pages.Main.items.Add(new Item("Телеграм", 25000, "telegramm.png", "Стулья"));
            Pages.Main.items.Add(new Item("Бэк", 80000, "backgroung.jpg", "Шкафы"));
            Pages.Main.items.Add(new Item("123", 123521, "backgroung.jpg", "Жопа"));
            OpenPage(new Pages.CategoryChose(this));
        }

        public void OpenPage(Page page)
        {
            frame.Navigate(page);
        }
    }
}
