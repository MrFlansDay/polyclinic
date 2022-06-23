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
    internal class Program {
        static void Main(string[] args) {
            /*Window window = new Window(2, 2, 20, 10, "1", new Header());
            Window_manager.List_Add(window);
            Window window2 = new Window(2, 2, 15, 10, "2", new Header());
            Window_manager.List_Add(window2);
            Window window3 = new Window(2, 2, 15, 10, "3", new Header());
            Window_manager.List_Add(window3);*/
            Window w;
            w = Window_manager.active_window;
            /* Action action = () => { Window_manager.List_Remove(w); };
             Action action1 = () => { 
                 Window window1 = new Window(2, 2, 15, 10, "3", new Header());
                 Window_manager.List_Add(window1);
             };
             window.Pack(new Button(4, 4, 5, 5, action1), new Button(10, 3, 10, 5, action, "textaaa"));*/
            // SignUp.registry("sdfsdf", "ldd@mail.ru", "3333", "3333");

            Window SignIn = new Window(33, 2, 52, 20, "Authorization");
            Window_manager.List_Add(SignIn);



            Action FalseSignUp = () => {
                Window alert = new Window(Window_manager.active_window.x - 5, Window_manager.active_window.height + 1 + Window_manager.active_window.y,
                    62, 2, "The user is already registered or the data is incorrect!");
                Window_manager.List_Add(alert);
                Window_manager.Draw_windows();
                Console.ReadKey(true);
                Window_manager.List_Remove(alert);
            };
            Action CloseWindow = () => {
                Window_manager.List_Remove(Window_manager.active_window);
            };
            Action Void = () => { };
            Action TryNewPatient = () => {
                if (Window_manager.active_window.signUp("Patients")) {
                    Void();
                    CloseWindow();
                }
                else FalseSignUp();
                Window_manager.Draw_windows();

            };
            Action SignUpPatientWindow = () => {
                Window signUpPatientWindow = new Window(33, 2, 52, 20, "Registration", Window_manager.active_window.container.FIO, Window_manager.active_window.container.mail, Window_manager.active_window.container.day);
                Window_manager.List_Remove(Window_manager.active_window);
                Window_manager.List_Add(signUpPatientWindow);
                signUpPatientWindow.Pack(new TextField(2, 4, 50, 2, "FIO: ", "text"),
                    new TextField(2, 7, 50, 2, "Start Time: ", "text"), new TextField(2, 10, 50, 2, "End Time: ", "text"),
                    new Button(0, 13, 50, 2, TryNewPatient, "OK"));
            };
            
            
            Action Monday = () => {
                Window monday = new Window(33, 2, 52, 29, "Timetable for the day", Window_manager.active_window.container.FIO, Window_manager.active_window.container.mail, "Monday");
                Window_manager.List_Add(monday);
                monday.Pack(new TextField(2, 4, 50, 2, "Timetable on Monday"));

                int newY = TimeAndSurname("Monday", CloseWindow);
                monday.Pack(new Button(0, 7 + newY, 15, 2, SignUpPatientWindow, "Add"), new Button(0, 10 + newY, 15, 2, CloseWindow, "Go back"));
            };
            Action Tuesday = () => {
                Window tuesday = new Window(33, 2, 52, 29, "Timetable for the day", Window_manager.active_window.container.FIO, Window_manager.active_window.container.mail, "Tuesday");
                Window_manager.List_Add(tuesday);
                tuesday.Pack(new TextField(2, 4, 50, 2, "Timetable on Tuesday"));
                int newY = TimeAndSurname("Tuesday", CloseWindow);
                tuesday.Pack(new Button(0, 7 + newY, 15, 2, SignUpPatientWindow, "Add"), new Button(0, 10 + newY, 15, 2, CloseWindow, "Go back"));
            };
            Action Wednesday = () => {
                Window wednesday = new Window(33, 2, 52, 29, "Timetable for the day", Window_manager.active_window.container.FIO, Window_manager.active_window.container.mail, "Wednesday");
                Window_manager.List_Add(wednesday);
                wednesday.Pack(new TextField(2, 4, 50, 2, "Timetable on Wednesday"));
                int newY = TimeAndSurname("Wednesday", CloseWindow);
                wednesday.Pack(new Button(0, 7 + newY, 15, 2, SignUpPatientWindow, "Add"), new Button(0, 10 + newY, 15, 2, CloseWindow, "Go back"));
            };
            Action Thursday = () => {
                Window thursday = new Window(33, 2, 52, 29, "Timetable for the day", Window_manager.active_window.container.FIO, Window_manager.active_window.container.mail, "Thursday");
                Window_manager.List_Add(thursday);
                thursday.Pack(new TextField(2, 4, 50, 2, "Timetable on Thursday"));
                int newY = TimeAndSurname("Thursday", CloseWindow);
                thursday.Pack(new Button(0, 7 + newY, 15, 2, SignUpPatientWindow, "Add"), new Button(0, 10 + newY, 15, 2, CloseWindow, "Go back"));
            };
            Action Friday = () => {
                Window friday = new Window(33, 2, 52, 29, "Timetable for the day", Window_manager.active_window.container.FIO, Window_manager.active_window.container.mail, "Friday");
                Window_manager.List_Add(friday);
                friday.Pack(new TextField(2, 4, 50, 2, "Timetable on Friday"));
                int newY = TimeAndSurname("Friday", CloseWindow);
                friday.Pack(new Button(0, 7 + newY, 15, 2, SignUpPatientWindow, "Add"), new Button(0, 10 + newY, 15, 2, CloseWindow, "Go back"));
            };
            Action Saturday = () => {
                Window saturday = new Window(33, 2, 52, 29, "Timetable for the day", Window_manager.active_window.container.FIO, Window_manager.active_window.container.mail, "Saturday");
                Window_manager.List_Add(saturday);
                saturday.Pack(new TextField(2, 4, 50, 2, "Timetable on Saturday"));
                int newY = TimeAndSurname("Saturday", CloseWindow);
                saturday.Pack(new Button(0, 7 + newY, 15, 2, SignUpPatientWindow, "Add"), new Button(0, 10 + newY, 15, 2, CloseWindow, "Go back"));
            };
            Action Sunday = () => {
                Window sunday = new Window(33, 2, 52, 29, "Timetable for the day", Window_manager.active_window.container.FIO, Window_manager.active_window.container.mail, "Sunday");
                Window_manager.List_Add(sunday);
                sunday.Pack(new TextField(2, 4, 50, 2, "Timetable on Sunday"));
                int newY = TimeAndSurname("Sunday", CloseWindow);
                sunday.Pack(new Button(0, 7 + newY, 15, 2, SignUpPatientWindow, "Add"), new Button(0, 10 + newY, 15, 2, CloseWindow, "Go back"));
            };
            Action Close = () => {
                Environment.Exit(0);
            };
            Action TimetableWeek = () => {
                Window timetableWeek = new Window(33, 2, 52, 30, "Timetable on the week", Window_manager.active_window.container.FIO, Window_manager.active_window.container.mail);
                Window_manager.List_Add(timetableWeek);
                Window_manager.List_Remove(Window_manager.windows[0]);
                timetableWeek.Pack(new TextField(2, 4, 50, 2, "Timetable on the week"),
                    new TextField(2, 7, 24, 2, $"Monday - {NumberOfPatient("Monday")}"), new Button(26, 7, 24, 2, Monday, "Open"),
                    new TextField(2, 10, 24, 2, $"Tuesday - {NumberOfPatient("Tuesday")}"), new Button(26, 10, 24, 2, Tuesday, "Open"),
                    new TextField(2, 13, 24, 2, $"Wednesday - {NumberOfPatient("Wednesday")}"), new Button(26, 13, 24, 2, Wednesday, "Open"),
                    new TextField(2, 16, 24, 2, $"Thursday - {NumberOfPatient("Thursday")}"), new Button(26, 16, 24, 2, Thursday, "Open"),
                    new TextField(2, 19, 24, 2, $"Friday - {NumberOfPatient("Friday")}"), new Button(26, 19, 24, 2, Friday, "Open"),
                    new TextField(2, 22, 24, 2, $"Saturday - {NumberOfPatient("Saturday")}"), new Button(26, 22, 24, 2, Saturday, "Open"),
                    new TextField(2, 25, 24, 2, $"Sunday - {NumberOfPatient("Sunday")}"), new Button(26, 25, 24, 2, Sunday, "Open"),
                    new Button(0, 28, 50, 2, Close, "Exit"));
            };

            Action WelcomeWindow = () => {
                Window welcomeWindow = new Window(33, 2, 52, 15, "Hello window", Window_manager.active_window.container.FIO, Window_manager.active_window.container.mail);
                Window_manager.List_Add(welcomeWindow);
                Window_manager.List_Remove(Window_manager.windows[0]);
                welcomeWindow.Pack(new TextField(2, 4, 50, 2, $"Hello, {welcomeWindow.container.FIO}"), new Button(0, 7, 50, 2, Close, "Exit"), new Button(0, 10, 50, 2, TimetableWeek, "Timetable"));
            };
            Action FalseSignIn = () => {
                Window alert = new Window(SignIn.x + 10, SignIn.height + 1 + SignIn.y, 30, 2, "The data is incorrect!");
                Window_manager.List_Add(alert);
                Window_manager.Draw_windows();
                Console.ReadKey(true);
                Window_manager.List_Remove(alert);
            };
            Action TrySignIn = () => {
                if (SignIn.signIn()) WelcomeWindow();
                else FalseSignIn();
                Window_manager.Draw_windows();
            };

            Action TrySignUp = () => {
                if (Window_manager.active_window.signUp()) WelcomeWindow();
                else FalseSignUp();
                Window_manager.Draw_windows();
            };

            Action SignUpWindow = () => {
                Window signUpWindow = new Window(33, 2, 52, 20, "Registration");
                Window_manager.List_Add(signUpWindow);
                Window_manager.List_Remove(SignIn);
                signUpWindow.Pack(new TextField(2, 4, 50, 2, "FIO: ", "text"), new TextField(2, 7, 50, 2, "E-mail: ", "mail"),
                    new TextField(2, 10, 50, 2, "Password: ", "password"), new TextField(2, 13, 50, 2, "Confirm password: ", "password"),
                    new Button(0, 16, 50, 2, TrySignUp, "OK"));
            };

            SignIn.Pack(new TextField(2, 4, 50, 2, "E-mail: ", "mail"), new TextField(2, 7, 50, 2, "Password: ", "password"),
                new Button(0, 10, 50, 2, TrySignIn, "Sign In"), new Button(0, 13, 50, 2, SignUpWindow, "Sign Up"));


            while (true) {

                Window_manager.Draw_windows();
                Window_manager.Start();
            }

        }
        private static readonly string _signUpConnectionString = ConfigurationManager.ConnectionStrings["Patients"].ConnectionString;
        private static SqlConnection sqlConnection = new SqlConnection(_signUpConnectionString);
        private static string NumberOfPatient(string day) {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand($"SELECT COUNT(Id) FROM Patients WHERE DayOfTheWeek = '{day}' AND Doctor = '{Window_manager.active_window.container.mail}'", sqlConnection);
            string getValue = "0";
            try {
                getValue = sqlCommand.ExecuteScalar().ToString();
            }
            catch {

            }
            sqlConnection.Close();
            return getValue;

        }
        static Action Close = () => {
            Environment.Exit(0);
        };
        /*static Action Delete = () => {
            sqlConnection.Open();


            SqlCommand sqlCommand = new SqlCommand($"DELETE FROM Patients WHERE DayOfTheWeek = '{Window_manager.active_window.container.day}' " +
                $"AND Doctor = '{Window_manager.active_window.container.mail}'" +
                $"AND StartTime = {StartTime} AND EndTime = {EndTime}", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        };*/
        private static int TimeAndSurname(string day, Action CloseWindow) {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand($"SELECT StartTime, EndTime, FIO FROM Patients WHERE DayOfTheWeek = '{day}' AND Doctor = '{Window_manager.active_window.container.mail}'", sqlConnection);
            /*SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dt);*/
            SqlDataReader reader = sqlCommand.ExecuteReader();
            int newY = 0;
            while (reader.Read()) {
                string StartTime = (string)reader[0];
                string EndTime = (string)reader[1];
                string Surname = GetSurname((string)reader[2]);

                Action Del = GetDelAction(StartTime, CloseWindow, day);
                Button button = new Button(35, 7 + newY, 5, 2, Del);

                Action FalseUp = () => {
                    Window alert = new Window(Window_manager.active_window.x - 5, Window_manager.active_window.height + 1 + Window_manager.active_window.y,
                        62, 2, "The user is already registered or the data is incorrect!");
                    Window_manager.List_Add(alert);
                    Window_manager.Draw_windows();
                    Console.ReadKey(true);
                    Window_manager.List_Remove(alert);
                };

                Action TryUpdate = () => {
                    if (Window_manager.active_window.signUp("Update")) {
                        CloseWindow();
                    }
                    else FalseUp();
                    Window_manager.Draw_windows();
                };
                Action UpPatientWindow = () => {
                    Window upPatientWindow = new Window(33, 2, 52, 20, "Registration", Window_manager.active_window.container.FIO, Window_manager.active_window.container.mail, Window_manager.active_window.container.day);
                    Window_manager.List_Remove(Window_manager.active_window);
                    Window_manager.List_Add(upPatientWindow);
                    upPatientWindow.Pack(new TextField(2, 4, 50, 2, "FIO: ", "text"),
                        new TextField(2, 7, 50, 2, "Start Time: ", "text"), new TextField(2, 10, 50, 2, "End Time: ", "text"),
                        new Button(0, 13, 50, 2, TryUpdate, "OK"));
                };

                Window_manager.active_window.Pack(
                    new TextField(2, 7 + newY, 33, 2, $"{StartTime[0].ToString() + StartTime[1] + ":" + StartTime[2] + StartTime[3]} - {EndTime[0].ToString() + EndTime[1] + ":" + EndTime[2] + EndTime[3]}" +
                    $" - {Surname}"), button, new Button(42, 7 + newY, 8, 2, UpPatientWindow, "Edit"));
                newY += 3;
                if (newY + 7 >= Window_manager.active_window.height) {
                    Window_manager.active_window.height += 3;
                }
            }
            if (newY == 0) {
                Window_manager.active_window.Pack(new TextField(2, 7, 33, 2, "Patient list is empty"));
                newY += 3;
            }
            reader.Close();
            sqlConnection.Close();
            return newY;

        }
        private static string GetSurname(string FIO) {
            try {
                return FIO.Split(' ')[1];
            }
            catch {
                return FIO.Split(' ')[0];
            }
        }

        private static Action GetDelAction(string StartTime, Action CloseWindow, string day) {
            Action action = () => {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"DELETE FROM Patients WHERE DayOfTheWeek = '{Window_manager.active_window.container.day}' " +
                    $"AND Doctor = '{Window_manager.active_window.container.mail}'" +
                    $"AND StartTime = '{StartTime}'", sqlConnection);
                int x = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                CloseWindow();

                Action NewPatient = () => {

                };

                Action action2 = () => {
                    Window monday = new Window(33, 2, 52, 29, "Timetable for the day", Window_manager.active_window.container.FIO, Window_manager.active_window.container.mail, "Monday");
                    Window_manager.List_Add(monday);
                    monday.Pack(new TextField(2, 4, 50, 2, $"Timetable on {day}"));

                    int newY = TimeAndSurname(day, CloseWindow);
                    monday.Pack(new Button(0, 7 + newY, 15, 2, NewPatient, "Add"), new Button(0, 10 + newY, 15, 2, CloseWindow, "Go back"));
                };
                action2();

                Window_manager.Draw_windows();
            };
            return action;
        }

        private static Action GetUpAction(string StartTime, Action CloseWindow, string day) {
            Action action = () => {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"DELETE FROM Patients WHERE DayOfTheWeek = '{Window_manager.active_window.container.day}' " +
                    $"AND Doctor = '{Window_manager.active_window.container.mail}'" +
                    $"AND StartTime = '{StartTime}'", sqlConnection);
                int x = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                CloseWindow();

                Action NewPatient = () => {

                };

                Action action2 = () => {
                    Window monday = new Window(33, 2, 52, 29, "Timetable for the day", Window_manager.active_window.container.FIO, Window_manager.active_window.container.mail, "Monday");
                    Window_manager.List_Add(monday);
                    monday.Pack(new TextField(2, 4, 50, 2, $"Timetable on {day}"));

                    int newY = TimeAndSurname(day, CloseWindow);
                    monday.Pack(new Button(0, 7 + newY, 15, 2, NewPatient, "Add"), new Button(0, 10 + newY, 15, 2, CloseWindow, "Go back"));
                };
                action2();

                Window_manager.Draw_windows();
            };
            return action;
        }

        /*private static Action TryNewPatient(Action CloseWindow) {

        }*/

    }
}
