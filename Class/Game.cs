using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Class
{
    enum E_SceneType
    {
        Start,
        Game,
        End,
    }
    internal class Game
    {
        private static Game instance;

        public static Game Instance
        {
            get { 
                if (instance == null) instance = new Game(); 
                return instance; 
            }
        }

        public int width = 80;
        public int height = 20;

        public ISceneUpdate currScene;

        public void Init()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            GameLoop();
        }

        public void GameLoop()
        {
            while (true)
            {
                if (currScene != null)
                {
                    currScene.Update();
                }
            }
        }

        
        public void LoadScene(E_SceneType scene)
        {
            currScene.onEnd();
            switch (scene)
            {
                case E_SceneType.Start:
                    Console.WriteLine("start");
                    break;
                case E_SceneType.Game:
                    break;
                case E_SceneType.End:
                    break;
            }
            currScene.onStart();
        }
    }
}
