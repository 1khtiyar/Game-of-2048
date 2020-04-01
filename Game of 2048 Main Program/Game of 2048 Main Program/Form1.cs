using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_2048_Main_Program
{
    delegate void ControlHandler(int[,] theGameBoard);
    public partial class Form1 : Form
    {

        ControlHandler actionAfterKeyDown;

        public static int[,] gameBoard = new int[4, 4];
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 4; i++)
            {
                Random rd = new Random();
                gameBoard[rd.Next(0, 4), rd.Next(0, 4)] = i % 2 == 0 ? 2 : 4;
            }
        }


        //Control functionality:
        public static void Down(int[,] gameBoard)
        {
            for (int j = 0; j < 4; j++)
            {
                bool enough = false;
                startRechecking:
                for (int i = 0, helper = 0; i < 4; i++, helper++)
                {
                    if (i < 3 && gameBoard[i + 1, j] == 0)
                    {
                        gameBoard[i + 1, j] = gameBoard[i, j];
                        gameBoard[i, j] = 0;
                    }
                    if (i > 0 && gameBoard[i, j] == 0)
                    {
                        gameBoard[i, j] = gameBoard[i - 1, j];
                        gameBoard[i - 1, j] = 0;
                    }
                    i = helper == 3 || helper == 7 ? 0 : i; //recheck 2 times
                }
                if (enough)
                {
                    continue;
                }
                for (int i = 3; i > 0; i--)
                {
                    if (gameBoard[i, j] == gameBoard[i - 1, j])
                    {
                        gameBoard[i, j] *= 2;
                        gameBoard[i - 1, j] = 0;
                    }
                }
                enough = true;
                goto startRechecking;
            }
        }
        public static void Up(int[,] gameBoard)
        {
            for (int j = 0; j < 4; j++)
            {
                bool enough = false;
                startRechecking:
                for (int i = 3, helper = 0; i >= 0; i--, helper++)
                {
                    if (i > 0 && gameBoard[i - 1, j] == 0)
                    {
                        gameBoard[i - 1, j] = gameBoard[i, j];
                        gameBoard[i, j] = 0;
                    }
                    if (i < 3 && gameBoard[i, j] == 0)
                    {
                        gameBoard[i, j] = gameBoard[i + 1, j];
                        gameBoard[i + 1, j] = 0;
                    }
                    i = helper == 3 || helper == 7 ? 0 : i; //recheck 2 times
                }
                if (enough)
                {
                    continue;
                }
                for (int i = 0; i < 3; i++)
                {
                    if (gameBoard[i, j] == gameBoard[i + 1, j])
                    {
                        gameBoard[i, j] *= 2;
                        gameBoard[i + 1, j] = 0;
                    }
                }
                enough = true;
                goto startRechecking;
            }
        }
        public static void Right(int[,] gameBoard)
        {
            for (int i = 0; i < 4; i++)
            {
                bool enough = false;
                startRechecking:
                for (int j = 0, helper = 0; j < 4; j++, helper++)
                {
                    if (j < 3 && gameBoard[i, j + 1] == 0)
                    {
                        gameBoard[i, j + 1] = gameBoard[i, j];
                        gameBoard[i, j] = 0;
                    }
                    if (j > 0 && gameBoard[i, j] == 0)
                    {
                        gameBoard[i, j] = gameBoard[i, j - 1];
                        gameBoard[i, j - 1] = 0;
                    }
                    j = helper == 3 || helper == 7 ? 0 : j; //recheck 2 times
                }
                if (enough)
                {
                    continue;
                }
                for (int j = 3; j > 0; j--)
                {
                    if (gameBoard[i, j] == gameBoard[i, j - 1])
                    {
                        gameBoard[i, j] *= 2;
                        gameBoard[i, j - 1] = 0;
                    }
                }
                enough = true;
                goto startRechecking;
            }
        }
        public static void Left(int[,] gameBoard)
        {
            for (int i = 0; i < 4; i++)
            {
                bool enough = false;
                startRechecking:
                for (int j = 3, helper = 0; j >= 0; j--, helper++)
                {
                    if (j > 0 && gameBoard[i, j - 1] == 0)
                    {
                        gameBoard[i, j - 1] = gameBoard[i, j];
                        gameBoard[i, j] = 0;
                    }
                    if (j < 3 && gameBoard[i, j] == 0)
                    {
                        gameBoard[i, j] = gameBoard[i, j + 1];
                        gameBoard[i, j + 1] = 0;
                    }
                    j = helper == 3 || helper == 7 ? 0 : j; //recheck 2 times
                }
                if (enough)
                {
                    continue;
                }
                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard[i, j] == gameBoard[i, j + 1])
                    {
                        gameBoard[i, j] *= 2;
                        gameBoard[i, j + 1] = 0;
                    }
                }
                enough = true;
                goto startRechecking;
            }
        }


        //Control handlers:

        private void ControlKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) {
                actionAfterKeyDown = Form1.Right;
                actionAfterKeyDown(Form1.gameBoard);
            }
            else if (e.KeyCode == Keys.Left)
            {
                actionAfterKeyDown = Form1.Left;
                actionAfterKeyDown(Form1.gameBoard);
            }
            else if (e.KeyCode == Keys.Up)
            {
                actionAfterKeyDown = Form1.Up;
                actionAfterKeyDown(Form1.gameBoard);
            }
            else if (e.KeyCode == Keys.Down)
            {
                actionAfterKeyDown = Form1.Down;
                actionAfterKeyDown(Form1.gameBoard);
            }

        }



        //public void PutResultsOnBoard()
        //{
        //    this.tableLayoutPanel1.ColumnStyles[]
        //}
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
