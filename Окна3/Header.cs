using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Окна3 {
    internal class Header {
        public Header() {
        }
        public void Draw(int x, int y, int width) {
            Drawer.horizontal(x + 1, y + 2, width - 1);
            Drawer.point(x + width - 2, y + 1, "|");
            Drawer.point(x + width - 1, y + 1, "X");
            Drawer.point(x + width - 4, y + 1, "|");
            Drawer.point(x + width - 3, y + 1, "-");
        }
    }
}
