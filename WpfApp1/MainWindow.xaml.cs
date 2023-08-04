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
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection conn = new ConnectionObj().getConnection();

            conn.Open();

            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM tab";

            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Modificar.Content = reader.GetString(0);
            }
            
        }
    }
}
