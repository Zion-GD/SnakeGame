using SnakeGame.Game.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Game
{
    internal class GameScene : ISceneUpdate
    {
        private Wall[] walls;
        public void onStart()
        {
            walls = new Wall[Game.Instance.width + (Game.Instance.height - 3) * 2];
            int index = 0;
            for (int i = 0; i < Game.Instance.width; i += 2)
            {
                walls[index] = new Wall(i, 0);
                ++index;
            }

            for (int i = 0; i < Game.Instance.width; i += 2)
            {
                walls[index] = new Wall(i, Game.Instance.height - 2);
                ++index;
            }

            for (int i = 1; i < Game.Instance.height - 2; i++)
            {
                walls[index] = new Wall(0, i);
                ++index;
            }

            for (int i = 1; i < Game.Instance.height - 2; i++)
            {
                walls[index] = new Wall(Game.Instance.width - 2, i);
                ++index;
            }
        }

        public void Update()
        {
            foreach(var wall in walls)
            {
                wall.Render();
            }
        }
        
        public void onEnd()
        {
            Console.Clear();
        }
    }
}
