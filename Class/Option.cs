using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Class
{
    class Option : IUIComponent
    {
        private string[] Options;
        private Vector2 pos;
        private ConsoleColor selectColor, unselectColor;
        private int LineSpace;
        public int currIndex;

        public Option(string[] options, ConsoleColor selectColor, ConsoleColor unselectColor, Vector2 pos, int space )
        {
            Options = options;
            this.pos = pos;
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

        public void Refresh()
        {
            for(int i = 0; i < Options.Length; ++i)
            {              
                UITools.DrawText(Options[i], new Vector2(pos.x - Options[i].Length / 2, pos.y - LineSpace * i),
                    i == currIndex? selectColor : unselectColor);
            }
        }

        public void SelectOption(int dir)
        {
            currIndex = (currIndex + dir + Options.Length) % Options.Length;
            Refresh();
        }
    }
}
