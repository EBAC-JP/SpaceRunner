using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : PowerUpBase {

    [SerializeField] float speedUp;

    protected override void StartPowerUp() {
        base.StartPowerUp();
        PlayerController.Instance.SpeedUp(speedUp);
    }

    protected override void EndPowerUp() {
        PlayerController.Instance.ResetSpeed();
    }
}
