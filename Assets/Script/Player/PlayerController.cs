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
    bool _canRun, _invencible;
    float _currentSpeed;
    MeshRenderer _myMesh;

    void Start() {
        SetComponents();
        ResetSpeed();
        SetInvencible(false);
    }

    // Update is called once per frame
    void Update() {
        if (!_canRun) return;
        _desiredPos = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _desiredPos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == obstacleTag && !_invencible) EndGame();
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.transform.tag == endTag) EndGame();
    }

    void EndGame() {
        _canRun = false;
        endGame.SetActive(true);
    }

    void SetComponents() {
        _myMesh = GetComponent<MeshRenderer>();
    }

    IEnumerator PlayInvencible(float duration) {

        for (int i = 0; i <= duration * 5; i++) {
            _myMesh.enabled = !_myMesh.enabled;
            yield return new WaitForSeconds(0.2f);
        }
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

    public void SetInvencible(bool value, float duration = 0f) {
        _invencible = value;
        if (_invencible) StartCoroutine(PlayInvencible(duration));
    }
}
