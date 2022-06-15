using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : CollactableBase {

    [SerializeField] int value = 1;
    [SerializeField] float deathDelay;
    [SerializeField] GameObject graphicItem;

    protected override void Collect() {
        if (graphicItem != null) graphicItem.SetActive(false);
        OnCollect();
        Destroy(gameObject, deathDelay);
    }
}
