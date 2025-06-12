
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Game.GameObject
{
    abstract class GameObject
    {
        public Vector2 pos;
        public abstract void Render();
    }
}
