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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin(string UserName)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            this.Title = "Admin manager";
            Username.Content = $"Bienvenido {UserName}!";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> labels = new List<string> { "Prueba 1", "Prueba 2", "Prueba 3", "Prueba 4" };
            CustomInputDialog dialog = new CustomInputDialog(labels.Count, labels);
            if (dialog.ShowDialog() == true)
            {
                List<string> inputValues = dialog.GetInputValues();
                MessageBox.Show(string.Join(", ", inputValues));
            }

        }
    }
}
