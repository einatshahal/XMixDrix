using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic;

namespace UI
{
    class UserSystemGame
    {
        private MangeGame m_game = new MangeGame();
        private int m_boardSize;
        private bool m_isPlayerWantToContinue = true;
        private bool m_isAnyPlayerWin = false;

        public void Run()
        {
            MenuGame();

            while (m_isPlayerWantToContinue || !m_isAnyPlayerWin)
            {
                if(m_game.IsPlayer2Computer)
                {
                   PlayWithComputer(); 
                }
                else
                {
                    PlayWithOtherPlayer();
                }
            }
        }
        public void MenuGame()
        {
            Console.WriteLine("          Reverse X-Mix-Drix Game            ");
            Console.Write("Please choose the size of the board that you want to play with:\n" +
                "3. 3x3\n" +
                "4. 4x4\n" +
                "5. 5x5\n" +
                "6. 6x6\n" +
                "7. 7x7\n" +
                "8. 8x8\n" +
                "9. 9x9\n");

            while (!IsValidInputSizeBoardAndUpdate())
            {
                if (m_isPlayerWantToContinue)
                {
                    Console.WriteLine("You Enter invalid input, please try again");
                }
                else
                {
                    
                }
            }

            Console.WriteLine("Please choose if you want to play the game:\n" +
                "1. with two players\n" +
                "2. with the computer\n");

            while (!IsValidInputRivalAndUpdate())
            {
                if (m_isPlayerWantToContinue)
                {
                    Console.WriteLine("You Enter invalid input, please try again");
                }
                else
                {

                }
            }
        }
        public bool IsValidInputSizeBoardAndUpdate()
        {
            bool isValid = true;
            int numberChoice;
            string inputUser = Console.ReadLine();

            if (inputUser == "Q" || inputUser == "q")
            {
                m_isPlayerWantToContinue = false;
                isValid = false;
            }
            else
            {
                if (!(int.TryParse(inputUser, out numberChoice)))
                {

                    isValid = false;
                }
                else
                {
                    if (numberChoice > 2 && numberChoice < 10)
                    {
                        m_game.initBoard(numberChoice);
                        m_boardSize = numberChoice;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
            }
            return isValid;
        }
        public bool IsValidInputRivalAndUpdate()
        {
            bool isValid = true;
            int numberChoice;
            string inputUser = Console.ReadLine();

            if (inputUser == "Q" || inputUser == "q")
            {
                m_isPlayerWantToContinue = false;
                isValid = false;
            }
            else
            {
                if (!(int.TryParse(inputUser, out numberChoice)))
                {
                    isValid = false;
                }
                else
                {
                    if (numberChoice == 1 || numberChoice == 2)
                    {
                        m_game.initPlayers(numberChoice);
                    }
                    else
                    {
                        isValid = false;
                    }
                }
            }
            return isValid;
        }
        public void printBoard()
        {

            Console.Write("  ");
            for (int i = 1; i <= m_boardSize; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            for (int i = 1; i <= m_boardSize; i++)
            {
                Console.Write(i + "|");
                for (int j = 1; j <= m_boardSize; j++)
                {
                    Console.Write(m_game.getSignCell(i, j) + "|");
                }
                Console.WriteLine();
                if (i != m_boardSize)
                {
                    Console.Write("=");
                    for (int j = 1; j <= m_boardSize; j++)
                    {
                        Console.Write("==");
                    }
                    Console.WriteLine();
                }
            }
        }
        public void PlayWithComputer() 
        {
            if(m_game.IsPlayer1Turn)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                printBoard();
                Console.WriteLine("\nPlease Enter the row and column of the cell that you want to place your sign:");

                int io_row=0;
                int io_col=0;
                while (!IsValidInputCell(ref io_row,ref io_col))
                {
                    io_row = 0;
                    io_col = 0;
                    Console.WriteLine("You Enter invalid input, please try again");
                }

                m_game.updateCell(io_row,io_col);
                m_isAnyPlayerWin = m_game.IsPlayerLose(io_row, io_col);

                m_game.IsPlayer1Turn = false;
            }
            //computer turn
            else
            {
                Ex02.ConsoleUtils.Screen.Clear();
                printBoard();

                int row = 0;
                int col = 0;

                Random rnd = new Random();
                do
                {
                    row = rnd.Next(1, m_boardSize + 1);
                    col = rnd.Next(1, m_boardSize + 1);
                }
                while (!m_game.IsEmptyCell(row, col));

                m_game.updateCell(row,col);
                m_isAnyPlayerWin = m_game.IsPlayerLose(row, col);

                m_game.IsPlayer1Turn = true;
            }
       
        }
        public void PlayWithOtherPlayer() 
        {
            Ex02.ConsoleUtils.Screen.Clear();
            printBoard();
            Console.WriteLine("\nPlease Enter the row and column of the cell that you want to place your sign:");

            int io_row = 0;
            int io_col = 0;
            while (!IsValidInputCell(ref io_row, ref io_col))
            {
                io_row = 0;
                io_col = 0;
                Console.WriteLine("You Enter invalid input, please try again");
            }

            m_game.updateCell(io_row, io_col);
            m_isAnyPlayerWin = m_game.IsPlayerLose(io_row, io_col);

            if (m_game.IsPlayer1Turn)
            {
                m_game.IsPlayer1Turn = false;
            }
            else
            {
                m_game.IsPlayer1Turn = true;
            }
        }
        public bool IsValidInputCell(ref int io_row, ref int io_col)
        {
            bool isValid = true;
            string inputUser = Console.ReadLine();

            if (inputUser == "Q" || inputUser == "q")
            {
                m_isPlayerWantToContinue = false;
                isValid = false;
            }
            else
            {
               foreach(char c in inputUser)
               {
                    if (char.IsDigit(c))
                    {
                        int numberFromChar = c - '0';

                        if (numberFromChar <= m_boardSize && numberFromChar > 0) 
                        {
                            if (io_row == 0)
                            {
                                io_row = numberFromChar;
                            }
                            else if (io_col == 0)
                            {
                                io_col = numberFromChar;
                            }
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }

                    else
                    {
                        if (c != ' ')
                        {
                            isValid = false;
                            break;
                        }
                    }
               }

                if (io_row == 0 || io_col == 0)
                {
                    isValid = false;
                }

                if (isValid == true)
                {
                    if (!m_game.IsEmptyCell(io_row, io_col))
                    {
                        isValid = false;
                    }
                }
            }
            return isValid;
        }
    }
}
