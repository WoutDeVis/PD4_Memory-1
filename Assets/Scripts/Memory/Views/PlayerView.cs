using Memory.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

namespace Memory.Views
{
    public class PlayerView : ViewBaseClass<Player>
    {
        [SerializeField] private Text playerNameText;
        [SerializeField] private Text playerScoreText;
        [SerializeField] private Text playerElapsedText;


        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Name")
            {
                playerNameText.text = Model.Name;
             
            }
            if (e.PropertyName == "Score")
            {
                playerScoreText.text = $"Score: {Model.Score}";
            }
            if (e.PropertyName == "Elapsed")
            {
                playerElapsedText.text = $"{Model.MM}:{Model.SS}:{Model.MS}";


                //Diffrent solution
                //TimeSpan timeSpan = TimeSpan.FromSeconds(Model.Elapsed);
                //string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}",
                //    timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
                //playerElapsedText.text = elapsedTime;
            }
            if (e.PropertyName == "IsActive")
            {
                if (Model.IsActive)
                    playerNameText.color = Color.red;
                else
                    playerNameText.color = Color.white;
            }
        }
    }
}
