using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : ModelBaseClass
{
    public int Row { get; private set; }
    public int Column { get; private set; }
    public int MemoryCardId 
    {
        get { return MemoryCardId; }
        set 
        {
            MemoryCardId = value;
            OnPropertyChanged();

        }
    }

    public MemoryBoard Board { get; private set; }

    public  Tile(int row, int column, MemoryBoard board)
    {
        Row = row;
        Column = column;
        Board = board;
    }

    public void Flip()
    {
        // Add code here to flip the tile over and show the MemoryCardId
    }

    public void Unflip()
    {
        // Add code here to unflip the tile and hide the MemoryCardId
    }

    public override string ToString()
    {
        return "Tile(" + Row + "," + Column + ")";
    }
}
