
using Memory.Models;
using Memory.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Memory
{
    public class MemoryGame : MonoBehaviour
    {
        public string Player1Name;
        public string Player2Name;

        private MemoryBoard _board;
        [SerializeField]
        private GameObject _tilePrefab;
        [SerializeField]
        private GameObject _memoryBoard;
        [SerializeField]
        private Material[] _materials;
        [SerializeField]
        private GameObject _playerViewPrefab;
        
        [SerializeField]
        private GameObject _player1;
        [SerializeField]
        private GameObject _player2;




        // Start is called before the first frame update
        void Start()
        {
            Player player1 = new Player();
            Player player2 = new Player();
           
            _player1.GetComponent<PlayerView>().Model = player1;
            player1.IsActive = true;
            player1.Name = Player1Name;
            

            _player2.GetComponent<PlayerView>().Model = player2;
            player2.IsActive = false;
            player2.Name = Player2Name;
           





            _board = new MemoryBoard(3, 3);

            _memoryBoard.GetComponent<MemoryBoardView>().SetUpMemoryBoardView(_board, _tilePrefab,_materials);
            _memoryBoard.GetComponent<MemoryBoardView>().Player1View = _player1.GetComponent<PlayerView>();
            _memoryBoard.GetComponent<MemoryBoardView>().Player2View = _player2.GetComponent<PlayerView>();
        }

    




    }
}
