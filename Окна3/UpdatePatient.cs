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
    internal class UpdatePatient {
        private static readonly string _signUpConnectionString = ConfigurationManager.ConnectionStrings["Patients"].ConnectionString;
        private static SqlConnection sqlConnection = new SqlConnection(_signUpConnectionString);

        public static bool registry(string FIO, string StartTime, string EndTime) {
            sqlConnection.Open();

            if (CheckUser(ref FIO, ref StartTime, ref EndTime, StartTime, EndTime)) {
                SqlCommand sqlCommand2 = new SqlCommand($"SELECT Id FROM Patients WHERE StartTime = '{StartTime}' AND EndTime = '{EndTime}'", sqlConnection);
                string id = sqlCommand2.ExecuteScalar().ToString();
                SqlCommand sqlCommand = new SqlCommand($"UPDATE Patients SET StartTime = '{StartTime}', EndTime = '{EndTime}', FIO = '{FIO}' " +
                    $"WHERE Id = '{id}'", sqlConnection);
                
                if (sqlCommand.ExecuteNonQuery() == 1) {
                    sqlConnection.Close();
                    return true;
                }
                else {

                }

            }
            else {

            }
            sqlConnection.Close();
            return false;
        }
        public static bool CheckUser(ref string FIO, ref string StartTime, ref string EndTime, string StartTime1, string EndTime1) {
            try {
                bool ItsTrue = CheckTime(StartTime1, EndTime1);
                ConvertTime(ref StartTime, ref EndTime);

                if (!ItsTrue) {
                    return false;
                }
                return true;
            }
            catch {
                return false;
            }
        }
        public static void ConvertTime(ref string StartTime, ref string EndTime) {
            StartTime = StartTime[0].ToString() + StartTime[1] + StartTime[3] + StartTime[4];
            EndTime = EndTime[0].ToString() + EndTime[1] + EndTime[3] + EndTime[4];
        }
        public static bool CheckTime(string StartTime, string EndTime) {
            bool IsTrue = true;
            try {
                if (Regex.IsMatch(StartTime[0].ToString() + StartTime[1], @"[^0-9\d_]")) IsTrue = false;
                if (Regex.IsMatch(StartTime[3].ToString() + StartTime[4], @"[^0-9\d_]")) IsTrue = false;
                if (StartTime[0] != '0' && StartTime[0] != '1') IsTrue = false;
                if (StartTime[1] == '8' || StartTime[1] == '9') IsTrue = false;
                if (StartTime[2] != ':') IsTrue = false;
                if (StartTime[3] > '6') IsTrue = false;

                if (Regex.IsMatch(EndTime[0].ToString() + EndTime[1], @"[^0-9\d_]")) IsTrue = false;
                if (Regex.IsMatch(EndTime[3].ToString() + EndTime[4], @"[^0-9\d_]")) IsTrue = false;
                if (EndTime[0] != '0' && EndTime[0] != '1') IsTrue = false;
                if (EndTime[1] == '8' || EndTime[1] == '9') IsTrue = false;
                if (EndTime[2] != ':') IsTrue = false;
                if (EndTime[3] > '6') IsTrue = false;
            }
            catch {
                return false;
            }



            return IsTrue;
        }

    }
}

