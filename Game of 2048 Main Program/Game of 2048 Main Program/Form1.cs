using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_2048_Main_Program
{
    public partial class Form1 : Form
    {
        public static Button[,] buttons = new Button[4, 4];

        public static int[,] gameBoard = new int[4, 4];
        public Form1()
        {
            InitializeComponent();
            buttons = new Button[,]{
                { button2,button3,button4,button5},
                { button6,button7,button8,button9},
                { button10,button11,button12,button13},
                { button14,button15,button16,button17}
            };

            for (int i = 0; i < 4; i++)
            {
                Random rd = new Random();
                Form1.gameBoard[rd.Next(0, 4), rd.Next(0, 4)] = i % 2 == 0 ? 2 : 4;
            }
            PutResultsOnBoard();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            buttons = new Button[,]{
                { button2,button3,button4,button5},
                { button6,button7,button8,button9},
                { button10,button11,button12,button13},
                { button14,button15,button16,button17}
            };

            for (int i = 0; i < 4; i++)
            {
                Random rd = new Random();
                Form1.gameBoard[rd.Next(0, 4), rd.Next(0, 4)] = i % 2 == 0 ? 2 : 4;
            }
            PutResultsOnBoard();
        }


        //Control functionality:
        public static void Down(ref int[,] gameBoard)
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
        public static void Up(ref int[,] gameBoard)
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
        public static void Right(ref int[,] gameBoard)
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
        public static void Left(ref int[,] gameBoard)
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


        public void PutResultsOnBoard()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (gameBoard[i, j]==0)
                    {
                        buttons[i, j].Text = null;
                        buttons[i, j].BackgroundImage = button23.BackgroundImage;
                        continue;
                    }
                    buttons[i, j].Text = gameBoard[i, j].ToString();
                    if (gameBoard[i,j]>=32)
                        buttons[i, j].BackgroundImage = button22.BackgroundImage;
                    else if (gameBoard[i,j]==16 || gameBoard[i, j] == 8)
                        buttons[i, j].BackgroundImage = button23.BackgroundImage;
                    else if (gameBoard[i, j] == 2 || gameBoard[i, j] == 4)
                        buttons[i, j].BackgroundImage = button24.BackgroundImage;
                }
            }
        }

        //Put additional value on gameboard
        public void AddVal(ref int[,] gameBoard)
        {
            Random rd = new Random();
            recheckNull:
            int i = rd.Next(0, 3), j = rd.Next(0, 3);
            if (gameBoard[i, j] != 0)
                goto recheckNull;
            gameBoard[i, j] = 2;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void RestartButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    gameBoard[i, j] = 0;
                    buttons[i, j].Text = null;
                }
            }
        }


        private void DownClick(object sender, EventArgs e)
        {
            Down(ref gameBoard);
            AddVal(ref gameBoard);
            PutResultsOnBoard();
        }
        private void UpClick(object sender, EventArgs e)
        {
            Up(ref gameBoard);
            AddVal(ref gameBoard);
            PutResultsOnBoard();
        }
        private void RightClick(object sender, EventArgs e)
        {
            Right(ref gameBoard);
            AddVal(ref gameBoard);
            PutResultsOnBoard();
        }
        private void LeftClick(object sender, EventArgs e)
        {
            Left(ref gameBoard);
            AddVal(ref gameBoard);
            PutResultsOnBoard();
        }
    }
}
