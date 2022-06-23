using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Окна3 {
    internal static class Drawer {
        public static void horizontal(int x, int y, int width) {
            for (int i = 0; i < width; i++) {
                Console.SetCursorPosition(x + i, y);
                Console.WriteLine("-");
            }
        }
        public static void vertical(int x, int y, int height) {
            for (int i = 0; i < height; i++) {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine("|");
            }
        }
        public static void point(int x, int y, string b) {
            Console.SetCursorPosition(x, y);
            Console.Write(b);
        }
        public static void Draw(int x, int y, int width, int height, bool highlight = false) {
            for (int i = x; i < width + x; i++) {
                for (int j = y; j < height + y; j++) {
                    point(i, j, " ");
                }
            }
            if (highlight) Console.ForegroundColor = ConsoleColor.Green;
            horizontal(x, y, width);
            vertical(x, y, height + 1);
            vertical(x + width, y, height + 1);
            horizontal(x + 1, y + height, width - 1);
            point(x, y, "+");
            point(x + width, y, "+");
            point(x, y + height, "+");
            point(x + width, y + height, "+");
            if (highlight) Console.ResetColor();
        }
        public static void clear() {
            Console.Clear();
        }
    }
}
