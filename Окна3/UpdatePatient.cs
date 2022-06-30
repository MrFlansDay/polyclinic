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

        public static bool registry(string FIO, string StartTime, string EndTime, string StartTime2 = "", string EndTime2 = "", string FIO2 = "") {
            sqlConnection.Open();

            if (CheckUser(ref FIO, ref StartTime, ref EndTime, ref StartTime2, ref EndTime2)) {
                SqlCommand sqlCommand2 = new SqlCommand($"SELECT Id FROM Patients WHERE StartTime = '{StartTime}' AND EndTime = '{EndTime}'", sqlConnection);
                string id = sqlCommand2.ExecuteScalar().ToString();
                SqlCommand sqlCommand = new SqlCommand($"UPDATE Patients SET StartTime = '{StartTime2}', EndTime = '{EndTime2}', FIO = '{FIO2}' " +
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
        public static bool CheckUser(ref string FIO, ref string StartTime, ref string EndTime, ref string StartTime1, ref string EndTime1) {
            if (StartTime.Count() == 5) {


                try {
                    bool ItsTrue = CheckTime(StartTime1, EndTime1);
                    ConvertTime(ref StartTime1, ref EndTime1);

                    if (!ItsTrue) {
                        return false;
                    }
                    return true;
                }
                catch {
                    return false;
                }
            } else {
                /*StartTime = StartTime[0].ToString() + StartTime[1] + ':' + StartTime[2] + StartTime[3];
                EndTime = EndTime[0].ToString() + EndTime[1] + ':' + EndTime[2] + EndTime[3];
                StartTime1 = StartTime1[0].ToString() + StartTime1[1] + ':' + StartTime1[2] + StartTime1[3];
                EndTime1 = EndTime1[0].ToString() + EndTime1[1] + ':' + EndTime1[2] + EndTime1[3];*/
                try {
                    bool ItsTrue = CheckTime(StartTime1, EndTime1);
                    ConvertTime(ref StartTime1, ref EndTime1);

                    if (!ItsTrue) {
                        return false;
                    }
                    return true;
                }
                catch {
                    return false;
                }
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

