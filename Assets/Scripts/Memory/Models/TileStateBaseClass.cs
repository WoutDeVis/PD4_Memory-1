using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Memory.Models
{
    public abstract class TileStateBaseClass : ITileState
    {
        public Tile Tile { get; set; }

        public abstract TileStates State { get; }

        public TileStateBaseClass(Tile tile)
        {
            Tile = tile;
        }
    }
}

