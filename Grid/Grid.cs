using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// A Grid object is a 2D array of GridNode objects. It provides the baseline implementation of the
/// square tile array of nodes that can be overridden by derived classes.
/// 
/// It will also set-up the connections for each node in the Grid. (Only cardinal connections are implemented in this version.)
/// </summary>
public abstract class Grid : MonoBehaviour
{

    public event EventHandler<GridCreationArgs> RaiseGridCreationEvent;

    public enum Direction 
    { 
        up,
        down,
        left,
        right
    };

    public enum ConnectionType
    {
        none,
        cardinal,
        cardinalWithDiagonal 
    };
  
    [SerializeField] private ConnectionType connectionType;
    private GridNode[,] gridNodes;
    public GridNode[,] GridNodes { get { return gridNodes;} }
    [SerializeField] protected GameObject gridNodePrefab;
    public int rows, columns;
    public bool drawGizmoGrid;

    protected virtual void Start()
    {
        gridNodes = new GridNode[columns, rows];
        CreateGrid();
    }

    protected virtual void NotifyCreation()
    {
        OnRaiseGridCreationEvent(new GridCreationArgs(this));
    }

    protected virtual void OnRaiseGridCreationEvent(GridCreationArgs e)
    {
        EventHandler<GridCreationArgs> handler = RaiseGridCreationEvent;
        
        if (handler != null)
        {
            handler(this, e);
        }
    }

    protected virtual void Activate()
    {
    }

    protected virtual void Update()
    {
    }

    protected virtual void OnDrawGizmos()
    {
        if (drawGizmoGrid) IterateOverGridByRow(DrawWireCubesAtNodes);
    }

    protected void DrawWireCubesAtNodes(Vector2 pos)
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(new Vector3(transform.position.x + pos.x, transform.position.y + pos.y, transform.position.z), Vector3.one);
    }

    #region Grid creation
    /// <summary>
    /// Creates the grid with the specified <c>rows</c> and <c>columns</c> by instantiating the linked <c>gridNodePrefab</c> at each position.
    /// Right now the creation of the grid assumes that the nodes will be 1x1x1 in size.
    /// </summary>
    protected void CreateGrid()
    {
        IterateOverGridByRow(CreateNode);
        ConnectGrid();
        NotifyCreation();
    }

    protected void CreateNode(int x, int y)
    {
        GameObject g = (GameObject)Instantiate(gridNodePrefab, new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z), Quaternion.identity);
        
        g.transform.parent = transform;
        gridNodes [x, y] = g.GetComponent<GridNode>();
        gridNodes [x, y].grid = this;
    }

    /// <summary>
    /// Connects the grid based on the selected connection type.
    /// </summary>
    protected void ConnectGrid()
    {
        switch (connectionType)
        {
            case ConnectionType.cardinal:
                for (int x = 0; x < rows; x++)
                {
                    for (int y = 0; y < columns; y++)
                    {
                        GridNode currentNode = gridNodes [x, y];
                        ConnectGridNode(ref currentNode, x, y, x - 1, y, Direction.left);
                        ConnectGridNode(ref currentNode, x, y, x + 1, y, Direction.right);
                        ConnectGridNode(ref currentNode, x, y, x, y + 1, Direction.up);
                        ConnectGridNode(ref currentNode, x, y, x, y - 1, Direction.down);
                    }
                }
                break;
      
            case ConnectionType.cardinalWithDiagonal:

                break;
      
            case ConnectionType.none:

                break;

            default:

                break;
        }
    }

    private GridNode ConnectGridNode<T>(ref T gridNode, int fromRow, int fromColumn, int targetRow, int targetColumn, Direction directionOfConnection) where T : GridNode
    {
        GridNode targetGridNode;
        GridNode fromNode = gridNode as GridNode;

        if (fromRow == targetRow && fromColumn == targetColumn)
        {
            return null;
        }

        if (targetRow > rows - 1 || targetColumn > rows - 1 || targetRow < 0 || targetColumn < 0)
        {
            return null;
        }

        if (gridNodes [targetRow, targetColumn] != null)
        {
            targetGridNode = gridNodes [targetRow, targetColumn];
            fromNode.AddConnection(directionOfConnection, targetGridNode);
            return targetGridNode;
        } 
        else
        {
            return null;
        }
    }
    #endregion

    protected void MoveGridInWorldSpace()
    {
        int yDelta = 0;
        int xDelta = 0;
        if (Input.GetButtonDown("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                yDelta = 1;
            } else
            {
                yDelta = -1;
            }
        }
        
        if (Input.GetButtonDown("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                xDelta = 1;
            } else
            {
                xDelta = -1;
            }
        }
        
        transform.position = new Vector3(transform.position.x + xDelta, transform.position.y + yDelta, 0);
        
    }

    #region Utiities & Queries
    public bool IsNodeOccupied(int x, int y)
    {
        if (gridNodes [x, y].contents != null)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }

    public GridNode GetGridNodeAtWorldCoordinate(Vector3 pos)
    {
        foreach (GridNode g in gridNodes)
        {
            if (g.transform.position.x == pos.x && g.transform.position.y == pos.y)
            {
                return g;
            }
        }
        return null;
    }

    protected void IterateOverGridByRow(Action<GridNode> methodToInvoke)
    {
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                methodToInvoke(gridNodes[x, y]);
            }
        }
    }

    protected void IterateOverGridByRow(Action<Vector2> methodToInvoke)
    {
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                methodToInvoke(new Vector2(x, y));
            }
        }
    }

    protected void IterateOverGridByRow(Action<int, int> methodToInvoke)
    { 
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                methodToInvoke(x, y);
            }
        }
    }
    #endregion
}