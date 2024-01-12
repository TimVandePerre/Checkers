namespace Checkers.Model
{
    public class BoardModel
    {
        public int Row { get; }
        public int Column { get; }

        public BoardModel(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
