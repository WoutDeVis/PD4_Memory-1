using Memory.Data;
using Memory.Models;
using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Memory.Models
{
    public class BoardOnePreviewState : BoardStateBaseClass
    {
        public BoardOnePreviewState(MemoryBoard board) : base(board) { }


        public override BoardStates State => BoardStates.OnePreview;

        public override void AddPreview(Tile tile)
        {
            if (tile.State.State != TileStates.Hidden)
            {
                return;
            }

            tile.Board.PreviewingTiles.Add(tile);

            if (tile.Board.IsCombinationFound)
            {

                if (Board.Player1.IsActive)
                    Board.Player1.Score++;
                else
                    Board.Player2.Score++;

                ImageRepository.Instance.AddCombination(tile.MemoryCardId);
                tile.Board.State = new BoardTwoFoundState(tile.Board);
                tile.State = new TileFoundState(tile);
                tile.Board.PreviewingTiles[0].State = new TileFoundState(tile.Board.PreviewingTiles[0]);
               

            }
            else
            {
                tile.Board.State = new BoardTwoPreviewState(tile.Board);
                tile.State = new TilePreviewState(tile);
            }
        }

        public override void TileAnimationEnded(Tile tile)
        {
            // Do nothing
        }
    }
}