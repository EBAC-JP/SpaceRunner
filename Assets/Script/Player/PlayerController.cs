using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] string obstacleTag;
    [Header("Moviments")]
    [SerializeField] Transform target;
    [SerializeField] float lerpSpeed;
    [SerializeField] float speed;

    Vector3 _desiredPos;
    bool _canRun = true;

    // Update is called once per frame
    void Update() {
        if (!_canRun) return;
        _desiredPos = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _desiredPos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == obstacleTag) {
            _canRun = false;
        }
    }
}
