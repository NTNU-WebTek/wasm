namespace TicTacToeBlazor.Helpers.TicTacToeGame
{
    /// <summary>
    /// Possible states of a cell in a tic-tac-toe game.
    /// </summary>
    public enum CellState
    {
        None = ' ',
        X = 'X',
        O = 'O'
    }
    /// <summary>
    /// Represents a cell in a tic-tac-toe game.
    /// </summary>
    public class TicTacToeCell
    {
        /// <summary>
        /// Gets or sets a value indicating whether this cell is part of a winning line.
        /// </summary>
        public bool IsWinningCell { get; set; }

        /// <summary>
        /// Gets the current state of the cell.
        /// </summary>
        public CellState CurrentState { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TicTacToeCell"/> class.
        /// </summary>
        /// <remarks>
        /// The cell is initialized with the <see cref="CellState.None"/> state.
        /// </remarks>
        public TicTacToeCell()
        {
            this.CurrentState = CellState.None;
        }

        /// <summary>
        /// Plays the cell with the specified state.
        /// </summary>
        /// <param name="newState">The new state of the cell. Must be different from <see cref="CellState.None"/>.</param>
        /// <returns>True if the cell was successfully played, false otherwise.</returns>
        /// <remarks>
        /// If the cell is already played, the method does nothing and returns false.
        /// If parameter <paramref name="newState"/> is <see cref="CellState.None"/>, the method does nothing and returns false.
        /// </remarks>
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