using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField] Transform levelContainer;
    [SerializeField] List<Color> colors;
    [Header("Pieces")]
    [SerializeField] float timeBetweenPieces;
    [SerializeField] Piece startPiece;
    [SerializeField] Piece finishPiece;
    [SerializeField] List<Piece> pieces;

    List<Piece> _spawnedPieces = new List<Piece>();

    void Awake() {
        CreateLevel();    
    }

    void CreateLevel(int levelIndex = 1) {
        CleanLevel();
        StartCoroutine(SpawnPieces(levelIndex));
    }

    void CleanLevel() {
        for (int i = _spawnedPieces.Count - 1; i >= 0; i--) {
            Destroy(_spawnedPieces[i]);
        }
        _spawnedPieces.Clear();
    }

    void SpawnStartPiece(Color color) {
        var piece = startPiece;
        piece.groundColor = color;
        var spawned = Instantiate(piece, levelContainer);
        _spawnedPieces.Add(spawned);
    }

    void SpawnMidPiece(Color color) {
        var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
        var piece = pieces[Random.Range(0, pieces.Count)];
        piece.groundColor = color;
        var spawned = Instantiate(piece, levelContainer);
        spawned.transform.position = lastPiece.endPiece.position;
        _spawnedPieces.Add(spawned);
    }

    void SpawnEndPiece(Color color) {
        var piece = finishPiece;
        piece.groundColor = color;
        var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
        var spawned = Instantiate(piece, levelContainer);
        spawned.transform.position = lastPiece.endPiece.position;
    }

    IEnumerator SpawnPieces(int levelIndex) {
        Color randomColor = colors[Random.Range(0, colors.Count)];
        SpawnStartPiece(randomColor);
        for (int i = 0; i < levelIndex * 3; i++) {
            SpawnMidPiece(randomColor);
            yield return new WaitForSeconds(timeBetweenPieces);
        }
        SpawnEndPiece(randomColor);
    }

}
