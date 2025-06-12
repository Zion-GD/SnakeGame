using SnakeGame.Game.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Game
{
    class UIManager
    {
        private Dictionary<string, IUIComponent> components;

        public event Action onRefresh;

        public UIManager()
        {
            components = new Dictionary<string, IUIComponent>();
            onRefresh = delegate {};
        }

        private void ComponentRegister(IUIComponent uic)
        {
            components.Add(uic.Name, uic);
            onRefresh += uic.Refresh;
        }

        private void ComponentCancel(IUIComponent uic)
        {
            components.Remove(uic.Name);
            onRefresh -= uic.Refresh;
        }

        public void Clear()
        {
            components.Clear();
            onRefresh = delegate {};
        }

        public IUIComponent GetUIComponent(string name)
        {
            if (components.ContainsKey(name))
                return components[name];
            return null;
        }

        public void RefreshAll()
        {
            Console.Clear();
            onRefresh?.Invoke();
        }

        public IUIComponent CreateOption(string name, Vector2 pos, int space, ConsoleColor selectColor = ConsoleColor.Red, ConsoleColor unselectColor = ConsoleColor.White, params string[] options)
        {
            IUIComponent option = new Option(name, options, selectColor, unselectColor, pos, space);
            ComponentRegister(option);
            return option;
        }

        public IUIComponent CreateTitle(string name, string txt, Vector2 pos, ConsoleColor color = ConsoleColor.White)
        {
            IUIComponent title = new Title(name, txt, pos, color);
            ComponentRegister(title);
            return title;
        }
    }
}
