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
using System.Data.SQLite;

namespace THANA
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            RegistrationDatabase registrationDataBase = new RegistrationDatabase();
            registrationDataBase.Create_folder();
            registrationDataBase.Create_database();
            registrationDataBase.Create_table();
        }
        private void Account_Registration(object sender, RoutedEventArgs e)
        {
            try
            {
                try
                {
                    string _T_name = T_name.Text;
                    int _U_number = int.Parse(U_number.Text);
                    int _User_id = int.Parse(User_id.Text);
                    int _password = int.Parse(password.Text);
                    int _re_password = int.Parse(re_password.Text);


                    if (_T_name != "")
                    {
                        using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Info\Registration.db; Version=3;"))
                        {
                            conn.Open();
                            string sql1 = "INSERT INTO Thana (T_name, U_nomber, User_ID, password, Re_Pasword) VALUES('" + _T_name + "','" + _U_number + "','" + _User_id + "','" + _password + "','" + _re_password + "')";
                            SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Succesfully create Account");
                            this.Close();
                        }

                    }

                    MessageBox.Show("Information is Save");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
