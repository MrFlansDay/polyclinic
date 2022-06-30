using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Окна3 {
    internal class Window : View {
        private Header header = new Header();
        public Container container;

        public Window(int x, int y, int width, int height, string title, string FIO = "", string mail = "", string day = "") : base(x, y, width, height) {
            header = new Header();
            container = new Container(x, y, width, height, title, FIO, mail, day);
        }

        public bool signIn(/*Action action, Action action2*/) {
            return container.signIn(/*action, action2*/);
        }
        public bool signUp(string Who = "Doctor", string StartTime = "", string EndTime = "", string FIO = "", string StartTime2 = "", string EndTime2 = "", string FIO2 = "") {
            return container.signUp(Who, StartTime, EndTime, FIO, StartTime2, EndTime2, FIO2);
        }
        public void getData() {
            container.getData();
        }
        public void Pack(params View[] views) {
            container.Pack(views);
        }

        public void Choose_field() {
            container.Choose_field();
        }
        public void Press( bool is_new = false) {
            container.Press(is_new);
        }

        private void draw_window() {
            Drawer.Draw(x, y, width, height);
            header.Draw(x, y, width);
        }
        public override void Draw() {
            draw_window();
            container.Draw();
        }
        public override void Move(ConsoleKeyInfo s) {
            base.Move(s);
            container.Move(s);
            Draw();
        }
    }
}
