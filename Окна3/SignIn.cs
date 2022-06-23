using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Окна3 {
    internal static class SignIn {
        private static readonly string _signUpConnectionString = ConfigurationManager.ConnectionStrings["Doctors"].ConnectionString;
        private static SqlConnection sqlConnection = new SqlConnection(_signUpConnectionString);

        public static bool logIn(string email = "a@mail.ru", string password = "1111") {
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand sqlCommand = new SqlCommand($"SELECT Password, Email FROM Doctors WHERE Password = '{password}' AND Email = '{email}'", sqlConnection);
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dt);

            if (dt.Rows.Count == 1) {
                /*sqlCommand = new SqlCommand($"SELECT Email FROM Doctors WHERE Password = '{password}' AND Email = '{email}'", sqlConnection);
                string getValue = sqlCommand.ExecuteScalar().ToString();*/
                Window_manager.active_person = email;
                sqlConnection.Close();
                return true;
            }
            sqlConnection.Close();
            return false;
        }
        public static string getName(string email) {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand($"SELECT FIO FROM Doctors WHERE Email = '{email}'", sqlConnection);
            string getValue = "";
            try {
                getValue = sqlCommand.ExecuteScalar().ToString();
            } catch {

            }
            sqlConnection.Close();
            return getValue;
        }
    }
}
