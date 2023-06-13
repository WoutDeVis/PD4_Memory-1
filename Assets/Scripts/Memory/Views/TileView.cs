using Memory.Data;
using Memory.Models;
using Memory.Models.States;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Memory.Views
{
    public class TileView : ViewBaseClass<Tile>, IPointerDownHandler
    {
        private Animator _animator;
        private Card _card;

        private void Start()
        {
            // _card = GetComponentInChildren<Card>();


            _animator = GetComponentInChildren<Animator>();
            AddEvents();
        }

        #region animation events
        private void AddEvents()
        {
            for (int i = 0; i < _animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                AnimationClip clip = _animator.runtimeAnimatorController.animationClips[i];


                AnimationEvent animationStartEvent = new AnimationEvent();
                animationStartEvent.time = 0;
                animationStartEvent.functionName = "AnimationStartHandler";
                animationStartEvent.stringParameter = clip.name;

                AnimationEvent animationEndEvent = new AnimationEvent();
                animationEndEvent.time = clip.length;
                animationEndEvent.functionName = "AnimationCompletedHandler";
                animationEndEvent.stringParameter = clip.name;

                clip.AddEvent(animationStartEvent);
                clip.AddEvent(animationEndEvent);
            }
        }

        public void AnimationStartHandler(string name)
        {

        }

        public void AnimationCompletedHandler(string name)
        {

            Model.Board.State.TileAnimationEnded(Model);

        }
        #endregion

        public void OnPointerDown(PointerEventData eventData)
        {
          
          
            Model.Board.State.AddPreview(Model);

        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
            if (e.PropertyName.Equals(nameof(Model.State)))
                StartAnimation();
            else if (e.PropertyName.Equals(nameof(Model.MemoryCardId)))
                LoadFront();

        }

        private void LoadFront()
        {
            ImageRepository.Instance.GetProcessTexture(Model.MemoryCardId, LoadFront);
        }
        private void LoadFront(Texture2D texture)
        {
            //gameObject.transform.Find("Front").GetComponent<Renderer>().material.mainTexture = texture;

            //Transform transform = gameObject.transform.Find("Front");
            //Debug.Log(transform.name + "  " + transform.position);

            //transform.GetComponent<Renderer>().material.mainTexture = texture;

            gameObject.transform.GetChild(0).GetChild(1).GetComponent<Renderer>().material.mainTexture = texture;

        }

        private void StartAnimation()
        {
           
            if (Model.State.State == TileStates.Preview || Model.State.State == TileStates.Found)
            {
                _animator.Play("Shown");
            }
            else if (Model.State.State == TileStates.Hidden)
            {
                _animator.Play("Hidden");
            }

        }
    }
}
