﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameLogic
    {
        public string CurrentPlayer { get; set; } = X;
        private const string X = "X";
        private const string O = "O";
        private string[,] Board = new string[3, 3];

        public void SetNextPlayer()
        {
            if(CurrentPlayer == X)
            {
                CurrentPlayer = O;
            }
            else
            {
                CurrentPlayer = X;
            }
        }

        public bool PlayerWin()
        {
            //check for horizontal rows
            for (int i = 0; i < 3; i++)
            {
                if (!String.IsNullOrWhiteSpace(Board[i, 0]))
                {
                    if (Board[i,0] == Board[i,1] && Board[i, 0] == Board[i, 2])
                    {
                        return true;
                    }
                }
            }

            //check for vertical columns
            for (int i = 0; i < 3; i++)
            {
                if (!String.IsNullOrWhiteSpace(Board[0, i]))
                {
                    if (Board[0, i] == Board[1, i] && Board[0, i] == Board[2, i])
                    {
                        return true;
                    }
                }
            }

            //check diagonally
            if (!String.IsNullOrWhiteSpace(Board[1, 1]))
            {
                if (Board[0, 0] == Board[1, 1] && Board[0, 0] == Board[2, 2])
                {
                    return true;
                }
                if (Board[1, 1] == Board[0, 2] && Board[1, 1] == Board[2, 0])
                {
                    return true;
                }
            }

            return false;
        }

        internal void UpdateBoard(Position position, string value)
        {
            Board[position.x, position.y] = value;
        }
    }
}
