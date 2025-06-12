using SnakeGame.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Game.UI
{
    class Option : IUIComponent
    {
        private string name;
        private string[] Options;
        private Vector2 pos;
        private ConsoleColor selectColor, unselectColor;
        private int LineSpace;
        public int currIndex;
        public List<Action> actions;

        public string Name
            { get { return name; } }

        public Option(string name, string[] options, ConsoleColor selectColor, ConsoleColor unselectColor, Vector2 pos, int space )
        {
            this.name = name;   
            Options = options;
            this.pos = pos;
            this.selectColor = selectColor;
            this.unselectColor = unselectColor;
            LineSpace = space;
            currIndex = 0;
            actions = new List<Action>();
            for(int i = 0; i<options.Length; ++i)
            {
                actions.Add(delegate {});
            }
        }

        public Action this[int index]
        {
            get { return actions[index]; }
            set { actions[index] += value; }
        }

        public void Refresh()
        {
            for(int i = 0; i < Options.Length; ++i)
            {              
                UITools.DrawText(Options[i], new Vector2(pos.x - Options[i].Length, pos.y + LineSpace * i),
                    i == currIndex? selectColor : unselectColor);
            }
        }

        public void SelectOption(int dir)
        {
            currIndex = (currIndex + dir + Options.Length) % Options.Length;
        }

        public void Invoke()
        {
            actions[currIndex].Invoke();
        }
    }
}
