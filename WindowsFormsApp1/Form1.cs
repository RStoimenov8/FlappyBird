using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        bool jumping = false;
        int pipeSpeed = 4;
        int gravity = 4;
        int Inscore = 0;

        public int Inscore1 { get => Inscore; set => Inscore = value; }

        public Form1()
        {
            InitializeComponent();
            EndText1.Text = "Game Over!";
            EndText2.Text = "Your final score is: " + Inscore;
            GameDesigner.Text = "Game Designet by Stoimenov!";
            EndText1.Visible = false;
            EndText2.Visible = false;
            GameDesigner.Visible = false;
            btnReset.Visible = false;
            btnClose.Visible = false;

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            flappyBird.Top += gravity;
            ScoreText.Text = "" + Inscore;

            if (pipeBottom.Left < -80)
            {
                pipeBottom.Left = 700;
                Inscore += 1;
            }
            else if (pipeTop.Left < -95)
            {
                pipeTop.Left = 800;
                Inscore += 1;
            }
            if (flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }
            else if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds))
            {
                endGame();
            }
            else if (flappyBird.Bounds.IntersectsWith(pipeTop.Bounds))
            {
                endGame();
            }
        }

        private void inGameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = true;
                gravity = -5;
            }
        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = false;
                gravity = 5;
            }
        }

        private void endGame()
        {
            GameTimer.Stop();
            EndText1.Visible = true;
            EndText2.Visible = true;
            EndText2.Text = "Your Final score is: " + Inscore;
            GameDesigner.Visible = true;
            btnReset.Visible = true;
            btnClose.Visible = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Use your Space button!");
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Stoimenov!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
