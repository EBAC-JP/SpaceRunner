using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFly : PowerUpBase {

    [SerializeField] float amountHeight;
    [SerializeField] float animationDuration;

    protected override void StartPowerUp() {
        base.StartPowerUp();
        PlayerController.Instance.ChangeHeight(amountHeight, animationDuration);
    }

    protected override void EndPowerUp() {
        PlayerController.Instance.ResetHeight(animationDuration);
    }
}
