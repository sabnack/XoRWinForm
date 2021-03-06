﻿using System;
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
        public bool Wined { get; private set; }
        public int Level { get; private set; }

        public Game(int level)
        {
            Level = level;
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

        public Game Clone()
        {
            return new Game(Level) { GameField = (int[,])GameField.Clone(), FirstPlayerMove = FirstPlayerMove, Wined = Wined };
        }
    }
}
