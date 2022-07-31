using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {
    [SerializeField] public Transform endPiece;
    [Header("Ground")]
    [SerializeField] public Color groundColor;
    [SerializeField] Material ground;
    [Header("PowerUp")]
    [SerializeField] Transform powerUp;
    [SerializeField] List<GameObject> powerUps;

    void Awake() {
        if (powerUp != null) SpawnPowerUp();
        ground.SetColor("_Color", groundColor);
    }

    void SpawnPowerUp() {
        Instantiate(powerUps[Random.Range(0, powerUps.Count)], powerUp);
    }
}
