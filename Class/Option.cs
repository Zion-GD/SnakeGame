using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Class
{
    class Option
    {
        private string[] Options;
        private ConsoleColor selectColor, unselectColor;
        private int LineSpace;
        public int currIndex;

        public Option(string[] options, ConsoleColor selectColor, ConsoleColor unselectColor, int space )
        {
            Options = options;
            this.selectColor = selectColor;
            this.unselectColor = unselectColor;
            this.LineSpace = space;
            currIndex = 0;
        }

        public string this[int index]
        {
            get { return Options[index]; }
            set { Options[index] = value; }
        }

        public void DrawOption(Vector2 pos)
        {
            for(int i = 0; i < Options.Length; ++i)
            {
                //Set option color
                if(i == currIndex) Console.ForegroundColor = selectColor;
                else Console.ForegroundColor = unselectColor;
                
                Console.SetCursorPosition(pos.x - Options[i].Length / 2, pos.y - LineSpace * i);
                Console.WriteLine(Options[i]);
            }
        }

        public void SelectOption(int dir)
        {
            currIndex = (currIndex + dir + Options.Length) % Options.Length;
            
        }
    }
}
