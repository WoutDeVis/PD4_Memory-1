using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Memory.Models
{
    public class BoardFinishedState : BoardStateBaseClass
    {
        public BoardFinishedState(MemoryBoard board) : base(board) { }
        

        public override BoardStates State => BoardStates.Finished;

        public override void AddPreview(Tile tile)
        {
           
        }

        public override void TileAnimationEnded(Tile tile)
        {
           
        }
    }
}