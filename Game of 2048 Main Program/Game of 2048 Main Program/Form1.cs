using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game_of_2048_Main_Program
{
    public partial class Form1 : Form
    {
        public static Button[,] buttons = new Button[4, 4];
        public static bool rulesFormEnabled = false;
        public static int[,] gameBoard = new int[4, 4];
        public static int swapMade = 0;
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            buttons = new Button[,]{
                { button2,button3,button4,button5},
                { button6,button7,button8,button9},
                { button10,button11,button12,button13},
                { button14,button15,button16,button17}
            };

            gameBoard[DateTime.Now.Minute % 3, DateTime.Now.Second % 3] = 2;
            gameBoard[DateTime.Now.Second % 3, DateTime.Now.Minute % 3] = 4;
            gameBoard[DateTime.Now.Second % 3, DateTime.Now.Second % 3] = 2;

            for (int i = 0; i < 4; i++)
            {
                Random rd = new Random();
                Form1.gameBoard[rd.Next(0, 4), rd.Next(0, 4)] = i % 2 == 0 ? 2 : 4;
            }
            PutResultsOnBoard();
        }

        //////////
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad4)
                LeftClickEvent();
            else if (e.KeyCode == Keys.NumPad6)
                RightClickEvent();
            else if (e.KeyCode == Keys.NumPad8)
                UpClickEvent();
            else if (e.KeyCode == Keys.NumPad2)
                DownClickEvent();
            else if (e.KeyCode == Keys.R)
                RestartEvent();

        }
        //////////

        //Control functionality:
        public static void DownAction(ref int[,] gameBoard,ref int swapsMade)
        {
            for (int j = 0; j < 4; j++)
            {
                bool enough = false;
                startRechecking:
                for (int i = 0, helper = 0; i < 4; i++, helper++)
                {
                    if (i < 3 && gameBoard[i + 1, j] == 0 && gameBoard[i,j]!=0)
                    {
                        gameBoard[i + 1, j] = gameBoard[i, j];
                        gameBoard[i, j] = 0;
                        swapsMade++;
                    }
                    if (i > 0 && gameBoard[i, j] == 0 && gameBoard[i-1, j] != 0)
                    {
                        gameBoard[i, j] = gameBoard[i - 1, j];
                        gameBoard[i - 1, j] = 0;
                        swapsMade++;
                    }
                    i = helper == 3 || helper == 7 ? 0 : i; //recheck 2 times
                }
                if (enough)
                {
                    continue;
                }
                for (int i = 3; i > 0; i--)
                {
                    if (gameBoard[i, j] != 0 && gameBoard[i, j] == gameBoard[i - 1, j])
                    {
                        gameBoard[i, j] *= 2;
                        gameBoard[i - 1, j] = 0;
                        swapsMade++;
                    }
                }
                enough = true;
                goto startRechecking;
            }
        }
        public static void UpAction(ref int[,] gameBoard,ref int swapsMade)
        {
            for (int j = 0; j < 4; j++)
            {
                bool enough = false;
                startRechecking:
                for (int i = 3, helper = 0; i >= 0; i--, helper++)
                {
                    if (i > 0 && gameBoard[i - 1, j] == 0 && gameBoard[i,j]!=0)
                    {
                        gameBoard[i - 1, j] = gameBoard[i, j];
                        gameBoard[i, j] = 0;
                        swapsMade++;
                    }
                    if (i < 3 && gameBoard[i, j] == 0 && gameBoard[i+1,j]!=0)
                    {
                        gameBoard[i, j] = gameBoard[i + 1, j];
                        gameBoard[i + 1, j] = 0;
                        swapsMade++;
                    }
                    i = helper == 3 || helper == 7 ? 0 : i; //recheck 2 times
                }
                if (enough)
                {
                    continue;
                }
                for (int i = 0; i < 3; i++)
                {
                    if (gameBoard[i, j] != 0 && gameBoard[i, j] == gameBoard[i + 1, j])
                    {
                        gameBoard[i, j] *= 2;
                        gameBoard[i + 1, j] = 0;
                        swapsMade++;
                    }
                }
                enough = true;
                goto startRechecking;
            }
        }
        public static void RightAction(ref int[,] gameBoard,ref int swapsMade)
        {
            for (int i = 0; i < 4; i++)
            {
                bool enough = false;
                startRechecking:
                for (int j = 0, helper = 0; j < 4; j++, helper++)
                {
                    if (j < 3 && gameBoard[i, j + 1] == 0 && gameBoard[i,j]!=0)
                    {
                        gameBoard[i, j + 1] = gameBoard[i, j];
                        gameBoard[i, j] = 0;
                        swapsMade++;
                    }
                    if (j > 0 && gameBoard[i, j] == 0 && gameBoard[i,j-1]!=0)
                    {
                        gameBoard[i, j] = gameBoard[i, j - 1];
                        gameBoard[i, j - 1] = 0;
                        swapsMade++;
                    }
                    j = helper == 3 || helper == 7 ? 0 : j; //recheck 2 times
                }
                if (enough)
                {
                    continue;
                }
                for (int j = 3; j > 0; j--)
                {
                    if (gameBoard[i,j]!=0 && gameBoard[i, j] == gameBoard[i, j - 1])
                    {
                        gameBoard[i, j] *= 2;
                        gameBoard[i, j - 1] = 0;
                        swapsMade++;
                    }
                }
                enough = true;
                goto startRechecking;
            }
        }
        public static void LeftAction(ref int[,] gameBoard,ref int swapsMade)
        {
            for (int i = 0; i < 4; i++)
            {
                bool enough = false;
                startRechecking:
                for (int j = 3, helper = 0; j >= 0; j--, helper++)
                {
                    if (j > 0 && gameBoard[i, j - 1] == 0 && gameBoard[i,j]!=0)
                    {
                        gameBoard[i, j - 1] = gameBoard[i, j];
                        gameBoard[i, j] = 0;
                        swapsMade++;
                    }
                    if (j < 3 && gameBoard[i, j] == 0 && gameBoard[i,j+1]!=0)
                    {
                        gameBoard[i, j] = gameBoard[i, j + 1];
                        gameBoard[i, j + 1] = 0;
                        swapsMade++;
                    }
                    j = helper == 3 || helper == 7 ? 0 : j; //recheck 2 times
                }
                if (enough)
                {
                    continue;
                }
                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard[i,j]!=0 && gameBoard[i, j] == gameBoard[i, j + 1])
                    {
                        gameBoard[i, j] *= 2;
                        gameBoard[i, j + 1] = 0;
                        swapsMade++;
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
                    if (gameBoard[i,j]<8)
                        buttons[i, j].BackgroundImage = buttonFor2.BackgroundImage;
                    else if (gameBoard[i,j]<64)
                        buttons[i, j].BackgroundImage = buttonFor8.BackgroundImage;
                    else if (gameBoard[i, j] <256)
                        buttons[i, j].BackgroundImage = buttonFor64.BackgroundImage;
                    else if (gameBoard[i, j] <1024)
                        buttons[i, j].BackgroundImage = buttonFor256.BackgroundImage;
                    else
                        buttons[i, j].BackgroundImage = buttonFor1024.BackgroundImage;
                }
            }
        }

        public bool isCrowded(int[,] gameBoard)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (gameBoard[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            for (int i = 1; i < 3; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    if (gameBoard[i,j]==gameBoard[i+1,j] ||
                        gameBoard[i, j] == gameBoard[i - 1, j] ||
                        gameBoard[i, j] == gameBoard[i, j+1] ||
                        gameBoard[i, j] == gameBoard[i, j-1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Put additional value on gameboard
        public void AddVal(ref int[,] gameBoard)
        {
            Random rd = new Random();
            recheckNull:
            int i = rd.Next(0, 4), j = rd.Next(0, 4);
            if (gameBoard[i, j] != 0)
                goto recheckNull;
            gameBoard[i, j] = 2;
        }
        private bool isThereWinner(int[,] gameboard)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (gameboard[i,j]==2048)
                    {
                        return true;
                    }
                }
            }
            return false;
        }



        public void DownClickEvent()
        {
            if (RestartButton.BackColor == Color.Salmon)
                return;
            DownAction(ref gameBoard, ref Form1.swapMade);
            if (Form1.swapMade != 0)
            {
                AddVal(ref gameBoard);
            }
            if (((isCrowded(gameBoard) && Form1.swapMade == 0) || isThereWinner(gameBoard)))
            {
                RestartButton.BackColor = Color.Salmon;
            }
            PutResultsOnBoard();
            Form1.swapMade = 0;
        }
        public void UpClickEvent()
        {
            if (RestartButton.BackColor == Color.Salmon)
                return;
            UpAction(ref gameBoard, ref Form1.swapMade);
            if (Form1.swapMade != 0)
            {
                AddVal(ref gameBoard);
            }
            if (((isCrowded(gameBoard) && Form1.swapMade == 0) || isThereWinner(gameBoard)))
            {
                RestartButton.BackColor = Color.Salmon;
            }
            PutResultsOnBoard();
            Form1.swapMade = 0;
        }
        public void RightClickEvent()
        {
            if (RestartButton.BackColor == Color.Salmon)
                return;
            RightAction(ref gameBoard, ref Form1.swapMade);
            if (Form1.swapMade != 0)
            {
                AddVal(ref gameBoard);
            }
            if (((isCrowded(gameBoard) && Form1.swapMade == 0) || isThereWinner(gameBoard)))
            {
                RestartButton.BackColor = Color.Salmon;
            }
            PutResultsOnBoard();
            Form1.swapMade = 0;
        }
        public void LeftClickEvent()
        {
            if (RestartButton.BackColor == Color.Salmon)
                return;
            LeftAction(ref gameBoard, ref Form1.swapMade);
            if (Form1.swapMade != 0)
            {
                AddVal(ref gameBoard);
            }
            if (((isCrowded(gameBoard) && Form1.swapMade == 0) || isThereWinner(gameBoard)))
            {
                RestartButton.BackColor = Color.Salmon;
            }
            PutResultsOnBoard();
            Form1.swapMade = 0;
        }


        public void RestartEvent()
        {
            this.RestartButton.BackColor = Color.LightGray;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Form1.gameBoard[i, j] = 0;
                    Form1.buttons[i, j].Text = null;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                Random rd = new Random();
                Form1.gameBoard[rd.Next(0, 4), rd.Next(0, 4)] = i % 2 == 0 ? 2 : 4;
            }
            Form1.gameBoard[DateTime.Now.Minute % 3, DateTime.Now.Second % 3+1] = 2;
            Form1.gameBoard[DateTime.Now.Second % 3, DateTime.Now.Minute % 3+1] = 4;
            Form1.gameBoard[DateTime.Now.Second % 3+1, DateTime.Now.Second % 3] = 2;
            this.PutResultsOnBoard();
        }
        private void RestartButton_Click(object sender, EventArgs e)
        {
            RestartEvent();
        }
        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DetailsButton_Click(object sender, EventArgs e)
        {
            if (rulesFormEnabled)
            {
                return;
            }
            (new Rules()).Show();
            rulesFormEnabled = true;
        }
    }
}
