using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField] Transform levelContainer;
    [Header("Material Colors")]
    [SerializeField] Material groundMaterial;
    [SerializeField] Material obstacleMaterial;
    [SerializeField] List<Color> groundColors;
    [SerializeField] List<Color> obstacleColors;
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
        SetColors();
        CleanLevel();
        StartCoroutine(SpawnPieces(levelIndex));
    }

    void CleanLevel() {
        for (int i = _spawnedPieces.Count - 1; i >= 0; i--) {
            Destroy(_spawnedPieces[i]);
        }
        _spawnedPieces.Clear();
    }

    void SetColors() {
        groundMaterial.SetColor("_Color", groundColors[Random.Range(0, groundColors.Count)]);
        obstacleMaterial.SetColor("_Color", obstacleColors[Random.Range(0, obstacleColors.Count)]);
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

    void SpawnEndPiece() {
        var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
        var spawned = Instantiate(finishPiece, levelContainer);
        spawned.transform.position = lastPiece.endPiece.position;
    }

    IEnumerator SpawnPieces(int levelIndex) {
        SpawnStartPiece();
        for (int i = 0; i < levelIndex * 3; i++) {
            SpawnMidPiece();
            yield return new WaitForSeconds(timeBetweenPieces);
        }
        SpawnEndPiece();
    }

}
