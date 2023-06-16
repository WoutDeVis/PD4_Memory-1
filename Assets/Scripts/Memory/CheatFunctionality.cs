using Codice.CM.Client.Differences;
using Memory.Data;
using Memory.Models;
using Memory.Models.States;
using Memory.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory
{
    public class CheatFunctionality : MonoBehaviour
    {
        private MemoryBoardView _memoryBoardView; 
        private void Start()
        {
           _memoryBoardView = FindObjectOfType<MemoryBoardView>();
        }

        public void CheatButtonPressed()
        {
            var model = _memoryBoardView.Model;

            if(model.State.State == BoardStates.OnePreview)
            {
                for (int i = 0; i < _memoryBoardView.Model.Tiles.Count; i++)
                {
                   if( model.PreviewingTiles[0].MemoryCardId == model.Tiles[i].MemoryCardId)
                    {
                        model.Tiles[i].Board.State.AddPreview(model.Tiles[i]);
                        break; 
                    }
                }
            }
        }
    }
}
