using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



namespace Memory.Models
{
    public class BoardTwoFoundState : BoardStateBaseClass
    {
        public BoardTwoFoundState(MemoryBoard board) : base(board) { }

        public override BoardStates State => BoardStates.TwoFound;

        public override void AddPreview(Tile tile)
        {
            // Empty body
        }

        public override void TileAnimationEnded(Tile tile)
        {
            Board.PreviewingTiles.Remove(tile);

            if (Board.PreviewingTiles.Count == 0)
            {
                if (Board.Tiles.Where(t => t.State.State == TileStates.Hidden).Count() < 2)

                {
                    Board.State = new BoardFinishedState(Board);
                    
                }
                else
                {
                    Board.State = new BoardNoPreviewState(Board);
                }
            }
        }
    }
}