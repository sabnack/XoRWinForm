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

        public Game()
        {
            InitializeComponent();
        }

        public Game(Start start)
        {
            _gameField = new int[3, 3];
            InitializeComponent();
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
            _moveCount = 0;
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
            string str;
            int flag = 1;
            if (_firstPlayerMove)
            {
                str = "X";
            }
            else
            {
                str = "O";
                flag = -1;
            }
            var tmp = (sender as Button).Name.Split(new char[] { ',' });
            _gameField[int.Parse(tmp[0]), int.Parse(tmp[1])] = flag;
            (sender as Button).Text = str;
            (sender as Button).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            (sender as Button).Enabled = false;
            _moveCount++;

            if (TestWin())
            {
                string str2;
                if (_firstPlayerMove)
                {
                    str2 = "First Player Win!";
                }
                else
                {
                    str2 = "Second Player Win!";
                }
                MessageBox.Show(str2);
                this.Close();
                return;
            }

            if (_moveCount == 9)
            {
                MessageBox.Show("Dead heat!");
                this.Close();
            }

            if (_firstPlayerMove)
            {
                _firstPlayerMove = false;
            }
            else
            {
                _firstPlayerMove = true;
            }
        }
    }
}
