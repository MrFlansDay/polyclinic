using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Окна3 {
    internal class Label : View {
        private string text;
        int text_length;
        public Label(int x, int y, int width, int height, string text) : base(x, y, width, height) {
            this.text = text;
            text_length = text.Count();
        }

        public override void Draw() {
            base.Draw();
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            int i = 0;
            
            while (i < width - 4) {
                if (text == "") break;
                if (text_length < width - 4) {
                    Console.WriteLine(text);
                    break;
                }
                Console.Write(text[i]);
                i++;
                if (i == width - 4 && i != text_length) {
                    Console.Write("...");
                    break;
                }

            }
            Console.ResetColor();
        }
        public override void Move(ConsoleKeyInfo s) {
            base.Move(s);
            Draw();
        }


    }
}
