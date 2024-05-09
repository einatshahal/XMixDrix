using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
     class Board
    {
        private
        int m_boardSize;
        eCell[,] board;

        public Board(int sizeBoard)
        {
            m_boardSize = sizeBoard;
            board = new eCell[m_boardSize, m_boardSize];
            for (int i = 0; i < m_boardSize; i++)
            {
                for (int j = 0; j < m_boardSize; j++)
                {
                    board[i,j]= eCell.EMPTY;
                }
            }
        }
        public int boardSize
        {
            get { return m_boardSize; }
        }
        public bool IsCellEmpty(int i_row, int i_col)
        {
            bool isEmpty = true;

            if (board[i_row - 1, i_col - 1] != eCell.EMPTY)
            {
                isEmpty = false;

            }
            return isEmpty;
        }
        public void updateCell(int i_row, int i_col, eCell i_playerSign)
        {
            board[i_row - 1, i_col - 1] = i_playerSign;
        }
        public string getSignCell(int i_row, int i_col)
        {
           return board[i_row - 1, i_col - 1].ToString();
        }
    }
}
