using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : CollactableBase {

    [Header("Coin")]
    [SerializeField] float lerpSpeed;
    [SerializeField] float minDistance;

    bool _collect = false;

    void Update() {
        if (_collect) {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerpSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) <= minDistance) {
                if (graphicItem != null) graphicItem.SetActive(false);
                Destroy(gameObject, deathDelay);
            }
        }
    }

    protected override void OnCollect() {
        base.OnCollect();
        _collect = true;
    }

    protected override void Collect() {
        OnCollect();
    }
   
}