using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Game
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
        private bool isLoading = false;

        public void Init()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            LoadScene(E_SceneType.Start);
            GameLoop();
        }

        public void GameLoop()
        {
            while (!isLoading)
            {
                if (currScene != null)
                {
                    currScene.Update();
                }
            }
        }

        
        public void LoadScene(E_SceneType scene)
        {
            isLoading = true;
            currScene?.onEnd();
            switch (scene)
            {
                case E_SceneType.Start:
                    currScene = new GameStartScene();
                    break;
                case E_SceneType.Game:
                    currScene = new GameScene();
                    break;
                case E_SceneType.End:
                    currScene = new GameEndScene();
                    break;
            }
            currScene?.onStart();
            isLoading = false;
            GameLoop();
        }
    }
}
