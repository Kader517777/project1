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
using System.Data.SQLite;

namespace THANA
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
            try
            {
                int _User_id = int.Parse(User_id.Text);
                int _password = int.Parse(password.Text);


                using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Info\Registration.db; Version=3;"))
                {
                    conn.Open();
                    string sql1 = "SELECT * FROM [Thana] WHERE User_ID= '" + _User_id + "'";
                    SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
                    SQLiteDataReader qLiteDataReader = cmd.ExecuteReader();
                    while (qLiteDataReader.Read())
                    {
                        int uuser_id = int.Parse(qLiteDataReader["User_ID"].ToString());
                        int u_password = int.Parse(qLiteDataReader["password"].ToString());
                        int u_Re_Pasword = int.Parse(qLiteDataReader["Re_Pasword"].ToString());



                        if (_User_id == uuser_id && _password == u_password && u_Re_Pasword == u_password)
                        {
                            Window1 window1 = new Window1();
                            window1.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("User ID or Password is Wrong!");
                        }
                    }


                    conn.Close();
                }






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Account(object sender, RoutedEventArgs e)
        {
            try
            {
                Registration registration = new Registration();
                registration.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
