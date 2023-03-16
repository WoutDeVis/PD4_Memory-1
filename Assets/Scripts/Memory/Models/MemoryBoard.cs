using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Memory.Models
{
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
            List<int> ids = new List<int>();
            for (int i = 0; i < Rows * Columns / 2; i++)
            {
                ids.Add(i);
                ids.Add(i);
            }
            if (Rows * Columns % 2 == 1)
            {
                ids.Add(ids.Count);
            }
            System.Random rng = new System.Random();
            int n = ids.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = ids[k];
                ids[k] = ids[n];
                ids[n] = value;
            }
            int index = 0;
            foreach (Tile tile in Tiles)
            {
                tile.MemoryCardId = ids[index];
                index++;
            }
        }

        public override string ToString()
        {
            return $"MemoryBoard({Rows},{Columns})";
        }
    }
}
