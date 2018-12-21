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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

          //  Load += LoadEvent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var game = new Game(this);
            game.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var game = new Game(this,1);
            game.Show();
            this.Hide();
        }

        //private void Start_Load(object sender, EventArgs e)
        //{
        //    Button helloButton = new Button();
        //    helloButton.BackColor = Color.LightGray;
        //    helloButton.ForeColor = Color.DarkGray;
        //    helloButton.Location = new Point(10, 10);
        //    helloButton.Text = "Привет";
        //    this.Controls.Add(helloButton);
        //}

        //private void LoadEvent(object sender, EventArgs e)
        //{
        //    BackColor = Color.Red;
        //}
    }
}
