using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : Singleton<LevelManager> {

    [SerializeField] Transform levelContainer;
    [Header("Material Colors")]
    [SerializeField] Material groundMaterial;
    [SerializeField] Material obstacleMaterial;
    [SerializeField] List<Color> groundColors;
    [SerializeField] List<Color> obstacleColors;
    [Header("Pieces")]
    [SerializeField] Piece startPiece;
    [SerializeField] Piece finishPiece;
    [SerializeField] List<Piece> pieces;
    [Header("Animation")]
    [SerializeField] float scaleDuration;
    [SerializeField] float scaleBetweenPieces;
    [SerializeField] Ease ease;

    List<Piece> _spawnedPieces = new List<Piece>();
    int _currentIndex;

    void Awake() {
        _currentIndex = 1;
        CreateLevel();    
    }

    public void CreateLevel() {
        CleanLevel();
        SetColors();
        SpawnPieces(_currentIndex);
    }

    void CleanLevel() {
        for (int i = _spawnedPieces.Count - 1; i >= 0; i--) {
            Destroy(_spawnedPieces[i].gameObject);
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
        _spawnedPieces.Add(spawned);
    }

    void SpawnPieces(int levelIndex) {
        SpawnStartPiece();
        for (int i = 0; i < levelIndex * 3; i++) {
            SpawnMidPiece();
        }
        SpawnEndPiece();
        StartCoroutine(ScalePieces());
        _currentIndex++;
    }

    IEnumerator ScalePieces() {
        foreach (var spawned in _spawnedPieces) {
            spawned.transform.localScale = Vector3.zero;
        }
        yield return null;
        foreach (var spawned in _spawnedPieces) {
            spawned.transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleBetweenPieces);
        }
    }

}
