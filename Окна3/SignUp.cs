using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Окна3 {
    internal static class SignUp {
        private static readonly string _signUpConnectionString = ConfigurationManager.ConnectionStrings["Doctors"].ConnectionString;
        private static SqlConnection sqlConnection = new SqlConnection(_signUpConnectionString);

        public static bool registry(string FIO, string email, string password, string ConfirmPassword) {
            sqlConnection.Open();

            if (CheckUser(email, password, ConfirmPassword)) {
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO Doctors(FIO, Email, Password) VALUES('{FIO}', '{email}', '{password}')", sqlConnection);
                
                if (sqlCommand.ExecuteNonQuery() == 1) {
                    return true;
                } else {

                }

            } else {

            }
            sqlConnection.Close();
            return false;
        }





        public static bool CheckUser(string email, string password, string ConfirmPassword) {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand sqlCommand = new SqlCommand($"SELECT Email FROM Doctors WHERE Email = '{email}'", sqlConnection);
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dt);

            if (dt.Rows.Count > 0 || password != ConfirmPassword || password.Count() < 6 || CheckPassword(password)) {
                return false;
            }
            return true;
        }
        private static bool CheckPassword(string password) {
            return !string.IsNullOrEmpty(password) && Regex.IsMatch(password, @"[^0-9a-zA-z\d_]");
        }
    }

}
