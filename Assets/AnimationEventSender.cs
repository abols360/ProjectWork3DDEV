using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventSender : MonoBehaviour
{
    // Start is called before the first frame update


    GameHeroController _heroController;
    private void Start() {
        _heroController =  GetComponentInParent<GameHeroController>();
    }
     public void OnFootstep(AnimationEvent animationEvent)
        {
           _heroController.OnFootstep(animationEvent);
        }

        public void OnLand(AnimationEvent animationEvent)
        {
            _heroController.OnLand(animationEvent);
        }
}
