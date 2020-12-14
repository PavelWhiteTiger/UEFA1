using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для UpdateStadium.xaml
    /// </summary>
    public partial class UpdateStadium : Page
    {
        public byte[] BArray;
        public List<StadiumT> Stadiums { get; set; }
        public StadiumT Stadium { get; set; }
        public UpdateStadium()
        {
            InitializeComponent();
            Stadiums = Connection.NewInstance().StadiumT.ToList();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (StackAdd.Children.OfType<TextBox>().Any(x => x.Text == "") || StackAdd.Children.OfType<ComboBox>().Any(x => x.SelectedIndex < 0))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if (BArray != null)
            {
                Stadium.Photo = BArray;
            }
            try
            {
                Connection.NewInstance().SaveChanges();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                DataContext = null;
                BArray = null;
                PhotoImage.Source = null;
                Stadiums = Connection.NewInstance().StadiumT.ToList();
                DataContext = this;
            }
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
                    PhotoImage.Stretch = Stretch.Fill;
                    PhotoImage.Source = bi3;
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

        private void StadiumComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Stadium = StadiumComboBox?.SelectedItem as StadiumT;
        }
    }
}
