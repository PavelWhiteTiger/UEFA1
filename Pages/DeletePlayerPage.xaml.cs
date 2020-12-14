using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using UEFA.Model;

namespace UEFA.Pages
{
    /// <summary>
    /// Логика взаимодействия для DeletePlayerPage.xaml
    /// </summary>
    public partial class DeletePlayerPage : Page
    {
        public List<TeamT> Teams { get; set; }
        public TeamT Team { get; set; }
        public PlayerT Player { get; set; }
        public DeletePlayerPage()
        {
            InitializeComponent();
            Teams = Connection.NewInstance().TeamT.ToList();
            DataContext = this;
        }



        private void ComboBoxClub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Player = ComboBoxPlayer.SelectedItem as PlayerT;

        }

        private void DeletePlayer(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection.NewInstance().PlayerT.Remove(Player);
                Connection.NewInstance().SaveChanges();
            }
            catch
            {
                MessageBox.Show("Выберите клуб и игрока");

            }
            finally
            {
                DataContext = null;
                Teams = Connection.NewInstance().TeamT.ToList();
                ComboBoxPlayer.SelectedIndex = -1;
                ComboBoxClub.SelectedIndex = -1;
                DataContext = this;
            }
        }
    }
}
