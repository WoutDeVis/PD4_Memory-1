using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Memory.Models
{
    public class BoardTwoHidingState : BoardStateBaseClass
    {
        public BoardTwoHidingState(MemoryBoard board) : base(board) { }
        

        public override BoardStates State => BoardStates.TwoHidden;

        public override void AddPreview(Tile tile)
        {
           
        }

        public override void TileAnimationEnded(Tile tile)
        {
            Board.PreviewingTiles.Remove(tile);

            if(Board.PreviewingTiles.Count == 0)
            {
                Board.ToggleActivePlayer();
                Board.State = new BoardNoPreviewState(Board);
            }


        }

  
    }
}