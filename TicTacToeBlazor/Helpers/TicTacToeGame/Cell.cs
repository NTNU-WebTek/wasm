namespace TicTacToeBlazor.Helpers.TicTacToeGame
{
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