using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHelper : MonoBehaviour {

    [Header("Moviments")]
    [SerializeField] Transform target;
    [SerializeField] float lerpSpeed;

    // Update is called once per frame
    void Update() {
        transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed);
    }
}
