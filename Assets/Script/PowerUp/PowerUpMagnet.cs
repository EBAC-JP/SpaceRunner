using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMagnet : PowerUpBase {

    [SerializeField] float sizeAmount;

    protected override void StartPowerUp() {
        base.StartPowerUp();
        PlayerController.Instance.ChangeCoinCollector(sizeAmount);
    }

    protected override void EndPowerUp() {
        PlayerController.Instance.ChangeCoinCollector(1);
    }
}
