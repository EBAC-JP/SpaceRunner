using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : PowerUpBase {

    protected override void StartPowerUp() {
        base.StartPowerUp();
        PlayerController.Instance.SetInvencible(true, duration);
    }

    protected override void EndPowerUp() {
        PlayerController.Instance.SetInvencible(false);
    }
}