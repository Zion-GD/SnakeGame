using SnakeGame.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Game.UI
{
    public static class UITools
    {
        public static void DrawText(string txt, Vector2 pos, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(pos.x, pos.y);
            Console.WriteLine(txt);
        }
    }
}
