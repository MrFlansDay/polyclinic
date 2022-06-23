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
    internal class SignUpPatient {
        private static int id = 10;
        private static readonly string _signUpConnectionString = ConfigurationManager.ConnectionStrings["Patients"].ConnectionString;
        private static SqlConnection sqlConnection = new SqlConnection(_signUpConnectionString);

        public static bool registry(string FIO, string StartTime, string EndTime) {
            sqlConnection.Open();

            if (CheckUser(ref FIO, ref StartTime, ref EndTime, StartTime, EndTime)) {
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO Patients(DayOfTheWeek, StartTime, EndTime, FIO, Doctor, Id) " +
                    $"VALUES('{Window_manager.active_window.container.day}', '{StartTime}', '{EndTime}', '{FIO}', '{Window_manager.active_window.container.mail}', '{id}')", sqlConnection);

                if (sqlCommand.ExecuteNonQuery() == 1) {
                    id++;
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
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();
                SqlCommand sqlCommand = new SqlCommand($"SELECT StartTime, EndTime FROM Patients WHERE StartTime > {StartTime} AND EndTime < {EndTime}", sqlConnection);
                adapter.SelectCommand = sqlCommand;
                adapter.Fill(dt);

                if (dt.Rows.Count > 0 || !ItsTrue) {
                    return false;
                }
                return true;
            } catch {
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
            } catch {
                return false;
            }

            

            return IsTrue;
        }

    }
}
