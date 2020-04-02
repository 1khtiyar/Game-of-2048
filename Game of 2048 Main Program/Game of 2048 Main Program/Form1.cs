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
    public partial class Form1 : Form
    {
        public static Button[,] buttons = new Button[4, 4];
        public static Color[] ColorsAccorValue = new Color[5];
        public static int[,] gameBoard = new int[4, 4];
        public Form1()
        {
            for (int i = 0,greenPart=160, bluePart = 110; i < 5; i++,greenPart+=10,bluePart+=10)
            {
                ColorsAccorValue[i] = Color.FromArgb(255, greenPart, bluePart);
            }
            buttons = new Button[,]{
                { button2,button3,button4,button5},
                { button6,button7,button8,button9},
                { button10,button11,button12,button13},
                { button14,button15,button16,button17}
            };
            InitializeComponent();

            for (int i = 0; i < 4; i++)
            {
                Random rd = new Random();
                gameBoard[rd.Next(0, 4), rd.Next(0, 4)] = i % 2 == 0 ? 2 : 4;
            }
            PutResultsOnBoard();
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
                Form1.Right(Form1.gameBoard);
            }
            else if (e.KeyCode == Keys.Left)
            {
                Form1.Left(Form1.gameBoard);
            }
            else if (e.KeyCode == Keys.Up)
            {
                Form1.Up(Form1.gameBoard);
            }
            else if (e.KeyCode == Keys.Down)
            {
                Form1.Down(Form1.gameBoard);
            }
            PutResultsOnBoard();
        }



        public void PutResultsOnBoard()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (gameBoard[i,j].ToString()!="0")
                    {
                        buttons[i, j].Text = gameBoard[i, j].ToString();
                        if (gameBoard[i, j]==2)
                            buttons[i, j].BackColor = ColorsAccorValue[0];
                        else if (gameBoard[i, j] == 4)
                            buttons[i, j].BackColor = ColorsAccorValue[1];
                        else if (gameBoard[i, j] == 8)
                            buttons[i, j].BackColor = ColorsAccorValue[2];
                        else if (gameBoard[i, j] == 16)
                            buttons[i, j].BackColor = ColorsAccorValue[3];
                        else if (gameBoard[i, j] == 32)
                            buttons[i, j].BackColor = ColorsAccorValue[4];
                        else if (gameBoard[i, j] == 64)
                            buttons[i, j].BackColor = ColorsAccorValue[5];
                    }
                }
            }
        }
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
