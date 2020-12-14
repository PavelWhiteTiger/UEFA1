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
using UEFA.Model;

namespace UEFA.Windows
{
    /// <summary>
    /// Логика взаимодействия для InfoTeamWindow.xaml
    /// </summary>
    public partial class InfoTeamWindow : Window
    {
        public TeamT Team { get; set; }
        public List<PlayerT> Players { get; set; }
        public InfoTeamWindow(TeamT team)
        {
            InitializeComponent();
            Team = team;
            Players = Team.PlayerT.ToList();
            DataContext = this;

        }
    }
}
