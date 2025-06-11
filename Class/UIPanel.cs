using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Class
{
    abstract class UIPanel
    {
        public abstract void Refresh();
        public virtual void DrawTitle()
        {
            UITools.DrawText("Test", new Vector2(0,0), ConsoleColor.White);
        }
    }
}
