using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models
{
    public class BoardNoPreviewState : BoardStateBaseClass 
    {
        public BoardNoPreviewState(MemoryBoard board) : base(board) { }

        public override BoardStates State => BoardStates.NoPreview;

        public override void AddPreview(Tile tile)
        {
            if (tile.State.State != TileStates.Hidden)
            {
                return;
            }

            tile.State = new TilePreviewState(tile);
            tile.Board.PreviewingTiles.Add(tile);
            tile.Board.State = new BoardOnePreviewState(tile.Board);

            
        }

        public override void TileAnimationEnded(Tile tile)
        {
            // Do nothing
        }
    }
}

