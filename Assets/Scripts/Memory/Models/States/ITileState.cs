using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public interface ITileState
    {
        TileStates State { get; }
        Tile Tile { get; set; }
    }
}