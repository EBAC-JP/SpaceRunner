using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {
    [SerializeField] public Transform endPiece;
    [SerializeField] Transform powerUp;
    [SerializeField] List<GameObject> powerUps;

    void Awake() {
        if (powerUp != null) SpawnPowerUp();
    }

    void SpawnPowerUp() {
        Instantiate(powerUps[Random.Range(0, powerUps.Count)], powerUp);
    }
}
