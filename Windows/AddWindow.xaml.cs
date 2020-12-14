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
using UEFA.Pages;

namespace UEFA.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void CRUDButtons(object sender, RoutedEventArgs e)
        {

            switch ((sender as Button).Name)
            {
                case "CreateClubButton":
                    CRUDFrame.Navigate(new CreateClubPage());
                    break;
                case "CreateStadiumButton":
                    CRUDFrame.Navigate(new CreateStadium());
                    break;
                case "CreatePlayerbButton":
                    CRUDFrame.Navigate(new CreatePlayerPage());
                    break;
                case "CreateGameButton":
                    CRUDFrame.Navigate(new CreateGame());
                    break;
                case "DeleteClubButton":
                    CRUDFrame.Navigate(new DeleteClubPage());
                    break;
                case "DeletePlayerButton":
                    CRUDFrame.Navigate(new DeletePlayerPage());
                    break;
                case "DeleteStadiumButton":
                    CRUDFrame.Navigate(new DeleteStadium());
                    break;
                case "DeleteGameButton":
                    CRUDFrame.Navigate(new DeleteGame());
                    break;
                case "UpdateClubButton":
                    CRUDFrame.Navigate(new UpdateClubPage());
                    break;
                case "UpdatePlayerButton":
                    CRUDFrame.Navigate(new UpdatePlayerPage());
                    break;
                case "UpdateGameButton":
                    CRUDFrame.Navigate(new UpdateGame());
                    break;
                case "UpdateStatisticButton":
                    CRUDFrame.Navigate(new UpdateStatistic());
                    break;
                case "UpdateStadiumButton":
                    CRUDFrame.Navigate(new UpdateStadium());
                    break;
                case "ExitButton":
                    new MenuWindow().Show();
                    this.Close();
                    break;
                  

            }
        }

    }
}
