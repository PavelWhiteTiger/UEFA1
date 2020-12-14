using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using UEFA.Converter;
using UEFA.Model;

namespace UEFA.Pages
{
    /// <summary>
    /// Логика взаимодействия для UpdateGame.xaml
    /// </summary>
    public partial class UpdateGame : Page
    {
        Regex reg;
        public List<GameT> Games { get; set; }
        public List<StadiumT> Stadiums { get; set; }
        public GameT Game { get; set; }
        public UpdateGame()
        {
            reg = new Regex(@"^(\d{1,2}):(\d{1,2})$");
            InitializeComponent();
            Games = Connection.NewInstance().GameT.ToList();
            Stadiums = Connection.NewInstance().StadiumT.ToList();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (StackAdd.Children.OfType<TextBox>().Any(x => x.Text == ""))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            Game = ComboBoxGame.SelectedItem as GameT;
            if (!reg.IsMatch(Game.Score.ToString()))
            {
                MessageBox.Show("Введите счет в формате 2:5");
                return;
            }
            try
            {
                Game.Winner = ConverterToScore.Convert(Game.Score);
                Connection.NewInstance().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DataContext = null;
                Games = Connection.NewInstance().GameT.ToList();
                Stadiums = Connection.NewInstance().StadiumT.ToList();
                DataContext = this;
            }
        }
    }
}
