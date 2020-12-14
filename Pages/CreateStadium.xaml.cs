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
    /// Логика взаимодействия для CreateStadium.xaml
    /// </summary>
    public partial class CreateStadium : Page
    {
        public byte[] BArray;
        public StadiumT Stadium { get; set; }
        public CreateStadium()
        {
            InitializeComponent();
            Stadium = new StadiumT();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (StackAdd.Children.OfType<TextBox>().Any(x => x.Text == "") )
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            try
            {
                Stadium.Photo = BArray;
                Connection.NewInstance().StadiumT.Add(Stadium);
                Connection.NewInstance().SaveChanges();
            }
            catch
            {
                MessageBox.Show("12");
            }
            finally
            {
                DataContext = null;
                Stadium = new StadiumT();
                PhotoImage.Source = null;
                BArray = null;
                StackAdd.Children.OfType<TextBox>().ToList().ForEach(x => x.Text = "");
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
