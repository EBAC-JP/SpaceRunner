using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollactableBase : MonoBehaviour {

    [SerializeField] string targetTag;
    [SerializeField] ParticleSystem particle;
    [SerializeField] AudioSource audioSource;

    protected virtual void Collect() {}
    protected virtual void OnCollect() {
        if (particle != null) particle.Play();
        if (audioSource != null) audioSource.Play();
    }

    private void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag(targetTag)) {
            Collect();
        }
    }
}
