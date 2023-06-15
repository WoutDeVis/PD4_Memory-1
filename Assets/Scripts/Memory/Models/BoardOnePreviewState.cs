using Memory.Data;
using Memory.Models;
using Memory.Models.States;
using System;
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
                {
                    ++Board.Player1.Score;
                    ImageRepository.Instance.AddScore(Board.Player1.Name, Board.Player1.Score, (int)Board.Player1.Elapsed);
                }
                else
                {
                    ++Board.Player2.Score;
                    ImageRepository.Instance.AddScore(Board.Player2.Name, Board.Player2.Score, (int)Board.Player2.Elapsed);
                }
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