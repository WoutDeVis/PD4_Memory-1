using Memory.Models;
using Memory.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    private Animator _animator;
    private TileView _tileView;

    private void Start()
    {
        _tileView = GetComponentInParent<TileView>();
        
        _animator = GetComponent<Animator>();
        AddEvents();
    }

    #region animation events
    private void AddEvents()
    {
        for(int i = 0;i< _animator.runtimeAnimatorController.animationClips.Length; i++)
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
        _tileView.Model.Board.State.TileAnimationEnded(_tileView.Model);
    }
    #endregion

   public void Play(string clipName)
   {
        _animator.Play(clipName);
   }

  
}
