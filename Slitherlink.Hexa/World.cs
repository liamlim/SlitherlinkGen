namespace Slitherlink.Hexa;

public class World<TCell, TEdge>
    where TCell : new()
    where TEdge : new()
{
    // all fields in this block contain information about the world
    private readonly Cell<TCell, TEdge>[][] _cells;
    private readonly Edge<TCell, TEdge>[][] _verticalEdges;
    private readonly Edge<TCell, TEdge>[][] _increasingEdges;
    private readonly Edge<TCell, TEdge>[][] _decreasingEdges;

    // This just makes sure that all internal arrays are allocated to correct sizes
    private void AllocateArrays()
    {
        int middleLineCount = TotalRowsCount;
        int firstLineCount = WorldSize;

        // this for loop handles all indices except the middle one
        for (int i = 0; i < firstLineCount - 1; i++)
        {
            int inverseI = TotalRowsCount - 1 - i;
            _cells[i] = new Cell<TCell, TEdge>[firstLineCount + i];
            _cells[inverseI] = new Cell<TCell, TEdge>[firstLineCount + i];
            _increasingEdges[i] = new Edge<TCell, TEdge>[firstLineCount + i];
            _increasingEdges[inverseI] = new Edge<TCell, TEdge>[firstLineCount + i];
            _decreasingEdges[i] = new Edge<TCell, TEdge>[firstLineCount + i];
            _decreasingEdges[inverseI] = new Edge<TCell, TEdge>[firstLineCount + i];
            _verticalEdges[i] = new Edge<TCell, TEdge>[firstLineCount + i + 1];
            _verticalEdges[inverseI] = new Edge<TCell, TEdge>[firstLineCount + i + 1];
        }

        // now it's time to handle the special case - the middle line
        _cells[firstLineCount] = new Cell<TCell, TEdge>[middleLineCount];
        _increasingEdges[firstLineCount] = new Edge<TCell, TEdge>[middleLineCount];
        _decreasingEdges[firstLineCount] = new Edge<TCell, TEdge>[middleLineCount];
        _increasingEdges[firstLineCount + 1] = new Edge<TCell, TEdge>[middleLineCount];
        _decreasingEdges[firstLineCount + 1] = new Edge<TCell, TEdge>[middleLineCount];
        _verticalEdges[firstLineCount] = new Edge<TCell, TEdge>[middleLineCount + 1];
    }

    private void CreateEdges()
    {
        static void AddEdges(Edge<TCell, TEdge>[][] edges)
        {
            for (int i = 0; i < edges.Length; i++)
            {
                var row = edges[i];
                for (int j = 0; j < row.Length; j++)
                {
                    row[j] = new Edge<TCell, TEdge>
                    {
                        Info = new TEdge()
                    };
                }
            }
        }

        AddEdges(_increasingEdges);
        AddEdges(_decreasingEdges);
        AddEdges(_verticalEdges);
    }

    private void CreateCells()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            var row = _cells[i];
            for (int j = 0; j < row.Length; j++)
            {
                var topLeft = _increasingEdges[i][j];
                var bottomRight = _increasingEdges[i + 1][j];
                var topRight = _decreasingEdges[i][j];
                var bottomLeft = _decreasingEdges[i + 1][j];
                var left = _verticalEdges[i][j];
                var right = _verticalEdges[i][j + 1];

                var cell = new Cell<TCell, TEdge>
                {
                    Info = new TCell(),
                    RowIndex = i,
                    ColumnIndex = j,
                    NorthWestEdge = topLeft,
                    SouthEastEdge = bottomRight,
                    NorthEastEdge = topRight,
                    SouthWestEdge = bottomLeft,
                    WestEdge = left,
                    EastEdge = right
                };

                topLeft.CellOnRightSide = cell;
                topRight.CellOnLeftSide = cell;
                left.CellOnRightSide = cell;
                right.CellOnLeftSide = cell;
                bottomLeft.CellOnRightSide = cell;
                bottomRight.CellOnLeftSide = cell;

                row[j] = cell;
            }
        }
    }

    public World(int worldSize)
    {
        if (worldSize < 0)
        {
            throw new InvalidOperationException("World size can't be negative!");
        }

        WorldSize = worldSize;
        TotalRowsCount = 2 * worldSize - 1;

        _cells = new Cell<TCell, TEdge>[TotalRowsCount][];
        _verticalEdges = new Edge<TCell, TEdge>[TotalRowsCount][];
        _increasingEdges = new Edge<TCell, TEdge>[TotalRowsCount + 1][];
        _decreasingEdges = new Edge<TCell, TEdge>[TotalRowsCount + 1][];

        AllocateArrays();
        CreateEdges();
        CreateCells();
    }

    public int GetCount(int rowIndex)
    {
        int normalizedIndex = rowIndex > WorldSize ? 2 * WorldSize - rowIndex - 1 : rowIndex;

        return WorldSize + normalizedIndex;
    }

    public Cell<TCell, TEdge> GetCell(int rowIndex, int columnIndex)
    {
        return _cells[rowIndex][columnIndex];
    }

    public int WorldSize { get; }
    public int TotalRowsCount { get; }
}
