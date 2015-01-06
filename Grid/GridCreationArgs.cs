using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Custom EventArgs class that contains information relevant to grid creation.
/// Currently the only relevant data is a reference to the grid.
/// http://msdn.microsoft.com/en-us/library/awbftdfh.aspx
/// </summary>
public class GridCreationArgs : EventArgs
{
    public GridCreationArgs(Grid _grid, string message = "")
    {
        grid = _grid;
    }
    
    private Grid grid;
    private string msg;
    
    public Grid NewGrid { get { return grid; } }
    public string Message { get { return msg; } }
}
