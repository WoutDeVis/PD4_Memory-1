
using Memory.Models;
using Memory.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Memory
{
    public class MemoryGame : MonoBehaviour
    {
        private MemoryBoard _board;
        [SerializeField]
        private GameObject _tilePrefab;
        [SerializeField]
        private GameObject _memoryBoard;





        private float _currentTime;




        // Start is called before the first frame update
        void Start()
        {
            _board = new MemoryBoard(3, 3);

            _memoryBoard.GetComponent<MemoryBoardView>().SetUpMemoryBoardView(_board, _tilePrefab);

            //Tile tile = _board.Tiles[Random.Range(0, _board.Tiles.Count)];
            //tile.PropertyChanged += Tile_PropertyChanged;
        }

        //private void Tile_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    Debug.Log($"Tile property '{e.PropertyName}' changed: {sender.ToString()}");
        //}




    }
}
