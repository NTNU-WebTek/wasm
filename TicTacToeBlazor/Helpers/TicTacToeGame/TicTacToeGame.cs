namespace TicTacToeBlazor.Helpers.TicTacToeGame
{

    /// <summary>
    ///  The state of tic-tac-toe game.
    /// </summary>
    public enum GameState
    {
        NotFinished,
        Tie,
        WinnerX,
        WinnerO,
    }
    /// <summary>
    /// Represents a tic-tac-toe game.
    /// </summary>
    /// <remarks>
    /// The game is played on a 3 by 3 grid of cells, stored in a one-dimensional array.
    /// (First three cells are the first row, etc.)
    /// </remarks>
    public class TicTacToeGame
    {
        /// <summary>
        /// Gets the current state of the game.
        /// </summary>
        public GameState State { get; private set; }
        private bool isXNext;
        private readonly TicTacToeCell[] board;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicTacToeGame"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets the cell at the specified index.
        /// </summary>
        /// <remarks>
        /// The cells are stored in a one-dimensional array.
        /// (First three cells are the first row, etc.)
        /// Valid indexes are 0 through 8.
        /// </remarks>
        /// <param name="index">index of the cell to return</param>
        /// <returns>cell at given index</returns>
        public TicTacToeCell GetCell(int index)
        {
            return this.board[index];
        }


        /// <summary>
        /// Gets all cells.
        /// </summary>
        /// <remarks>
        /// The cells are stored in a one-dimensional array.
        /// (First three cells are the first row, etc.)
        /// </remarks>
        /// <returns>All cells. Indexed 0 through 8</returns>
        public TicTacToeCell[] GetCells()
        {
            return this.board;
        }

        /// <summary>
        /// Plays the cell at the specified index.
        /// </summary>
        /// <remarks>
        /// The cells are stored in a one-dimensional array.
        /// (First three cells are the first row, etc.)
        /// Valid indexes are 0 through 8.
        /// </remarks>
        /// <param name="index">index of the cell to play</param>
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


        /// <summary>
        /// Resets the game to its initial state, i.e. all cells are empty, X starts and state is NotFinished.
        /// </summary>
        public void ResetGame()
        {
            this.State = GameState.NotFinished;
            this.isXNext = true;
            this.FillBoard();
        }

        /// <summary>
        /// Returns the <see cref="CellState"/> corresponding to the next move (X or O).
        /// If the game is finished, returns CellState.None.
        /// </summary>
        /// <remarks>
        /// This is useful for displaying the next move to the user.
        /// </remarks>
        /// <returns></returns>
        public CellState NextMove()
        {
            CellState next = CellState.None;
            if (this.State == GameState.NotFinished)
            {
                next = isXNext ? CellState.X : CellState.O;
            }
            return next;
        }

        /// <summary>
        /// Checks if the game is finished and updates the State property accordingly.
        /// </summary>
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

            // There is a winner
            if (winnerCells.Length > 0)
            {
                // Mark the winning cells
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

        /// <summary>
        /// Checks if the three cells are all X or all O.
        /// </summary>
        private static bool IsWInningTriple(TicTacToeCell first, TicTacToeCell second, TicTacToeCell third)
        {
            return first.CurrentState != CellState.None
            && first.CurrentState == second.CurrentState
            && second.CurrentState == third.CurrentState;
        }

        /// <summary>
        /// Checks if the board is full.
        /// </summary>
        /// <returns>true if the board is full, false otherwise</returns>
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
}