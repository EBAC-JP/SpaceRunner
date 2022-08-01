using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentHelper : MonoBehaviour {
    
    [SerializeField] List<Transform> positions;
    [SerializeField] float duration;

    int _index = 0;

    void Start() {
        transform.position = positions[_index].position;
        NextIndex();
        StartCoroutine(StartMoviment());
    }

    void NextIndex() {
        _index++;
        if (_index >= positions.Count) _index = 0;
    }

    IEnumerator StartMoviment() {
        float time = 0;
        while(true) {
            var currentPosition = transform.position;
            while (time < duration) {
                transform.position = Vector3.Lerp(currentPosition, positions[_index].position, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            NextIndex();
            time = 0;
            yield return null;
        }
    }
}
