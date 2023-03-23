using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models
{
    public class TileFoundState : TileStateBaseClass
    {
        public TileFoundState(Tile tile) : base(tile) { }

        public override TileStates State { get { return TileStates.Found; } }
    }
}
