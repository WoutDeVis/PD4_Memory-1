using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models
{
    public class TileHiddenState : TileStateBaseClass
    {

        public TileHiddenState(Tile tile) : base(tile) { }

        public override TileStates State => TileStates.Hidden;
    }
}

