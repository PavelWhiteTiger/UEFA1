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
    /// Логика взаимодействия для DeleteGame.xaml
    /// </summary>
    public partial class DeleteGame : Page
    {
        public List<GameT> Games { get; set; }
        public GameT Game { get; set; }
        public DeleteGame()
        {
            InitializeComponent();
            Games = Connection.NewInstance().GameT.ToList();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Game = DeleteComboBox.SelectedItem as GameT;
                Connection.NewInstance().GameT.Remove(Game);
                Connection.NewInstance().SaveChanges();

            }
            catch 
            {
                MessageBox.Show("Выберите игру для удаления");
            }
            finally
            {
                DataContext = null;
                Games = Connection.NewInstance().GameT.ToList();
                DeleteComboBox.SelectedIndex = -1;
                DeleteComboBox.ItemsSource = Games;
                DataContext = this;
            }
        }
    }
}
