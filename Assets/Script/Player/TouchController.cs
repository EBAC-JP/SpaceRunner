using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

    [SerializeField] float moveSpeed;

    Vector2 _pastPosition;

    void Update() {
        if (Input.GetMouseButton(0)) {
            Move(Input.mousePosition.x - _pastPosition.x);
        }
        _pastPosition = Input.mousePosition;
    }

    void Move(float speed) {
        transform.position += Vector3.right * Time.deltaTime * speed * moveSpeed;
    }
}
