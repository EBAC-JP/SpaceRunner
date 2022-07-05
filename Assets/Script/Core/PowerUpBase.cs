using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : CollactableBase {

    [Header("PowerUp")]
    [SerializeField] protected float duration;

    protected override void OnCollect() {
        base.OnCollect();
        StartPowerUp();
    }

    protected virtual void StartPowerUp() {
        Invoke(nameof(EndPowerUp), duration);
    }

    protected virtual void EndPowerUp() {}

}
