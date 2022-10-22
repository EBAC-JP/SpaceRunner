using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollactableBase : MonoBehaviour {

    [SerializeField] string targetTag;
    [SerializeField] ParticleSystem particle;
    [SerializeField] AudioSource audioSource;
    [SerializeField] protected GameObject graphicItem;
    [SerializeField] protected float deathDelay;

    protected virtual void Collect() {
        if (graphicItem != null) graphicItem.SetActive(false);
        OnCollect();
        Destroy(gameObject, deathDelay);
    }
    
    protected virtual void OnCollect() {
        if (particle != null) particle.Play();
        if (audioSource != null) audioSource.Play();
        PlayerController.Instance.Bounce();
    }

    private void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag(targetTag)) {
            Collect();
        }
    }
}
