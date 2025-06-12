using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Game
{
    internal interface ISceneUpdate
    {
        void onStart();
        void Update();
        void onEnd();

    }
}
