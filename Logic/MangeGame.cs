using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class MangeGame
    {
        Board board;
        Player m_player1 = new Player();
        Player m_player2 = new Player();
        private bool m_isPlayer1Turn = true;
        int m_countEmptyCell;

        public static void Main()
        { }
        public int CountEmptyCell
        {
            get { return m_countEmptyCell; }
        }
        public bool IsPlayer1Turn
        {
            get { return m_isPlayer1Turn; }
            set { m_isPlayer1Turn = value; }
        }
        public bool IsPlayer2Computer
        {
            get { return m_player2.IsComputer; }
        }
        public void initBoard(int i_sizeBoard)
        {
            board = new Board(i_sizeBoard);
            m_countEmptyCell = i_sizeBoard * i_sizeBoard;
        }
        public void initPlayers(int i_numberChoise)
        {
            m_player1.PlayerSign = eCell.X;
            m_player2.PlayerSign = eCell.O;
            m_player1.IsComputer = false;

            if (i_numberChoise == 1)
            {
                m_player2.IsComputer = false;
            }
            if (i_numberChoise == 2)
            {
                m_player2.IsComputer = true;
            }
        }
        public void updateCell(int i_row,int i_col)
        {
            if (m_isPlayer1Turn == true)
            {
                board.updateCell(i_row, i_col, m_player1.PlayerSign);
            }
            else
            {
                board.updateCell(i_row, i_col, m_player2.PlayerSign);
            }
            m_countEmptyCell--;
        }
        public bool IsEmptyCell(int i_row,int i_col)
        {
            bool isEmpty = true;
            if(!board.IsCellEmpty(i_row,i_col))
            {
                isEmpty = false;
            }
            return isEmpty;
        }
        public string getSignCell(int i_row,int i_col)
        {
            string sign = board.getSignCell(i_row, i_col);
            if (sign == "EMPTY")
            {
                sign = " ";
            }
            return sign;
        }
        public bool IsPlayerLose(int i_row, int i_col)
        {
            bool IsLose = true;
            eCell signPlayer;

            if (m_isPlayer1Turn == true)
            {
                signPlayer = m_player1.PlayerSign;
            }
            else
            {
                signPlayer = m_player2.PlayerSign;
            }

            //check row
            for (int i = 1; i <= board.boardSize; i++) 
            {
                if (board.getSignCell(i_row,i) != signPlayer.ToString())
                {
                    IsLose = false;
                    break;
                }
            }

            if (!IsLose)
            {
                //check col
                for (int i = 1; i <= board.boardSize; i++)
                {
                    if (board.getSignCell(i, i_col) != signPlayer.ToString())
                    {
                        IsLose = false;
                        break;
                    }
                }
            }

            if (!IsLose)
            {
                //slant1
                for (int i = 1; i <= board.boardSize; i++)
                {
                    if (board.getSignCell(i, i) != signPlayer.ToString())
                    {
                        IsLose = false;
                        break;
                    }
                }
            }

            if (!IsLose)
            {
                //slant2
                int tempCol = board.boardSize;

                for (int i = 1; i <= board.boardSize; i++)
                {
                    if (board.getSignCell(i, tempCol) != signPlayer.ToString())
                    {
                        IsLose = false;
                        break;
                    }
                    tempCol--;
                }
            }


            if(!IsLose)
            {
                if (m_isPlayer1Turn == true)
                {
                   m_player2.Score++;
                }
                else
                {
                    m_player1.Score++;
                }
            }

            return IsLose;
        }

    }
}

