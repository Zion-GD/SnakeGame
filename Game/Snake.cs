using System;
using System.Collections.Generic;
using System.Text;
using SnakeGame.Game.GameObject;

namespace SnakeGame.Game
{
    enum E_MoveDir
    {
        Up,
        Down,
        Left,
        Right,
    }

    class Snake
    {
        SnakeBody[] bodys;
        int Length;
        E_MoveDir dir;

        public Snake(int x, int y)
        {
            bodys = new SnakeBody[200];

            bodys[0] = new SnakeBody(E_SnakeBody_Type.Head, x, y);
            Length = 1;

            dir = E_MoveDir.Right;
        }

        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                bodys[i].Render();
            }
        }

        public void Move()
        {
            SnakeBody lastBody = bodys[Length - 1];
            Console.SetCursorPosition(lastBody.pos.x, lastBody.pos.y);
            Console.Write("  ");
            //身体移动更新
            for (int i = Length - 1; i > 0; i--)
            {
                bodys[i].pos = bodys[i - 1].pos;
            }

            switch (dir)
            {
                case E_MoveDir.Up:
                    --bodys[0].pos.y;
                    break;
                case E_MoveDir.Down:
                    ++bodys[0].pos.y;
                    break;
                case E_MoveDir.Left:
                    bodys[0].pos.x -= 2;
                    break;
                case E_MoveDir.Right:
                    bodys[0].pos.x += 2;
                    break;
            }
        }

        public void ChangeDir(E_MoveDir dir)
        {
            if( dir == this.dir ||
                Length > 1 && 
                (this.dir == E_MoveDir.Left && dir == E_MoveDir.Right ||
                 this.dir == E_MoveDir.Right && dir == E_MoveDir.Left ||
                 this.dir == E_MoveDir.Up && dir == E_MoveDir.Down ||
                 this.dir == E_MoveDir.Down && dir == E_MoveDir.Up))
            {
                return;
            }
            this.dir = dir;
        }

        public bool CheckEnd(Wall[] walls)
        {
            //是否和墙体位置重合
            for (int i = 0; i < walls.Length; i++)
            {
                if( bodys[0].pos == walls[i].pos )
                {
                    return true;
                }
            }

            for (int i = 1; i < Length; i++)
            {
                if(bodys[0].pos == bodys[i].pos)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckSamePos(Vector2 p)
        {
            for (int i = 0; i < Length; i++)
            {
                if(bodys[i].pos == p)
                {
                    return true;
                }
            }
            return false;
        }

        public void CheckEatFood(Food food)
        {
            if( bodys[0].pos == food.pos )
            {
                food.RandomPos(this);
                AddBody();
            }
        }

        private void AddBody()
        {
            SnakeBody frontBody = bodys[Length - 1];
            bodys[Length] = new SnakeBody(E_SnakeBody_Type.Body, frontBody.pos.x, frontBody.pos.y);
            ++Length;
        }
    }
}
