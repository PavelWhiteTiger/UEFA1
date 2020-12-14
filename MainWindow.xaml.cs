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
using UEFA.Pages;
using UEFA.Windows;

namespace UEFA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public RegisterPage regPage;
        public static bool IsAdmin ;
        public MainWindow()
        {
            InitializeComponent();
            regPage = new RegisterPage(this);

        }

        private void entryButton(object sender, RoutedEventArgs e)
        {
          
                new MenuWindow().Show();
                this.Close();

            
        }

        private void boolButton(object sender, RoutedEventArgs e)
        {
            if (adminButton.IsChecked == true)
            {
                this.Width = 1200;
                registerFrame.Navigate(regPage);
                buttonEntry.Visibility = Visibility.Hidden;
                IsAdmin = true;
            }
            else
            {
                this.Width = 800;
                buttonEntry.Visibility = Visibility.Visible;
            }
        }

        private void infoButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ли́га чемпио́нов УЕФА (англ. UEFA Champions League) — ежегодный международный турнир по футболу, организованный Союзом европейских футбольных ассоциаций (УЕФА) среди клубов высших дивизионов в Европе.\n\n" +
                "Самый престижный европейский клубный футбольный турнир. Со своего первого розыгрыша в сезоне 1955 / 56 и по сезон 1991 / 92 назывался Кубком европейских чемпионов(англ. European Champion Clubs' Cup)." +
                " В сезоне 1991/92 был изменён формат турнира и после стадии 1/8 финала игрались групповые турниры. Тогда же появились гимн и эмблема. С сезона 1992/93 турнир получил своё нынешнее название.", "Info");
        }

    }
}
