using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Class
{
    public struct Vector2
    {
        public int x;
        public int y;
        public int this[int index]
        {
            get { return index switch { 0 => x, 1 => y, _ => throw new IndexOutOfRangeException("Invalid Vector2 index!"), }; }
            set { 
                    switch(index)
                    {
                    case 0: x = value; break; 
                    case 1: y = value; break;
                    default: throw new IndexOutOfRangeException("Invalid Vector2 index!");
                    }
                }
        }

        public Vector2 (int x, int y)
        {
            this.x = x;
            this.y = y;
        }        
    }
}
