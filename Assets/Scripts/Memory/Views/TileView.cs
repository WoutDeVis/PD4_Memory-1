using Memory.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Memory.Views
{
    public class TileView : ViewBaseClass<Tile>, IPointerDownHandler
    {


        public void OnPointerDown(PointerEventData eventData)
        {

        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }


    }
}
