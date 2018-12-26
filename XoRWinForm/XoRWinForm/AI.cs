using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoRWinForm
{
    class AI
    {

        public Move GetBestMove(Game game)
        {
            var EmptyCell = GetEmptyCell(game);
            var BestMoves = new List<Move>();
            if (EmptyCell.Count == 0) return null;

            foreach (var item in EmptyCell)
            {
                BestMoves.Add(GetBestMove(game, item));
            }

            var bestMove = new Move();

            foreach (var item in BestMoves)
            {
                if (item.Score > 0)// && game.FirstPlayerMove)
                {
                    bestMove = item;
                }
            }

            if (bestMove.Score == 0)
            {
                foreach (var item in BestMoves)
                {
                    if (bestMove.Score > item.Score)// && game.FirstPlayerMove)
                    {
                        bestMove = item;
                    }
                }
            }

            if (bestMove.Score == 0)
            {
                bestMove = BestMoves[new Random().Next(BestMoves.Count)];
            }
            return bestMove;
        }

        private Move GetBestMove(Game game, Point p)
        {
            var result = new Move() { P = p };
            var g = game.Clone();
            g.MakeMove(p);

            if (g.Wined)
            {
                result.Score = 10;
                return result;
            }
            g = game.Clone();

            g.FirstPlayerMove = !g.FirstPlayerMove;
            g.MakeMove(p);
            if (g.Wined)
            {
                result.Score = -10;
                return result;
            }
            return result;
        }

        public List<Point> GetEmptyCell(Game game)
        {
            List<Point> EmptyCell = new List<Point>();

            for (var x = 0; x < 3; x++)
            {
                for (var y = 0; y < 3; y++)
                {
                    if (game.GameField[x, y] == 0)
                    {
                        EmptyCell.Add(new Point(x, y));
                    }
                }
            }
            return EmptyCell;
        }
    }

    class Move
    {
        public Point P;
        public int Score;
    }
}
