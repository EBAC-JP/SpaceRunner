using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController> {

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
    float _currentSpeed;

    void Start() {
        ResetSpeed();
    }

    // Update is called once per frame
    void Update() {
        if (!_canRun) return;
        _desiredPos = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _desiredPos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
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

    public void SpeedUp(float amount) {
        _currentSpeed = amount;
    }

    public void ResetSpeed() {
        _currentSpeed = speed;
    }
}
