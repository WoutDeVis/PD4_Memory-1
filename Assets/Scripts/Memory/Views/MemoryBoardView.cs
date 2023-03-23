using Memory.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Memory.Views
{
    public class MemoryBoardView : ViewBaseClass<MemoryBoard>
    {




        public void SetUpMemoryBoardView(MemoryBoard model, GameObject tilePrefab, Material[] materials)
        {
            Model = model;

            foreach (Tile tile in Model.Tiles)
            {

                Vector3 position = new Vector3(tile.Column, 0, tile.Row);

                // Instantiate the tilePrefab using the executing MemoryBoardView's gameObject as parent
                GameObject tileObject = Instantiate(tilePrefab, position, tilePrefab.transform.rotation, this.gameObject.transform);

                //Debug.Log(tile.MemoryCardId);
                tileObject.transform.GetChild(0).GetChild(1).GetComponent<Renderer>().material = materials[tile.MemoryCardId];


                // Get the TileView component from the instantiated GameObject
                TileView tileView = tileObject.GetComponent<TileView>();

                // Assign the tile as the Model of the TileView component
                tileView.Model = tile;
            }
        }


        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }



    }
}

