﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Game.GameObject
{
    enum E_SnakeBody_Type
    {
        Head,
        Body,
    }
    internal class SnakeBody : GameObject
    {
        private E_SnakeBody_Type type;

        public SnakeBody(E_SnakeBody_Type type, int x, int y)
        {
            this.type = type;
            this.pos = new Vector2(x, y);
        }
        public override void Render()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = type == E_SnakeBody_Type.Head ? ConsoleColor.Yellow : ConsoleColor.Green;
            Console.Write(type == E_SnakeBody_Type.Head ? "●" : "◎");
        }
    }
}
