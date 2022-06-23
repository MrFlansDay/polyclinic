using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Окна3 {
    internal class Window_manager {
        public static List<Window> windows = new List<Window>();
        public static Window active_window;
        public static string active_person;
        private static int count = -1;

        public static void List_Add(Window window) {
            windows.Add(window);
            active_window = window;
            count++;
        }
        public static void List_Remove(Window window) {
            if (windows.Count > 0) {
                windows.Remove(window);
                active_window = windows[0];
            }
        }
        public static void Start() {
            ConsoleKeyInfo s = Console.ReadKey(true);

            if (Is_move(s)) {
                active_window.Move(s);
                active_window.Draw();
            }
            else if ((s.Modifiers & ConsoleModifiers.Shift) == ConsoleModifiers.Shift && s.Key == ConsoleKey.Tab) {
                count++;
                active_window = windows[count % (windows.Count)];
            }


            else if (s.Key == ConsoleKey.Tab) {
                while (true) {
                    s = Console.ReadKey(true);
                    if (s.Key == ConsoleKey.Tab) {
                        active_window.Choose_field();
                    }
                    else if (s.Key == ConsoleKey.Enter) {
                        active_window.Press();
                    }
                    else {
                        break;
                    }

                }
            }
        }
        public static void Draw_windows() {
            Console.Clear();
            for (int i = 0; i < windows.Count; i++) {
                windows[i].Draw();
            }
            active_window.Draw();
        }
        
        private static bool Is_move(ConsoleKeyInfo s) {
            if (s.Key == ConsoleKey.LeftArrow || s.Key == ConsoleKey.RightArrow || s.Key == ConsoleKey.UpArrow
               || s.Key == ConsoleKey.DownArrow) {
                return true;
            }
            else {
                return false;
            }
        }
        
    }
}
