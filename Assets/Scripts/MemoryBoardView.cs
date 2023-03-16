using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MemoryBoardView :  ViewBaseClass <MemoryBoard>
{




    public void SetUpMemoryBoardView(MemoryBoard model, GameObject tilePrefab)
    {
        Model = model;

        foreach (Tile tile in Model.Tiles)
        {
           
            Vector3 position = new Vector3(tile.Column, 0, tile.Row);

            // Instantiate the tilePrefab using the executing MemoryBoardView's gameObject as parent
            GameObject tileObject = Instantiate(tilePrefab, position, Quaternion.identity, this.gameObject.transform);

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
