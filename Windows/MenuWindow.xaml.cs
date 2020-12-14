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
using System.Windows.Shapes;

namespace UEFA.Windows
{
    using Model;
    using System.Threading;

    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
       
        public List<TeamT> Teams { get; set; }
        public List<PlayerT> Players { get; set; }
        public List<GameT> Games { get; set; }
        public TeamT Team { get; set; }
        public MenuWindow()
        {
            InitializeComponent();
            Connection.refresh();
            Teams = Connection.NewInstance().TeamT.ToList();
            Players = Connection.NewInstance().PlayerT.ToList();
            Games = Connection.NewInstance().GameT.ToList();

            DataContext = this;
            if (MainWindow.IsAdmin == false)
            {
                ButtonAdmin.Visibility = Visibility.Hidden;

            }

        }

        private void AdminButton(object sender, RoutedEventArgs e)
        {
            new AddWindow().Show();
            this.Close();

        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var GamesNew = new List<GameT>();
            GamesNew.Clear();
            if (SearchTextBox.Text.Length > 0)
            {
                for (int i = 0; i < Connection.NewInstance().GameT.ToList().Count; i++)
                {

                    if (Connection.NewInstance().GameT.ToList()[i].TeamT.Team.ToLower().Contains(SearchTextBox.Text.ToLower()) || Connection.NewInstance().GameT.ToList()[i].TeamT1.Team.ToLower().Contains(SearchTextBox.Text.ToLower()))
                    {
                        GamesNew.Add(Connection.NewInstance().GameT.ToList()[i]);
                    }
                }
                GameListBox.ItemsSource = GamesNew;
            }
            else
                GameListBox.ItemsSource = Games;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new InfoWindow(PlayerDataGrid.SelectedItem as PlayerT).ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new InfoTeamWindow(DataGridTeam.SelectedItem as TeamT).ShowDialog();
        }
    }
}
