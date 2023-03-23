using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models
{
    public abstract class BoardStateBaseClass : IBoardState
    {
        public MemoryBoard Board { get; }
        public abstract BoardStates State { get; }

        protected BoardStateBaseClass(MemoryBoard board)
        {
            Board = board;
        }

        public abstract void AddPreview(Tile tile);

        public abstract void TileAnimationEnded(Tile tile);
    }
}
