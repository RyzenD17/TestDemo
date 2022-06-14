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

namespace TestDemo
{
    /// <summary>
    /// Логика взаимодействия для AddOrUpdatePage.xaml
    /// </summary>
    public partial class AddOrUpdatePage : Page
    {
        Shop shop = new Shop();
        bool flag;
        public AddOrUpdatePage()
        {
            InitializeComponent();
            flag = true;
        }

        public AddOrUpdatePage(Shop ShopUpdate)
        {
            InitializeComponent();
            shop = ShopUpdate;
            TBTitle.Text = shop.Title;
            TBGenre.Text = shop.Genre;
            TBAuthor.Text = shop.Author;
            TBInShop.Text = Convert.ToString(shop.CountInShop);
            TBInStock.Text = Convert.ToString(shop.CountInStock);
            TBDescription.Text = shop.Description;
            TBCost.Text = Convert.ToString(shop.Cost);
        }

        private void BtnSaveAllChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string title = TBTitle.Text;
                string genre = TBGenre.Text;
                string author = TBAuthor.Text;
                int inshop = Convert.ToInt32(TBInShop.Text);
                int instock = Convert.ToInt32(TBInStock.Text);
                string description = TBDescription.Text;
                double cost = Convert.ToDouble(TBCost.Text);
                shop.Title = title;
                shop.Genre = genre;
                shop.Author = author;
                shop.CountInShop = inshop;
                shop.CountInStock = instock;
                shop.Description = description;
                shop.Image = "NULL";
                shop.Cost = cost;
                if (flag == true)
                {
                    BaseClass.Base.Shop.Add(shop);
                }
                BaseClass.Base.SaveChanges();
                MessageBox.Show("Данные записаны!", "Запись");
                FrameClass.MainFrame.Navigate(new MainPage());
            }

            catch
            {
                MessageBox.Show("Ошибка при сохранении!", "Ошибка!");
            }
        }
    }
}
