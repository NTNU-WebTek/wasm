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

        public TicTacToeCell GetCell(int index)
        {
            return this.board[index];
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
            if (this.State == GameState.NotFinished)
            {
                next = isXNext ? CellState.X : CellState.O;
            }
            return next;
        }

        private void CheckForWinner()
        {
            TicTacToeCell[] winnerCells = CheckColumns();
            if (winnerCells.Length == 0)
            {
                winnerCells = this.CheckRows();
            }

            if (winnerCells.Length == 0)
            {
                winnerCells = this.CheckDiagnals();
            }

            if (winnerCells.Length > 0)
            {
                foreach (TicTacToeCell cell in winnerCells)
                {
                    cell.IsWinningCell = true;
                }
                if (winnerCells[0].CurrentState == CellState.X)
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

        private TicTacToeCell[] CheckColumns()
        {
            for (int i = 0; i < 3; i++)
            {
                TicTacToeCell firstCell = this.board[i];
                TicTacToeCell secondCell = this.board[i + 3];
                TicTacToeCell ThirdCell = this.board[i + 6];
                if (IsWInningTriple(firstCell, secondCell, ThirdCell))
                {

                    return new TicTacToeCell[] { firstCell, secondCell, ThirdCell };
                }
            }
            return Array.Empty<TicTacToeCell>();
        }


        private TicTacToeCell[] CheckRows()
        {
            for (int i = 0; i < 3; i++)
            {
                int indexOfset = i * 3;
                TicTacToeCell firstCell = this.board[indexOfset];
                TicTacToeCell secondCell = this.board[indexOfset + 1];
                TicTacToeCell ThirdCell = this.board[indexOfset + 2];
                if (IsWInningTriple(firstCell, secondCell, ThirdCell))
                {
                    return new TicTacToeCell[] { firstCell, secondCell, ThirdCell };
                }
            }
            return Array.Empty<TicTacToeCell>();
        }

        private TicTacToeCell[] CheckDiagnals()
        {
            for (int i = 0; i < 2; i++)
            {
                int indexOfset = i * 2;
                TicTacToeCell firstCell = this.board[indexOfset];
                TicTacToeCell secondCell = this.board[4];
                TicTacToeCell ThirdCell = this.board[8 - indexOfset];
                if (IsWInningTriple(firstCell, secondCell, ThirdCell))
                {
                    return new TicTacToeCell[] { firstCell, secondCell, ThirdCell };
                }
            }
            return Array.Empty<TicTacToeCell>();
        }

        private static bool IsWInningTriple(TicTacToeCell first, TicTacToeCell second, TicTacToeCell third)
        {
            return first.CurrentState != CellState.None
            && first.CurrentState == second.CurrentState
            && second.CurrentState == third.CurrentState;
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
        public bool IsWinningCell { get; set; }

        public CellState CurrentState { get; private set; }

        public TicTacToeCell()
        {
            this.CurrentState = CellState.None;
        }

        public bool PlayCell(CellState newState)
        {
            bool success = false;
            if (this.CurrentState == CellState.None && newState != CellState.None)
            {
                this.CurrentState = newState;
                success = true;
            }
            return success;
        }

    }

}