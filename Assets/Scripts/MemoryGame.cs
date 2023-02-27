using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGame : MonoBehaviour
{
    private MemoryBoard _board;
    private float _currentTime;




    // Start is called before the first frame update
    void Start()
    {
        _board = new MemoryBoard(3, 3);

        Tile tile = _board.Tiles[Random.Range(0, _board.Tiles.Count)];
        tile.PropertyChanged += Tile_PropertyChanged;
    }

    private void Tile_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        Debug.Log($"Tile property '{e.PropertyName}' changed: {sender.ToString()}");
    }




    void Update()
    {
       
        _currentTime += Time.deltaTime;

        if (_currentTime > 2)
        {
            foreach (var tile in _board.Tiles)
            {
                tile.MemoryCardId++;
            }
            _currentTime -= 2;
        }
    }
}
