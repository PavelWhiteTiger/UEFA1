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
    /// Логика взаимодействия для DeleteStadium.xaml
    /// </summary>
    public partial class DeleteStadium : Page
    {

        public List<StadiumT> Stadiums { get; set; }
        public StadiumT Stadium { get; set; }
        public DeleteStadium()
        {
            InitializeComponent();
            Stadiums = Connection.NewInstance().StadiumT.ToList();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Stadium = DeleteComboBox.SelectedItem as StadiumT;
                Connection.NewInstance().StadiumT.Remove(Stadium);
                Connection.NewInstance().SaveChanges();

            }
            catch 
            {
                MessageBox.Show("Выберите стадион для удаления и проверьте что на нем не играют команды");
            }
            finally
            {
                Stadiums = Connection.NewInstance().StadiumT.ToList();
                DeleteComboBox.SelectedIndex = -1;
                DeleteComboBox.ItemsSource = Stadiums;

            }
        }
    }
}
