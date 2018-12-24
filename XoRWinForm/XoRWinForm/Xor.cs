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
    public partial class Xor : Form
    {
        private Start _start { get; }
        private int _level { get; }

        private Game Game { get; set; }

        public Xor()
        {
            InitializeComponent();
        }

        public Xor(Start start, int level = 0)
        {
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
            Game = new Game();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var tmp = (sender as Button).Name.Split(new char[] { ',' });
            var p = new Point() { X = int.Parse(tmp[0]), Y = int.Parse(tmp[1]) };

            if (!Game.Wined && !Game.TestDeadHeat())
            {
                Game.PcMove();
            }

            DrawField();

            if (Game.Wined)
            {
                MessageBox.Show(Game.FirstPlayerMove ? "First Player Win!" : "Second Player Win!");
                this.Close();
            }
        }

        private void DrawField()
        {
            foreach (Button item in this.tableLayoutPanel1.Controls)
            {
                var tmp = item.Name.Split(new char[] { ',' });
                var p = new Point() { X = int.Parse(tmp[0]), Y = int.Parse(tmp[1]) };
                if (Game.GameField[p.X, p.Y] != 0)
                {
                    if (Game.GameField[p.X, p.Y] == -1)
                    {
                        item.Text = "O";
                    }
                    else
                    {
                        item.Text = "X";
                    }
                    item.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    item.Enabled = false;
                }
            }

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

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            _start.Show();
        }
    }
}
