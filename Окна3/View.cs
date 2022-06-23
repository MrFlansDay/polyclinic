using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Окна3 {
    internal abstract class View {
        public int x, y, width, height;
        public View(int x, int y, int width, int height) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        public virtual void Draw() {

        }
        public virtual void Move(ConsoleKeyInfo s) {
            if ((s.Key == ConsoleKey.LeftArrow) && (x > 1)) {
                x--;
            }
            else if ((s.Key == ConsoleKey.RightArrow) && (x < 119)) {
                x++;
            }
            else if ((s.Key == ConsoleKey.UpArrow) && (y > 1)) {
                y--;
            }
            else if (s.Key == ConsoleKey.DownArrow && (y < 119)) {
                y++;
            }
        }
    }
}
