using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Memory.Models
{
    public class Tile : ModelBaseClass
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        private int _memoryCardId = 0;
        public int MemoryCardId
        {
            get { return _memoryCardId; }
            set
            {
                _memoryCardId = value;
                OnPropertyChanged();
            }
        }

        public MemoryBoard Board { get; private set; }

        private ITileState _state;
        public ITileState State
        {
            get { return _state; }
            set
            {
                _state = value;
                _state.Tile = this;
                OnPropertyChanged();
            }
        }

        public Tile(int row, int column, MemoryBoard board)
        {
            Row = row;
            Column = column;
            Board = board;
            State = new TileHiddenState(this);
        }

        public override string ToString()
        {
            return "Tile(" + Row + "," + Column + ")";
        }
    }
}


   

