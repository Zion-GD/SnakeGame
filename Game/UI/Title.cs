using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Game.UI
{
    internal class Title : IUIComponent
    {
        private string name;
        private string txt;
        private Vector2 pos;
        private ConsoleColor color;

        public string Name
        { get { return name; } }

        public Title(string name, string txt, Vector2 pos, ConsoleColor color = ConsoleColor.White)
        {
            this.name = name;
            this.txt = txt;
            this.pos = new Vector2(pos.x - txt.Length, pos.y);
            this.color = color;
        }

        public void Refresh()
        {
            UITools.DrawText(txt, pos, color);
        }
    }
}
