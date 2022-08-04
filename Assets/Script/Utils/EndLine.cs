using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLine : MonoBehaviour {

    [SerializeField] LineRenderer line;
    
    void Start() {
        line.positionCount = 2;
        SetLinePositions();
    }

    void SetLinePositions() {
        line.SetPosition(0, new Vector3(-4.8f, 1f, transform.position.z + 4.5f));
        line.SetPosition(1, new Vector3(4.8f, 1f, transform.position.z + 4.5f));
    }
}
