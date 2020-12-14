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
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Win32;
using System.IO;

namespace UEFA.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreatePlayerPage.xaml
    /// </summary>
    public partial class CreatePlayerPage : Page
    {
        public byte[] BArray;
        public PlayerT Player { get; set; }
        public List<TeamT> Teams { get; set; }
        public List<CountryT> Countries { get; set; }
        public List<RoleT> Roles { get; set; }
        public CreatePlayerPage()
        {
            InitializeComponent();
            Player = new PlayerT();
            Countries = Connection.NewInstance().CountryT.OrderBy(x => x.Country).ToList();
            Roles = Connection.NewInstance().RoleT.ToList();
            Teams = Connection.NewInstance().TeamT.ToList();
            DataContext = this;
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {

            if (StackAdd.Children.OfType<TextBox>().Any(x => x.Text == "") || StackAdd.Children.OfType<ComboBox>().Any(x => x.SelectedIndex < 0))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            try
            {
                Player.StatisticPlayerT = new StatisticPlayerT();
                Player.Photo = BArray;
                Connection.NewInstance().PlayerT.Add(Player);
                Connection.NewInstance().SaveChanges();
            }
            catch (Exception ex)
            {
                Connection.NewInstance().PlayerT.Remove(Player);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DataContext = null;
                PhotoImage.Source = null;
                BArray = null;
                Countries = Connection.NewInstance().CountryT.ToList();
                Roles = Connection.NewInstance().RoleT.ToList();
                Teams = Connection.NewInstance().TeamT.ToList();
                Player = new PlayerT();
                StackAdd.Children.OfType<TextBox>().ToList().ForEach(tb => tb.Text = String.Empty);
                StackAdd.Children.OfType<ComboBox>().ToList().ForEach(cb => cb.SelectedIndex = -1);
                DataContext = this;
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
