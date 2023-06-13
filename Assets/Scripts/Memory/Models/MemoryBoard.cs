using Memory.Data;
using Memory.Models.States;
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

        public Player Player1;
        public Player Player2;

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

        public IBoardState State { get; set; }

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

            State = new BoardNoPreviewState(this);
        }

        public void ToggleActivePlayer()
        {
            Player1.IsActive = !Player1.IsActive;
            Player2.IsActive = !Player2.IsActive;
        }

        private void AssignMemoryCardIds()
        {
            ImageRepository repo = ImageRepository.Instance;
            repo.ProccesImageIds(AssignMemoryCardIds);
        }
        private void AssignMemoryCardIds(List<int> memoryCardIds)
        {
            memoryCardIds.Shuffle();
            Tiles.Shuffle();
            List<Tile> shuffleTiles = Tiles;
            int memoryCardIndex = 0;
            bool first = true;
            foreach(Tile tile in shuffleTiles)
            {
                tile.MemoryCardId = memoryCardIds[memoryCardIndex];
                if (first)
                {

                    first = false;
                }
                else
                {
                    memoryCardIndex++;
                    first = true;
                }
            }
           
        }


        //public void AssignMemoryCardIds()
        //{
        //    List<int> ids = new List<int>();
        //    for (int i = 0; i < Tiles.Count / 2; i++)
        //    {
        //        ids.Add(i);
        //        ids.Add(i);
        //    }
        //    if (Tiles.Count % 2 == 1)
        //    {
        //        ids.Add((int)Mathf.Floor(Tiles.Count / 2));
        //    }
        //    System.Random rng = new System.Random();
        //    int n = ids.Count;
        //    while (n > 1)
        //    {
        //        n--;
        //        int k = rng.Next(n + 1);
        //        int value = ids[k];
        //        ids[k] = ids[n];
        //        ids[n] = value;
        //    }
        //    int index = 0;
        //    foreach (Tile tile in Tiles)
        //    {
        //        tile.MemoryCardId = ids[index];
        //        index++;

        //        Debug.Log(tile.MemoryCardId);
        //    }
        //}

        public override string ToString()
        {
            return $"MemoryBoard({Rows},{Columns})";
        }





    }


    public static class ListExtensions
    {
        private static System.Random random = new System.Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }


}

