using System.Runtime.CompilerServices;
using System.Text;
using TicTacToeBlazor.Components;

namespace TicTacToeBlazor.Helpers
{
    public class TicTacToeGame
    {
        public GameState State { get; set; }
        private bool isXNext;
        private readonly TicTacToeCell[] board;

        public TicTacToeGame()
        {
            this.State = GameState.NotFinished;
            this.isXNext = true;
            this.board = new TicTacToeCell[9];
            this.FillBoard();
        }

        private void FillBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                this.board[i] = new TicTacToeCell();
            }
        }

        public char GetCellState(int index)
        {
            return (char)this.board[index].CurrentState;
        }

        public void PlayCell(int index)
        {
            if (this.State == GameState.NotFinished)
            {
                CellState move = this.isXNext ? CellState.X : CellState.O;
                bool success = this.board[index].PlayCell(move);
                if (success)
                {
                    this.isXNext = !this.isXNext;
                }
                this.CheckForWinner();
            }
        }

        public void ResetGame()
        {
            this.State = GameState.NotFinished;
            this.isXNext = true;
            this.FillBoard();
        }

        public CellState NextMove()
        {
           CellState next = CellState.None;
           if (this.State==GameState.NotFinished) {
            next = isXNext ? CellState.X : CellState.O;
           }
           return next;
        }

        private void CheckForWinner()
        {
            CellState winner = CheckColumns();

            if (winner == CellState.None)
            {
                winner = this.CheckRows();
            }

            if (winner == CellState.None)
            {
                winner = this.CheckDiagnals();
            }

            if (winner != CellState.None)
            {
                if (winner == CellState.X)
                {
                    this.State = GameState.WinnerX;
                }
                else
                {
                    this.State = GameState.WinnerO;
                }
            }
            else if (this.IsFull())
            {
                this.State = GameState.Tie;
            }
            else
            {
                this.State = GameState.NotFinished;
            }
        }

        private CellState CheckColumns()
        {
            for (int i = 0; i < 3; i++)
            {
                CellState firstCell = this.board[i].CurrentState;
                CellState secondCell = this.board[i + 3].CurrentState;
                CellState ThirdCell = this.board[i + 6].CurrentState;
                if (firstCell == secondCell && secondCell == ThirdCell)
                {
                    return firstCell;
                }
            }
            return CellState.None;
        }


        private CellState CheckRows()
        {
            for (int i = 0; i < 3; i++)
            {
                int indexOfset = i * 3;
                CellState firstCell = this.board[indexOfset].CurrentState;
                CellState secondCell = this.board[indexOfset + 1].CurrentState;
                CellState ThirdCell = this.board[indexOfset + 2].CurrentState;
                if (firstCell == secondCell && secondCell == ThirdCell)
                {
                    return firstCell;
                }
            }
            return CellState.None;
        }

        private CellState CheckDiagnals()
        {
            for (int i = 0; i < 2; i++)
            {
                int indexOfset = i * 2;
                CellState firstCell = this.board[indexOfset].CurrentState;
                CellState secondCell = this.board[4].CurrentState;
                CellState ThirdCell = this.board[8 - indexOfset].CurrentState;
                if (firstCell == secondCell && secondCell == ThirdCell)
                {
                    return firstCell;
                }
            }
            return CellState.None;
        }

        private bool IsFull()
        {
            int i = 0;
            bool hasEmptyCell = false;
            while (i < 9 && !hasEmptyCell)
            {
                if (this.board[i].CurrentState == CellState.None)
                {
                    hasEmptyCell = true;
                }
                i++;
            }
            return !hasEmptyCell;
        }




        public enum GameState
        {
            NotFinished,
            Tie,
            WinnerX,
            WinnerO,
        }
        public enum CellState
        {
            None = ' ',
            X = 'X',
            O = 'O'
        }

        public class TicTacToeCell
        {
            private CellState currentState;

            public CellState CurrentState
            {
                get
                {
                    return currentState;
                }
                private set
                {
                    currentState = value;
                }
            }

            public TicTacToeCell()
            {
                this.currentState = CellState.None;
            }

            public bool PlayCell(CellState newState)
            {
                bool success = false;
                if (this.currentState == CellState.None && newState != CellState.None)
                {
                    this.CurrentState = newState;
                    success = true;
                }
                return success;
            }

        }
    }
}