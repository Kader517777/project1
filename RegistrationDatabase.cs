using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace THANA
{
    internal class RegistrationDatabase
    {
        public void Create_folder()
        {
            try
            {
                Directory.CreateDirectory(@"C:\Info");
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }
        public void Create_database()
        {
            try
            {
                SQLiteConnection.CreateFile(@"C:\Info\Registration.db");

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }
        public void Create_table()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Info\Registration.db; Version=3;"))
                {
                    conn.Open();
                    string sql = "CREATE TABLE Thana(T_name varchar(30), U_nomber int, User_ID int, password ind, Re_Pasword int)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }
    }
}
