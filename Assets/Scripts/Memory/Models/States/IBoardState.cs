using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public interface IBoardState
    {
        BoardStates State { get; }
        MemoryBoard Board { get; }
        void AddPreview(Tile tile);
        void TileAnimationEnded(Tile tile);
    }
}
