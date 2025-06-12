using SnakeGame.Game.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeGame.Game
{
    internal class GameScene : ISceneUpdate
    {
        private Wall[] walls;
        private int frame = 0;
        private Snake snake;
        private Food food;
        public void onStart()
        {
            snake = new Snake(40, 10);
            food = new Food(snake);

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
            foreach (var wall in walls)
            {
                wall.Render();
            }
        }

        public void Update()
        {
            if(frame % 4444 == 0)
            {
                food.Render();

                snake.Move();
                snake.Draw();

                //检测是否撞墙
                if (snake.CheckEnd(walls))
                {
                    //结束逻辑
                    Game.Instance.LoadScene(E_SceneType.End);
                }

                snake.CheckEatFood(food);

                frame = 0;
            }
            ++frame;

            if (Console.KeyAvailable)
            {
                //检测输入输出 不能再 间隔帧里面去处理 应该每次都检测 这样才准确
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        snake.ChangeDir(E_MoveDir.Up);
                        break;
                    case ConsoleKey.A:
                        snake.ChangeDir(E_MoveDir.Left);
                        break;
                    case ConsoleKey.S:
                        snake.ChangeDir(E_MoveDir.Down);
                        break;
                    case ConsoleKey.D:
                        snake.ChangeDir(E_MoveDir.Right);
                        break;
                }
            }
        }
        
        public void onEnd()
        {
            Console.Clear();
        }
    }
}
