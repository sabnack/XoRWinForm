using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoRWinForm
{
    class Game
    {
        public int[,] GameField { get; set; }
        public bool FirstPlayerMove { get; set; }
        //  private Point p { get; set; }
        public bool Wined { get; private set; }

        public Game()
        {
            GameField = new int[3, 3];
            FirstPlayerMove = true;
        }

        public void MakeMove(Point p)
        {
            int flag = FirstPlayerMove ? 1 : -1;
            GameField[p.X, p.Y] = flag;

            if (TestWin())
            {
                Wined = true;
            }
            else
            {
                FirstPlayerMove = !FirstPlayerMove;
            }

        }

        public void PcMove()
        {
            int flag = FirstPlayerMove ? 1 : -1;
            var rnd = new Random();
            int x = rnd.Next(3);
            int y = rnd.Next(3);

            while (GameField[x, y] != 0)
            {
                x = rnd.Next(3);
                y = rnd.Next(3);
            }
            GameField[x, y] = flag;

            if (TestWin())
            {
                Wined = true;
            }
            else
            {
                FirstPlayerMove = !FirstPlayerMove;
            }
        }

        public bool TestDeadHeat()
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (GameField[i, j] == 0)
                        return false;
                }
            }
            return true;
        }

        private bool TestWin()
        {
            for (var i = 0; i < 3; i++)
            {
                if (Math.Abs(GameField[i, 0] + GameField[i, 1] + GameField[i, 2]) == 3) return true;
                if (Math.Abs(GameField[0, i] + GameField[1, i] + GameField[2, i]) == 3) return true;
            }
            if (Math.Abs(GameField[0, 0] + GameField[1, 1] + GameField[2, 2]) == 3) return true;
            if (Math.Abs(GameField[0, 2] + GameField[1, 1] + GameField[2, 0]) == 3) return true;
            return false;
        }
    }
}
