using SnakeGame.Game.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Game
{
    internal class GameEndScene : ISceneUpdate
    {
        private UIManager uim;
        private Option o;

        public void onStart()
        {
            uim = new UIManager();
            Vector2 titlePos = new Vector2(Game.Instance.width / 2, 2);
            uim.CreateTitle("startTitle", "贪吃蛇游戏", titlePos);
            Vector2 optionPos = new Vector2(Game.Instance.width / 2, 10);
            o = uim.CreateOption("startOptions", optionPos, 3, ConsoleColor.Red, ConsoleColor.White, "开始游戏", "退出游戏") as Option;
            o[0] += LoadGameScene;
            o[1] += QuitGame;
            uim.RefreshAll();
        }

        public void LoadGameScene()
        {
            Game.Instance.LoadScene(E_SceneType.Start);
        }

        public void QuitGame()
        {
            Environment.Exit(0);
        }

        public void Update()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    o?.SelectOption(1);
                    break;
                case ConsoleKey.S:
                    o?.SelectOption(-1);
                    break;
                case ConsoleKey.Enter:
                    o?.Invoke();
                    break;
            }
            uim.RefreshAll();
        }

        public void onEnd()
        {
            Console.Clear();
        }
    }
}
