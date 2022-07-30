using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

    [SerializeField] Animator animator;
    [SerializeField] List<AnimationSetup> animationSetups;

    public enum AnimationType {
        IDLE,
        RUN,
        DEATH
    }

    public void Play(AnimationType type) {
        foreach (var animation in animationSetups) {
            if (animation.type == type) {
                animator.SetTrigger(animation.triggerName);
                break;
            }
        }
    }
}

[System.Serializable]
public class AnimationSetup {
    public AnimationManager.AnimationType type;
    public string triggerName;
}
