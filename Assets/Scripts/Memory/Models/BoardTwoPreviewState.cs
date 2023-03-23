using Memory.Models;
using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Memory.Models
{
    public class BoardTwoPreviewState : BoardStateBaseClass
    {
        public BoardTwoPreviewState(MemoryBoard board) : base(board) { }

        // Start is called before the first frame update
        public override BoardStates State => BoardStates.TwoPreview;

        public override void AddPreview(Tile tile)
        {
            
        }

        public override void TileAnimationEnded(Tile tile)
        {
            if (tile.Board.PreviewingTiles.Count == 2 && tile.Board.PreviewingTiles[1] == tile)
            {
                // Both tiles ended the preview animation and should both be hidden again
                tile.State = new TileHiddenState(tile);
                tile.Board.PreviewingTiles[0].State = new TileHiddenState(tile.Board.PreviewingTiles[0]);
                tile.Board.State = new BoardTwoHidingState(tile.Board);
            }
        }
    }
}
