using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField] Transform levelContainer;
    [Header("Pieces")]
    [SerializeField] float timeBetweenPieces;
    [SerializeField] Piece startPiece;
    [SerializeField] Piece finishPiece;
    [SerializeField] List<Piece> pieces;

    List<Piece> _spawnedPieces;

    void Awake() {
        CreateLevel();    
    }

    void CreateLevel(int levelIndex = 1) {
        _spawnedPieces = new List<Piece>();
        StartCoroutine(SpawnPieces(levelIndex));
    }

    void SpawnStartPiece() {
        var spawned = Instantiate(startPiece, levelContainer);
        _spawnedPieces.Add(spawned);
    }

    void SpawnMidPiece() {
        var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
        var spawned = Instantiate(pieces[Random.Range(0, pieces.Count)], levelContainer);
        spawned.transform.position = lastPiece.endPiece.position;
        _spawnedPieces.Add(spawned);
    }

    IEnumerator SpawnPieces(int levelIndex) {
        SpawnStartPiece();
        for (int i = 0; i < levelIndex * 3; i++) {
            SpawnMidPiece();
            yield return new WaitForSeconds(timeBetweenPieces);
        }
        SpawnEndPiece();
    }

    void SpawnEndPiece() {
        var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
        var spawned = Instantiate(finishPiece, levelContainer);
        spawned.transform.position = lastPiece.endPiece.position;
    }

}
