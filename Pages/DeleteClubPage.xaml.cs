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
using UEFA.Model;

namespace UEFA.Pages
{
    /// <summary>
    /// Логика взаимодействия для DeleteClubPage.xaml
    /// </summary>
    public partial class DeleteClubPage : Page
    {
        public List<TeamT> Teams { get; set; }
        public List<GameT> Games { get; set; }
        public TeamT Team { get; set; }
        public DeleteClubPage()
        {
            InitializeComponent();
            Teams = Connection.NewInstance().TeamT.ToList();
            Games = Connection.NewInstance().GameT.ToList();
            DataContext = this;


        }

        private void ComboBoxClub(object sender, SelectionChangedEventArgs e)
        {

            Team = ClubComboBox.SelectedItem as TeamT;

        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {

            if (Team != null)
            {
                List<GameT> games = Games.Where(x => x.TeamT.Team == Team.Team).ToList();
                List<GameT> games2 = Games.Where(x => x.TeamT1.Team == Team.Team).ToList();
                Connection.NewInstance().GameT.RemoveRange(games);
                Connection.NewInstance().GameT.RemoveRange(games2);
                Connection.NewInstance().SaveChanges();
                Connection.NewInstance().TeamT.Remove(Team);
                Connection.NewInstance().SaveChanges();
                MessageBox.Show("Удаление прошло успешно");
            }
            else if (Team == null)
            {
                MessageBox.Show("Выберите команду");
                return;
            }
            else
            {
                MessageBox.Show("Команда участвовала в матчах");
                return;
            }
            DataContext = null;
            Teams = Connection.NewInstance().TeamT.ToList();
            Games = Connection.NewInstance().GameT.ToList();
            ClubComboBox.SelectedIndex = -1;
            ClubComboBox.ItemsSource = Teams;
            DataContext = this;

        }
    }
}
