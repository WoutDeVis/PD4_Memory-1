using Memory.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Memory.Views
{
    public class MemoryBoardView : ViewBaseClass<MemoryBoard>
    {

        [SerializeField] private float _tileSpacing = 10f;
        private PlayerView _player1View;
        public PlayerView Player1View 
        { 
            get => _player1View;
            set
            {
                _player1View = value;
                Model.Player1 = value.Model;
            }

        }

        private PlayerView _player2View;
        public PlayerView Player2View
        {
            get => _player2View;
            set
            {
                _player2View = value;
                Model.Player2 = value.Model;
            }

        }

        public void SetUpMemoryBoardView(MemoryBoard model, GameObject tilePrefab, Material[] materials)
        {
            Model = model;




            float centerX = -(model.Columns - 1) / 2f * _tileSpacing * 2;
            float centerZ = -(model.Rows - 1) / 2f * _tileSpacing * 2;

            // Iterate over all the tiles in the model and spawn a tile prefab for each one
            foreach (Tile tile in Model.Tiles)
            {
                
                
                Vector3 position = new Vector3(tile.Column + centerX, 0, tile.Row + centerZ);

                
                GameObject tileObject = Instantiate(tilePrefab, position, tilePrefab.transform.rotation, this.gameObject.transform);

               
                //tileObject.transform.GetChild(0).GetChild(1).GetComponent<Renderer>().material = materials[tile.MemoryCardId];


                
                TileView tileView = tileObject.GetComponent<TileView>();

                
                tileView.Model = tile;
            }
        }

        private void Update()
        {
                Player1View.Model.Elapsed += Time.deltaTime;
                Player2View.Model.Elapsed += Time.deltaTime; 
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }



    }
}

