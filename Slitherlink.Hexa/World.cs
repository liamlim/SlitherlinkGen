﻿namespace Slitherlink.Hexa;

public class World<TCell, TEdge>
    where TCell : notnull, new()
    where TEdge : notnull, new()
{
    // all fields in this block contain information about the world
    private readonly Cell<TCell, TEdge>[][] _cells;
    private readonly Edge<TCell, TEdge>[][] _verticalEdges;
    private readonly Edge<TCell, TEdge>[][] _edgesToNorthEast;
    private readonly Edge<TCell, TEdge>[][] _edgesToSouthEast;

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
            _edgesToNorthEast[i] = new Edge<TCell, TEdge>[firstLineCount + i];
            _edgesToNorthEast[inverseI + 1] = new Edge<TCell, TEdge>[firstLineCount + i];
            _edgesToSouthEast[i] = new Edge<TCell, TEdge>[firstLineCount + i];
            _edgesToSouthEast[inverseI + 1] = new Edge<TCell, TEdge>[firstLineCount + i];
            _verticalEdges[i] = new Edge<TCell, TEdge>[firstLineCount + i + 1];
            _verticalEdges[inverseI] = new Edge<TCell, TEdge>[firstLineCount + i + 1];
        }

        // now it's time to handle the special case - the middle line
        _cells[firstLineCount - 1] = new Cell<TCell, TEdge>[middleLineCount];
        _edgesToNorthEast[firstLineCount - 1] = new Edge<TCell, TEdge>[middleLineCount];
        _edgesToSouthEast[firstLineCount - 1] = new Edge<TCell, TEdge>[middleLineCount];
        _edgesToNorthEast[firstLineCount] = new Edge<TCell, TEdge>[middleLineCount];
        _edgesToSouthEast[firstLineCount] = new Edge<TCell, TEdge>[middleLineCount];
        _verticalEdges[firstLineCount - 1] = new Edge<TCell, TEdge>[middleLineCount + 1];
    }

    // Creates instances of all objects representing edges
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

        AddEdges(_edgesToNorthEast);
        AddEdges(_edgesToSouthEast);
        AddEdges(_verticalEdges);
    }

    // Creates instances of all objects representing cells
    private void CreateCells()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            var row = _cells[i];
            for (int j = 0; j < row.Length; j++)
            {
                var northWest = _edgesToNorthEast[i][j];
                var southEast = _edgesToNorthEast[i + 1][j];
                var northEast = _edgesToSouthEast[i][j];
                var southWest = _edgesToSouthEast[i + 1][j];
                var west = _verticalEdges[i][j];
                var east = _verticalEdges[i][j + 1];

                var cell = new Cell<TCell, TEdge>
                {
                    Info = new TCell(),
                    NorthWestEdge = northWest,
                    SouthEastEdge = southEast,
                    NorthEastEdge = northEast,
                    SouthWestEdge = southWest,
                    WestEdge = west,
                    EastEdge = east
                };

                northWest.CellOnEast = cell;
                northEast.CellOnWest = cell;
                west.CellOnEast = cell;
                east.CellOnWest = cell;
                southWest.CellOnEast = cell;
                southEast.CellOnWest = cell;

                row[j] = cell;
            }
        }
    }

    /// <summary>
    /// Public constructor taking non-negative world size as an input and creating an instance of empty world.
    /// </summary>
    public World(int worldSize)
    {
        if (worldSize <= 0)
        {
            throw new InvalidOperationException("World size need to be greater than 0");
        }

        WorldSize = worldSize;
        TotalRowsCount = 2 * worldSize - 1;

        _cells = new Cell<TCell, TEdge>[TotalRowsCount][];
        _verticalEdges = new Edge<TCell, TEdge>[TotalRowsCount][];
        _edgesToNorthEast = new Edge<TCell, TEdge>[TotalRowsCount + 1][];
        _edgesToSouthEast = new Edge<TCell, TEdge>[TotalRowsCount + 1][];

        AllocateArrays();
        CreateEdges();
        CreateCells();
    }

    /// <summary>
    /// Gets the total number of cells of the row on the given index.
    /// </summary>
    public int GetCellCount(int rowIndex)
    {
        int normalizedIndex = rowIndex > WorldSize ? 2 * WorldSize - rowIndex - 1 : rowIndex;

        return WorldSize + normalizedIndex;
    }

    /// <summary>
    /// Gets the object representing the cell on specified coordinates.
    /// </summary>
    public Cell<TCell, TEdge> GetCell(int rowIndex, int columnIndex)
    {
        return _cells[rowIndex][columnIndex];
    }

    /// <summary>
    /// Number of cells on each of 6 sides of the hexa shaped world.
    /// </summary>
    public int WorldSize { get; }

    /// <summary>
    /// Number of horizontal rows containing a sequence of cells.
    /// </summary>
    public int TotalRowsCount { get; }
}
