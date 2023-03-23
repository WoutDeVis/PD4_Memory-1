
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
        [SerializeField]
        private Material[] _materials;





        // Start is called before the first frame update
        void Start()
        {
            _board = new MemoryBoard(3, 3);

            _memoryBoard.GetComponent<MemoryBoardView>().SetUpMemoryBoardView(_board, _tilePrefab,_materials);

        }

    




    }
}
