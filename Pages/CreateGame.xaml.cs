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
    /// Логика взаимодействия для CreateGame.xaml
    /// </summary>
    public partial class CreateGame : Page 
    {
        public List<CountryT> Countries { get; set; }
        public List<StadiumT> Stadiums { get; set; }
        public List<TeamT> Teams { get; set; }
        public GameT Game { get; set; }
        Regex reg;

        public CreateGame()
        {
            reg = new Regex(@"^(\d{1,2}):(\d{1,2})$");
            InitializeComponent();
            Countries = Connection.NewInstance().CountryT.ToList();
            Stadiums = Connection.NewInstance().StadiumT.ToList();
            Teams = Connection.NewInstance().TeamT.ToList();
            Game = new GameT() { Date = DateTime.Now };
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (StackAdd.Children.OfType<TextBox>().Any(x => x.Text == "") || StackAdd.Children.OfType<ComboBox>().Any(x => x.SelectedIndex < 0))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if (!reg.IsMatch(Game.Score.ToString()))
            {
                MessageBox.Show("Введите счет в формате 2:5");
                return;
            }
            Game.Winner = ConverterToScore.Convert(Game.Score);

            try
            {
                Connection.NewInstance().GameT.Add(Game);
                Connection.NewInstance().SaveChanges();

            }
            catch (Exception ex)
            {
                Connection.NewInstance().GameT.Remove(Game);
                MessageBox.Show(ex.Message, "Ошибка заполнения данных");
            }
            finally
            {
                DataContext = null;
                Countries = Connection.NewInstance().CountryT.ToList();
                Stadiums = Connection.NewInstance().StadiumT.ToList();
                Teams = Connection.NewInstance().TeamT.ToList();
                Game = new GameT() { Date = DateTime.Now }; ;
                DataContext = this;
                StackAdd.Children.OfType<TextBox>().ToList().ForEach(tb => tb.Text = String.Empty);
                StackAdd.Children.OfType<ComboBox>().ToList().ForEach(cb => cb.SelectedIndex = -1);
                DatePickerGame.Text = DateTime.Now.ToString();

            }
        }
    }
}
