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
using System.Runtime.InteropServices;
using System.Security;

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
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void ClickLogin(object sender, RoutedEventArgs e)
        {
            string user = UserBox.Text;
            string pwd = ConvertToUnsecureString(Password.SecurePassword);
            OracleConnection conn = new ConnectionObj().getConnection("login", "login");

            conn.Open();

            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM users WHERE LOWER(username) = LOWER('{user}') AND password = '{pwd}'";

            try
            {
                OracleDataReader reader = cmd.ExecuteReader();
                MessageBox.Show(pwd);
                if (reader.Read())
                {
                    MessageBox.Show($"Esto es una prueba\n user: {user} \n pass: {pwd}", "Prueba", MessageBoxButton.OK, MessageBoxImage.Information);
                    MessageBox.Show($"Has sido loggeado como: {reader.GetString(0)}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecto, verifica los datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private string ConvertToUnsecureString(SecureString securePassword)
        {
            IntPtr unmanagedPassword = IntPtr.Zero;
            try
            {
                unmanagedPassword = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                int passwordLength = securePassword.Length;
                char[] passwordChars = new char[passwordLength];
                Marshal.Copy(unmanagedPassword, passwordChars, 0, passwordLength);
                return new string(passwordChars);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedPassword);
            }
        }
    }
}
