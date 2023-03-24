using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models
{
    public class Player : ModelBaseClass
    {
        private string _name;
        private int _score;
        private bool _isActive;
        private float _elapsed;

        public Player() { }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Score
        {
            get { return _score; }
            set
            {
                if (_score != value)
                {
                    _score = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    OnPropertyChanged();
                }
            }
        }

        public float Elapsed
        {
            get { return _elapsed; }
            set
            {
                if (_elapsed != value && IsActive)
                {
                    _elapsed = value;
                    OnPropertyChanged();
                }
            }
        }

        public int MM => (int)(Elapsed / 60);
        public int SS => (int)(Elapsed % 60);
        public int MS => (int)((Elapsed % 1) * 1000);



    }
}

