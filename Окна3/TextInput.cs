using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Окна3 {
    internal class TextInput : View {
        public string type;
        public int text_length;
        public TextInput(int x, int y, int width, int height, int text_length, string type = "text") : base(x, y, width, height) {
            this.type = type;
            this.text_length = text_length;
        }
        public void Text(ref string text) {
            text = "";
            Console.CursorVisible = true;
            Console.SetCursorPosition(x, y);
            int i = 0;
            while (true) {
                int temp = width - text_length - 2;
                var s = Console.ReadKey();
                if (i < temp) {
                    if (s.Key == ConsoleKey.Enter) break;
                    else if (s.Key == ConsoleKey.Backspace) {
                        if (text.Length > 0) {
                            text = text.Remove(text.Length - 1);
                            i--;
                            Console.SetCursorPosition(x, y);
                            Console.Write(text);
                            for (int j = text.Length; j < temp; j++) {
                                Console.Write(" ");
                                Console.CursorLeft--;
                            }
                        }
                    } else {
                        text += s.KeyChar;
                        i++;
                    }
                } else {
                    if (s.Key == ConsoleKey.Enter) break;
                    else if (s.Key == ConsoleKey.Backspace) {
                        if (text.Length > 0) {
                            text = text.Remove(text.Length - 1);
                            i--;
                            Console.SetCursorPosition(x, y);
                            if (text.Length > temp) Console.Write(text.Substring(text.Length - temp - 1));
                            Console.CursorLeft--;
                        }
                    } else {
                        Console.SetCursorPosition(x, y);
                        Console.Write(text.Substring(text.Length - temp));
                        text += s.KeyChar;
                        i++;
                    }
                }
                if (Console.CursorLeft < x) Console.CursorLeft = x;
                Thread.Sleep(100);
            }
            Console.SetCursorPosition(x, y);
            Console.CursorVisible = false;
        }
        public void Password(ref string password) {
            password = "";
            int i = 0;
            Console.CursorVisible = true;
            Console.SetCursorPosition(x, y);
            while (true) {
                int temp = width - text_length - 2;
                var s = Console.ReadKey(true);
                if (i < temp) {
                    if (s.Key == ConsoleKey.Enter) break;
                    else if (s.Key == ConsoleKey.Backspace) {
                        if (password.Length > 0) {
                            password = password.Remove(password.Length - 1);
                            i--;
                            Console.SetCursorPosition(x, y);
                            foreach(char a in password) Console.Write("a");
                            for (int j = password.Length; j < temp; j++) {
                                Console.Write(" ");
                                Console.CursorLeft--;
                            }
                        }
                    }
                    else {
                        Console.Write("*");
                        password += s.KeyChar;
                        i++;
                    }
                }
                else {
                    if (s.Key == ConsoleKey.Enter) break;
                    else if (s.Key == ConsoleKey.Backspace) {
                        if (password.Length > 0) {
                            password = password.Remove(password.Length - 1);
                            i--;
                            Console.SetCursorPosition(x, y);
                            if (password.Length > temp) for (int l = 0; l <= password.Substring(password.Length - temp - 1).Length; l++) Console.Write("*");
                            Console.CursorLeft--;
                        }
                    }
                    else {
                        Console.SetCursorPosition(x, y);
                        for (int l = 0; l <= password.Substring(password.Length - temp).Length; l++) Console.Write("*");
                        password += s.KeyChar;
                        i++;
                        Console.CursorLeft--;
                    }
                }
                if (Console.CursorLeft < x) Console.CursorLeft = x;
                Thread.Sleep(100);
            }
            Console.SetCursorPosition(x, y);
            Console.CursorVisible = false;
        }
        public void Mail(ref string mail) {
            mail = "";
            Console.CursorVisible = true;
            Console.SetCursorPosition(x, y);
            int i = 0;
            while (true) {
                int temp = width - text_length - 2;
                var s = Console.ReadKey();
                if (i < temp) {
                    if (s.Key == ConsoleKey.Enter) break;
                    else if (s.Key == ConsoleKey.Backspace) {
                        if (mail.Length > 0) {
                            mail = mail.Remove(mail.Length - 1);
                            i--;
                            Console.SetCursorPosition(x, y);
                            Console.Write(mail);
                            for (int j = mail.Length; j < temp; j++) {
                                Console.Write(" ");
                                Console.CursorLeft--;
                            }
                        }
                    }
                    else {
                        mail += s.KeyChar;
                        i++;
                    }
                }
                else {
                    if (s.Key == ConsoleKey.Enter) break;
                    else if (s.Key == ConsoleKey.Backspace) {
                        if (mail.Length > 0) {
                            mail = mail.Remove(mail.Length - 1);
                            i--;
                            Console.SetCursorPosition(x, y);
                            if (mail.Length > temp) Console.Write(mail.Substring(mail.Length - temp - 1));
                            Console.CursorLeft--;
                        }
                    }
                    else {
                        Console.SetCursorPosition(x, y);
                        Console.Write(mail.Substring(mail.Length - temp));
                        mail += s.KeyChar;
                        i++;
                    }
                }
                if (Console.CursorLeft < x) Console.CursorLeft = x;
                Thread.Sleep(100);
            }
            Console.SetCursorPosition(x, y);
            Console.CursorVisible = false;
        }
        public void Phone(ref string phone) {
            phone = "";
            Console.CursorVisible = true;
            Console.SetCursorPosition(x, y);
            int i = 0;
            while (true) {
                int temp = width - text_length - 2;
                var s = Console.ReadKey();
                if (i < temp) {
                    if (s.Key == ConsoleKey.Enter) break;
                    else if (s.Key == ConsoleKey.Backspace) {
                        if (phone.Length > 0) {
                            phone = phone.Remove(phone.Length - 1);
                            i--;
                            Console.SetCursorPosition(x, y);
                            Console.Write(phone);
                            for (int j = phone.Length; j < temp; j++) {
                                Console.Write(" ");
                                Console.CursorLeft--;
                            }
                        }
                    }
                    else {
                        phone += s.KeyChar;
                        i++;
                    }
                }
                else {
                    if (s.Key == ConsoleKey.Enter) break;
                    else if (s.Key == ConsoleKey.Backspace) {
                        if (phone.Length > 0) {
                            phone = phone.Remove(phone.Length - 1);
                            i--;
                            Console.SetCursorPosition(x, y);
                            if (phone.Length > temp) Console.Write(phone.Substring(phone.Length - temp - 1));
                            Console.CursorLeft--;
                        }
                    }
                    else {
                        Console.SetCursorPosition(x, y);
                        Console.Write(phone.Substring(phone.Length - temp));
                        phone += s.KeyChar;
                        i++;
                    }
                }
                if (Console.CursorLeft < x) Console.CursorLeft = x;
                Thread.Sleep(100);
            }
            Console.SetCursorPosition(x, y);
            Console.CursorVisible = false;
        }
        public void Draw_text(string text) {
            Console.CursorVisible = false;
            Console.SetCursorPosition(x, y);
            if (text != "") {
                int temp = width - text_length - 1;
                if (text.Length > temp) {
                    for (int i = 0; i < temp; i++) {
                        Console.Write(text[i]);
                    }
                } else {
                    Console.Write(text);
                }
            }
            
        }

        public void Draw_password(string password) {
            Console.CursorVisible = false;
            Console.SetCursorPosition(x, y);
            if (password != "") {
                int temp = width - text_length - 1;
                if (password.Length > temp) {
                    for (int i = 0; i < temp; i++) {
                        Console.Write("*");
                    }
                }
                else {
                    foreach (char a in password) Console.Write("*");
                }
            }
        }

        public void Draw_mail(string mail) {
            Console.CursorVisible = false;
            string temp = "";
            if (mail.Length >= 9) {
                temp = mail.Substring(mail.Length - 8);

            }
            if (temp != "@mail.ru") {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.SetCursorPosition(x, y);
            if (mail != "") {
                int temp1 = width - text_length - 1;
                if (mail.Length > temp1) {
                    for (int i = 0; i < temp1; i++) {
                        Console.Write(mail[i]);
                    }
                }
                else {
                    Console.Write(mail);
                }
            }
            Console.ResetColor();

        }
        public void Draw_phone(string phone) {
            Console.CursorVisible = false;
            if (phone.Length != 11) {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (phone.Length > 0 && phone[0] != '8') {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            try {
                long a = Convert.ToInt64(phone);
            }
            catch (Exception) {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.SetCursorPosition(x, y);
            if (phone != "") {
                int temp = width - text_length - 1;
                if (phone.Length > temp) {
                    for (int i = 0; i < temp; i++) {
                        Console.Write(phone[i]);
                    }
                }
                else {
                    Console.Write(phone);
                }
            }
            Console.ResetColor();
        }

        public void Draw(string text, string password, string mail, string phone) {
            base.Draw();
            if (type == "text") {
                Draw_text(text);
            } else if (type == "password") {
                Draw_password(password);
            } else if (type == "mail") {
                Draw_mail(mail);
            } else if (type == "phone") {
                Draw_phone(phone);
            }
        }

        public void Move(ConsoleKeyInfo s, string text, string password, string mail, string phone) {
            base.Move(s);
            Draw(text, password, mail, phone);
        }

    }
}
