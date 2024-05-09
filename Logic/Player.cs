using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Logic
{
    public class Player
    {
        private int m_Score = 0;
        private bool m_IsComputer;
        private eCell m_PlayerSign;

        public int Score
        {
            get{ return m_Score; }
            set{ m_Score = value; }
        }
        public bool IsComputer
        {
            get { return m_IsComputer; }
            set { m_IsComputer = value; }
        }
        public eCell PlayerSign
        {
            get { return m_PlayerSign; }
            set { m_PlayerSign = value; }
        }
    }
}
