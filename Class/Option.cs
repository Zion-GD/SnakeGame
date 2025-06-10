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
        public string Name;
        public string[] Options;
        public Color selectColor, unselectColor;
        public int currIndex;

        public Option(string name, string[] options, Color selectColor, Color unselectColor, )
        {
            Name = name;
            Options = options;
            this.selectColor = selectColor;
            this.unselectColor = unselectColor;
        }

        public string this[int index]
        {
            get { return Options[index]; }
            set { Options[index] = value; }
        }

        public void DrawOption(Vector2 pos)
        {
            
        }
    }
}
