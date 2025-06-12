using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Game.GameObject
{
    internal class Food : GameObject
    {
        public Food()
        {
            RandomPos();
        }

        public override void Render()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("✦");
        }

        private void RandomPos()
        {
            Random r = new Random();
            int x = r.Next(2, Game.Instance.width / 2) * 2;
            int y = r.Next(1, Game.Instance.height - 4);
            pos = new Vector2(x, y);

            if (false)
                RandomPos();
        }

    }
}
