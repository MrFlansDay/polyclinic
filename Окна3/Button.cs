using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Окна3 {
    internal class Button : View {
        public Label label;
        Action action;
        public Button(int x, int y, int width, int height, Action action, string text = "X") : base(x, y, width, height) {
            label = new Label(x+2, y, width, height, text);
            this.action = action;
        }

        public bool Is_active = false;


        public void Press() {
            action();
            Window_manager.Draw_windows();
        }
        

        public override void Draw() {
            base.Draw();
            Drawer.Draw(x + 1, y - 1, width, height, Is_active);
            label.x = x+2;
            label.y = y;
            label.Draw();
        }
        public override void Move(ConsoleKeyInfo s) {
            base.Move(s);
            Draw();
        }
    }
}
