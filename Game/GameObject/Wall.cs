
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Game.GameObject
{
    internal class Wall : GameObject
    {
        public Wall(int x, int y) {
            this.pos = new Vector2(x, y);            
        }

        public override void Render()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("■");
        }
    }
}
