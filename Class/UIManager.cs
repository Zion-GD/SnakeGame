using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Class
{
    class UIManager
    {
        private static UIManager instance = new UIManager();
        public static UIManager Instance
        {
            get { return instance; }
        }
        private List<IUIComponent> components = new List<IUIComponent>();

        public event Action onRefresh;

        public void ComponentRegister(IUIComponent uic)
        {
            components.Add(uic);
            onRefresh += uic.Refresh;
        }

        public void RefreshAll()
        {
            onRefresh?.Invoke();
        }
    }
}
