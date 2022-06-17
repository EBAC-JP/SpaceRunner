using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] GameObject endGame;
    [Header("Tags")]
    [SerializeField] string obstacleTag;
    [SerializeField] string endTag;
    [Header("Moviments")]
    [SerializeField] Transform target;
    [SerializeField] float lerpSpeed;
    [SerializeField] float speed;

    Vector3 _desiredPos;
    bool _canRun;

    // Update is called once per frame
    void Update() {
        if (!_canRun) return;
        _desiredPos = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _desiredPos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == obstacleTag) EndGame();
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.transform.tag == endTag) EndGame();
    }

    void EndGame() {
        _canRun = false;
        endGame.SetActive(true);
    }

    public void StartGame() {
        _canRun = true;
    }
}
