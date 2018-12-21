using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XoRWinForm
{
    public partial class Game : Form
    {
        private bool _firstPlayerMove { get; set; }
        private int[,] _gameField { get; set; }
        private int _moveCount { get; set; }
        private Start _start { get; }
        private int _level { get; }

        public Game()
        {
            InitializeComponent();
        }

        public Game(Start start)
        {
            _gameField = new int[3, 3];
            _start = start;
            InitializeComponent();
            InitButtonsName();
            button1.Click += Button_Click;
            button2.Click += Button_Click;
            button3.Click += Button_Click;
            button4.Click += Button_Click;
            button5.Click += Button_Click;
            button6.Click += Button_Click;
            button7.Click += Button_Click;
            button8.Click += Button_Click;
            button9.Click += Button_Click;
            _firstPlayerMove = true;
        }
        
        public Game(Start start, int level)
        {
            _level = level;
            _gameField = new int[3, 3];
            _start = start;
            InitializeComponent();
            InitButtonsName();
            button1.Click += Button_Click;
            button2.Click += Button_Click;
            button3.Click += Button_Click;
            button4.Click += Button_Click;
            button5.Click += Button_Click;
            button6.Click += Button_Click;
            button7.Click += Button_Click;
            button8.Click += Button_Click;
            button9.Click += Button_Click;
            _firstPlayerMove = true;
            CompMove();
        }

        private void InitButtonsName()
        {
            button1.Name = "0,0";
            button2.Name = "0,1";
            button3.Name = "0,2";
            button4.Name = "1,0";
            button5.Name = "1,1";
            button6.Name = "1,2";
            button7.Name = "2,0";
            button8.Name = "2,1";
            button9.Name = "2,2";
        }

        private bool TestWin()
        {
            if (Math.Abs(_gameField[0, 0] + _gameField[0, 1] + _gameField[0, 2]) == 3) return true;
            if (Math.Abs(_gameField[1, 0] + _gameField[1, 1] + _gameField[1, 2]) == 3) return true;
            if (Math.Abs(_gameField[2, 0] + _gameField[2, 1] + _gameField[2, 2]) == 3) return true;
            if (Math.Abs(_gameField[0, 0] + _gameField[1, 0] + _gameField[2, 0]) == 3) return true;
            if (Math.Abs(_gameField[0, 1] + _gameField[1, 1] + _gameField[2, 1]) == 3) return true;
            if (Math.Abs(_gameField[0, 2] + _gameField[1, 2] + _gameField[2, 2]) == 3) return true;
            if (Math.Abs(_gameField[0, 0] + _gameField[1, 1] + _gameField[2, 2]) == 3) return true;
            if (Math.Abs(_gameField[0, 2] + _gameField[1, 1] + _gameField[2, 0]) == 3) return true;
            return false;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string str = _firstPlayerMove ? "X" : "O";
            int flag = _firstPlayerMove ? 1 : -1;

            var tmp = (sender as Button).Name.Split(new char[] { ',' });
            _gameField[int.Parse(tmp[0]), int.Parse(tmp[1])] = flag;
            (sender as Button).Text = str;
            (sender as Button).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            (sender as Button).Enabled = false;
            _moveCount++;

            if(EndGame()) return;

            TestDeadHeat();

            _firstPlayerMove = _firstPlayerMove ? false : true;

            if (_level != 0)
            {
                CompMove();
            }
        }

        private bool EndGame(string str = "First Player Win!")
        {
            if (TestWin())
            {
                MessageBox.Show(_firstPlayerMove ? str : "Second Player Win!");
                this.Close();
                return true;
            }
            return false;
        }

        private void CompMove()
        {
            var rnd = new Random();
            int x = rnd.Next(3);
            int y = rnd.Next(3);

            while (_gameField[x, y]!=0)
            {
                x = rnd.Next(3);
                y = rnd.Next(3);
            }
            _gameField[x, y] = 1;

            foreach (var item in tableLayoutPanel1.Controls)
            {
                if ((item as Button).Name == x + "," + y)
                {
                    (item as Button).Text = "X";
                    (item as Button).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    (item as Button).Enabled = false;
                    _moveCount++;
                }
            }
            if(EndGame("Computer Win!")) return;
            TestDeadHeat();
            _firstPlayerMove = false;
        }

        private void TestDeadHeat()
        {
            if (_moveCount == 9)
            {
                MessageBox.Show("Dead heat!");
                this.Close();
            }
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            _start.Show();
        }

    }
}
