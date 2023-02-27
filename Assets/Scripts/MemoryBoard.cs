using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryBoard : ModelBaseClass
{
    public int Rows;
    public int Columns;
    public List<Tile> Tiles = new();
    public List<Tile> PreviewingTiles = new();
    public bool IsCombinationFound
    {
        get
        {
            if (PreviewingTiles.Count == 2 && PreviewingTiles[0].MemoryCardId == PreviewingTiles[1].MemoryCardId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public MemoryBoard(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Tiles = new List<Tile>();
        PreviewingTiles = new List<Tile>();

        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                Tiles.Add(new Tile(row, col, this));
            }
        }

        AssignMemoryCardIds();
    }

    public void AssignMemoryCardIds()
    {
        int numTiles = Tiles.Count;
        List<int> cardIds = new List<int>();

        // Generate cardIds from 0 to numTiles/2-1
        for (int i = 0; i < numTiles / 2; i++)
        {
            cardIds.Add(i);
            cardIds.Add(i);
        }

        // If numTiles is odd, add one more unique cardId
        if (numTiles % 2 != 0)
        {
            cardIds.Add(numTiles / 2);
        }

        // Shuffle the cardIds randomly
        System.Random rng = new System.Random();
        int n = cardIds.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int temp = cardIds[k];
            cardIds[k] = cardIds[n];
            cardIds[n] = temp;
        }

        // Assign the shuffled cardIds to the tiles
        for (int i = 0; i < numTiles; i++)
        {
            Tiles[i].MemoryCardId = cardIds[i];
        }
    }

    public override string ToString()
    {
        return $"MemoryBoard({Rows},{Columns})";
    }
}
