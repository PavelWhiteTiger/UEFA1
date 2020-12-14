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
    /// Логика взаимодействия для UpdateClubPage.xaml
    /// </summary>
    public partial class UpdateClubPage : Page
    {
        public byte[] BArray;
        public List<StadiumT> Stadiums { get; set; }
        public List<CountryT> Countries { get; set; }
        public List<TeamT> Teams { get; set; }
        public TeamT Team { get; set; }



        public UpdateClubPage()
        {
            InitializeComponent();
            Teams = Connection.NewInstance().TeamT.ToList();
            Countries = Connection.NewInstance().CountryT.ToList();
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
            if (BArray != null)
            {
                Team.Photo = BArray;
            }
            try
            {
                Connection.NewInstance().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DataContext = null;
                PhotoImage.Source = null;
                BArray = null;
                Teams = Connection.NewInstance().TeamT.ToList();
                Countries = Connection.NewInstance().CountryT.ToList();
                Stadiums = Connection.NewInstance().StadiumT.ToList();
                DataContext = this;
            }
        }

        private void NameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Team = NameComboBox?.SelectedItem as TeamT;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
