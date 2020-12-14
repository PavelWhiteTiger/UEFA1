using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для CreateClubPage.xaml
    /// </summary>
    public partial class CreateClubPage : Page
    {
        public byte[] BArray;
        public TeamT Teams { get; set; }
        public List<CountryT> Countries { get; set; }
        public List<StadiumT> Stadiums { get; set; }

        public CreateClubPage()
        {
            InitializeComponent();
            Countries = Connection.NewInstance().CountryT.ToList();
            Stadiums = Connection.NewInstance().StadiumT.ToList();
            Teams = new TeamT();
            DataContext = this;

        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            if (StackAdd.Children.OfType<TextBox>().Any(x => x.Text == "") || StackAdd.Children.OfType<ComboBox>().Any(x => x.SelectedIndex < 0))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            Teams.Photo = BArray;
            Teams.StatisticTeamT = new StatisticTeamT();
            try
            {
                Connection.NewInstance().TeamT.Add(Teams);
                Connection.NewInstance().SaveChanges();
            }
            catch (Exception ex)
            {
                Connection.NewInstance().TeamT.Remove(Teams);
                MessageBox.Show(ex.Message, "Ошибка заполнения данных");
            }
            finally
            {
                DataContext = null;

                Countries = Connection.NewInstance().CountryT.ToList();
                Stadiums = Connection.NewInstance().StadiumT.ToList();
                Teams = new TeamT();
                PhotoImage.Source = null;
                BArray = null;
                DataContext = this;
                StackAdd.Children.OfType<TextBox>().ToList().ForEach(tb => tb.Text = String.Empty);
                StackAdd.Children.OfType<ComboBox>().ToList().ForEach(cb => cb.SelectedIndex = -1);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog f = new OpenFileDialog();
                if (f.ShowDialog() == true)
                {
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(f.FileName);
                    bi3.EndInit();
                    (PhotoImage as System.Windows.Controls.Image).Stretch = Stretch.Fill;
                    (PhotoImage as System.Windows.Controls.Image).Source = bi3;
                    using (var a = new FileStream(f.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (BinaryReader br = new BinaryReader(a))
                        {
                            BArray = br.ReadBytes((int)a.Length);
                        }
                    }


                }
            }
            catch
            {
                MessageBox.Show("Поместите файл формата .png .jp(e)g .ico");
                return;
            }
        }
    }
}
