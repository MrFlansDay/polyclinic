using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Окна3 {
    internal class Container : View {
        // public Button button;
        //private TextField textField;
        private Label label;
        public string FIO;
        public string mail;
        public string day;
        public List<View> items;
        public List<string> texts;
        public List<string> passwords;
        public List<string> mails;
        public List<string> phones;

        public Container(int x, int y, int width, int height, string title, string FIO = "", string mail = "", string day = "") : base(x, y, width, height) {

            //Action action = () => { Window_manager.List_Remove(Window_manager.active_window); };
            //button = new Button(width - 1, y + 1, 10, 3, action);


            //textField = new TextField(x + 1, y + 3, 50, 3, text);


            label = new Label(x + 1, y + 1, width, height, title);
            items = new List<View>() {/* button, textField*/};
            this.FIO = FIO;
            this.mail = mail;
            this.day = day;
        }

        public int iterator = 0;

        public void getData() {
            texts = new List<string>();
            passwords = new List<string>();
            mails = new List<string>();
            phones = new List<string>();

            foreach (var item in items) {
                if (item is TextField temp) {
                    if (temp.type == "text") {
                        texts.Add(temp.text);
                    } else if (temp.type == "password") {
                        passwords.Add(temp.password);
                    } else if (temp.type == "mail") {
                        mails.Add(temp.mail);
                    } else if (temp.type == "phone") {
                        phones.Add(temp.phone);
                    }
                }
            }
            try {
                mail = mails[0];
                FIO = SignIn.getName(mail);
            } catch {

            }
            /*try {
                FIO = texts[0];
            } catch {
                FIO = SignIn.getName(mail);
            }*/

        }

        public bool signIn(/*Action action, Action action2*/) {
            getData();
            try {
                 return SignIn.logIn(mails[0], passwords[0]);
            } catch {
                return false;
            }
            /*if (SignIn.logIn(mails[0], passwords[0])) {
                return action;
            } else {
                 return action2;
            }*/
        }
        public bool signUp(string Who) {
            getData();
            if (Who == "Doctor") {
                try {
                    FIO = texts[0];
                    mail = mails[0];
                    return SignUp.registry(texts[0], mails[0], passwords[0], passwords[1]);
                }
                catch {
                    return false;
                }
            }
            else if (Who == "Patients") {
                try {
                    return SignUpPatient.registry(texts[0], texts[1], texts[2]);
                }
                catch {
                    return false;
                }
            }
            else {
                try {
                    return UpdatePatient.registry(texts[0], texts[1], texts[2]);
                }
                catch {
                    return false;
                }

            }
        }
        private static readonly string _signUpConnectionString = ConfigurationManager.ConnectionStrings["Patients"].ConnectionString;
        private static SqlConnection sqlConnection = new SqlConnection(_signUpConnectionString);
        public void Delete(string day, string StartTime, string EndTime, string FIO) {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand($"DELETE FROM Patients WHERE DayOfTheWeek = '{day}' AND Doctor = '{Window_manager.active_window.container.mail}'" +
                $"AND StartTime = {StartTime} AND EndTime = {EndTime} AND FIO = {FIO}", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Pack(params View[] views) {
            for (int i = 0; i < views.Length; i++) {
                views[i].y += y;
                views[i].x += x;
                items.Add(views[i]);
                iterator++;
            }
            Draw();
        }
        public void Choose_field() {
            if (items[iterator % items.Count()] is TextField temp) {
                temp.Is_active = true;
                if (items[(iterator - 1) % items.Count()] is TextField temp1) {
                    temp1.Is_active = false;
                } else if (items[(iterator - 1) % items.Count()] is Button temp2) {
                    temp2.Is_active = false;
                }
                iterator++;
            }
            else if (items[iterator % items.Count()] is Button temp1) {
                temp1.Is_active = true;
                if (items[(iterator - 1) % items.Count()] is TextField temp2) {
                    temp2.Is_active = false;
                }
                else if (items[(iterator - 1) % items.Count()] is Button temp3) {
                    temp3.Is_active = false;
                }
                iterator++;
            }
            Draw();
        } 

        public void Press(bool is_new) {
            foreach (var item in items) {
                if (item is TextField temp) {
                    if (temp.Is_active) temp.Write(is_new);
                } else if (item is Button temp2) {
                    if (temp2.Is_active) temp2.Press();
                }

            }
        }


        public override void Draw() {
            base.Draw();
            label.Draw();
            foreach(View view in items) {
                if (view is TextField temp) {
                    temp.Draw();
                } else {
                    view.Draw();
                }
                
            }
        }

        public override void Move(ConsoleKeyInfo s) {
            base.Move(s);
            label.Move(s);
            foreach (View view in items) {
                if (view is TextField temp) {
                    temp.Move(s);
                }
                else {
                    view.Move(s);
                }

            }
            Draw();
        }
    }
}
