using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Окна3 {
    internal class TextField : View {
        public TextInput textInput;
        public Label label;
        public string label_text;
        public string type;
        public bool Is_active = false;
        public string text = "";
        public string password = "";
        public string mail = "";
        public string phone = "";

        public TextField(int x, int y, int width, int height, string label_text, string type = "text") : base(x, y, width, height) {
            textInput = new TextInput(x, y, width, height, label_text.Count());
            textInput.type = type;
            this.type = type;
            label = new Label(x, y, width, height, label_text);
            this.label_text = label_text;
        }

        public void Write(bool is_new) {
            textInput.x = x + label_text.Length;
            textInput.y = y;
            if (type == "text") {
                textInput.Text(ref text);

                

                textInput.Draw_text(text);
                Draw();
            } else if (type == "password") {
                textInput.Password(ref password);
                textInput.Draw_password(password);
            } else if (type == "mail") {
                textInput.Mail(ref mail);
                textInput.Draw_mail(mail);
            } else if (type == "phone") {
                textInput.Phone(ref phone);
                textInput.Draw_phone(phone);
            }
            
        }
        public override void Draw() {
            base.Draw();
            Drawer.Draw(x - 1, y - 1, width, height, Is_active);
            label.x = x;
            label.y = y;
            label.Draw();
            textInput.x = x + label_text.Length;
            textInput.y = y;
            textInput.Draw(text, password, mail, phone);
        }

        public override void Move(ConsoleKeyInfo s) {
            base.Move(s);
            label.Move(s);
            textInput.Move(s, text, password, mail, phone);
            Draw();
        }

    }
}
