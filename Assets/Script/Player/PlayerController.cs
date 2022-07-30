using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController> {

    [SerializeField] GameObject endGame;
    [SerializeField] GameObject coinCollector;
    [Header("Animation")]
    [SerializeField] AnimationManager animationManager;
    [SerializeField] GameObject playerModel;
    [Header("Tags")]
    [SerializeField] string obstacleTag;
    [SerializeField] string endTag;
    [Header("Moviments")]
    [SerializeField] Transform target;
    [SerializeField] float lerpSpeed;
    [SerializeField] float baseSpeed;
    

    Vector3 _desiredPos, _startPosition;
    bool _canRun, _invencible;
    float _currentSpeed;
    List<SkinnedMeshRenderer> _meshRendereres;

    void Start() {
        SetVariables();
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
        if (collision.transform.tag == obstacleTag && !_invencible) {
            collision.transform.DOMoveZ(1f, .3f).SetRelative();
            EndGame(AnimationManager.AnimationType.DEATH);
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.transform.tag == endTag) EndGame();
    }

    void EndGame(AnimationManager.AnimationType type = AnimationManager.AnimationType.IDLE) {
        _canRun = false;
        animationManager.Play(type);
        endGame.SetActive(true);
    }

    void SetVariables() {
        _startPosition = transform.position;
        _meshRendereres = new List<SkinnedMeshRenderer>(playerModel.GetComponentsInChildren<SkinnedMeshRenderer>());
    }

    IEnumerator PlayInvencible(float duration) {

        for (int i = 0; i <= duration * 5; i++) {
            foreach (var mesh in _meshRendereres) {
                mesh.enabled = !mesh.enabled;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void StartGame() {
        _canRun = true;
        animationManager.Play(AnimationManager.AnimationType.RUN, _currentSpeed / baseSpeed);
    }

    public void SpeedUp(float amount) {
        _currentSpeed = amount;
        animationManager.Play(AnimationManager.AnimationType.RUN, _currentSpeed / baseSpeed);
    }

    public void ResetSpeed() {
        _currentSpeed = baseSpeed;
    }

    public void SetInvencible(bool value, float duration = 0f) {
        _invencible = value;
        if (_invencible) StartCoroutine(PlayInvencible(duration));
    }

    public void ChangeHeight(float amount, float animationDuration) {
        transform.DOMoveY(_startPosition.y + amount, animationDuration);
        animationManager.Play(AnimationManager.AnimationType.RUN, 1 / baseSpeed);
    }

    public void ResetHeight(float animationDuration) {
        transform.DOMoveY(_startPosition.y, animationDuration);
        animationManager.Play(AnimationManager.AnimationType.RUN, _currentSpeed / baseSpeed);
    }

    public void ChangeCoinCollector(float amount) {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
}
