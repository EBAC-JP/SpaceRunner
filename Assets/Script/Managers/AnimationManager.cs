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

    public void Play(AnimationType type, float animationSpeed = 1) {
        foreach (var animation in animationSetups) {
            if (animation.type == type) {
                animator.SetTrigger(animation.triggerName);
                animator.speed = animation.speed * animationSpeed;
                break;
            }
        }
    }
}

[System.Serializable]
public class AnimationSetup {
    public AnimationManager.AnimationType type;
    public string triggerName;
    public float speed = 1f;
}
