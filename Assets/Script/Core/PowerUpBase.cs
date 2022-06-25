using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : CollactableBase {

    [SerializeField] float duration;

    protected override void OnCollect() {
        base.OnCollect();
        StartPowerUp();
    }

    protected virtual void StartPowerUp() {
        Debug.Log("Começou!");
        Invoke(nameof(EndPowerUp), duration);
    }

    protected virtual void EndPowerUp() {
        Debug.Log("Terminou");
    }

}
