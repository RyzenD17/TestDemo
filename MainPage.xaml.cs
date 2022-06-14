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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        List<Shop> ShopFilterStart = BaseClass.Base.Shop.ToList();
        List<Shop> ShopFilter;

        public MainPage()
        {
            InitializeComponent();
            LVTest.ItemsSource = BaseClass.Base.Shop.ToList();
            CBFilter.Items.Add("Все записи");
            CBFilter.SelectedIndex = 0;
            CBSorting.Items.Add("По идентификатору");
            CBSorting.Items.Add("По названию");
            CBSorting.Items.Add("По автору");
            CBSorting.SelectedIndex=0;
        }

        private void BtnAddNewData_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new AddOrUpdatePage());
        }

        private void BtbUpdateData_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int id = Convert.ToInt32(btn.Uid);
            Shop ShopUpdate = BaseClass.Base.Shop.FirstOrDefault(x => x.ID == id);
            FrameClass.MainFrame.Navigate(new AddOrUpdatePage(ShopUpdate));
        }

        private void Filters()
        {
            int index = CBFilter.SelectedIndex;
            if(index!=0)
            {
                ShopFilter = ShopFilterStart.Where(x => x.CountInShop == index).ToList();
            }
            else
            {
                ShopFilter = ShopFilterStart;
            }
           
            if(!string.IsNullOrWhiteSpace(TBFindText.Text))
            {
                ShopFilter = ShopFilter.Where(x => x.Title.ToLower().Contains(TBFindText.Text.ToLower())).ToList();
            }
            LVTest.ItemsSource = ShopFilter;

        }

        private void TBFindText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filters();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int id = Convert.ToInt32(btn.Uid);
                Shop ShopDelete = BaseClass.Base.Shop.FirstOrDefault(x => x.ID == id);
                MessageBoxResult messageboxResult = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo);
                if(messageboxResult==MessageBoxResult.Yes)
                {
                    BaseClass.Base.Shop.Remove(ShopDelete);
                }
                BaseClass.Base.SaveChanges();
                FrameClass.MainFrame.Navigate(new MainPage());
                MessageBox.Show("Запись успешно удалена!", "Удаление");

            }
           catch
            {
                MessageBox.Show("Возникла ошибка при удалении записи!", "Ошибка");
            }
        }

        private void TBTitleGenre_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int id = Convert.ToInt32(tb.Uid);
            List<Shop> titleGenre = BaseClass.Base.Shop.Where(x => x.ID == id).ToList();
            string titleGenreStr = "";
            foreach (Shop s in titleGenre)
            {
                titleGenreStr = s.Title + " | " + s.Genre;
            }
            tb.Text = titleGenreStr;
        }

        private void btnSortingAZ_Click(object sender, RoutedEventArgs e)
        {
            
            if (CBSorting.SelectedIndex==0)
            {
                ShopFilter.Sort((x, y) => x.ID.CompareTo(y.ID));
                LVTest.Items.Refresh();
            }
            if (CBSorting.SelectedIndex == 1)
            {
                ShopFilter.Sort((x, y) => x.Title.CompareTo(y.Title));
                LVTest.Items.Refresh();
            }
            if (CBSorting.SelectedIndex == 2)
            {
                ShopFilter.Sort((x, y) => x.Author.CompareTo(y.Author));
                LVTest.Items.Refresh();
            }
        }

        private void btnSortingZA_Click(object sender, RoutedEventArgs e)
        {

            if (CBSorting.SelectedIndex == 0)
            {
                ShopFilter.Sort((x, y) => x.ID.CompareTo(y.ID));
                ShopFilter.Reverse();
                LVTest.Items.Refresh();
            }
            if (CBSorting.SelectedIndex == 1)
            {
                ShopFilter.Sort((x, y) => x.Title.CompareTo(y.Title));
                ShopFilter.Reverse();
                LVTest.Items.Refresh();
            }
            if (CBSorting.SelectedIndex == 2)
            {
                ShopFilter.Sort((x, y) => x.Author.CompareTo(y.Author));
                ShopFilter.Reverse();
                LVTest.Items.Refresh();
            }
        }

        private void CBFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filters();
        }
    }
}
