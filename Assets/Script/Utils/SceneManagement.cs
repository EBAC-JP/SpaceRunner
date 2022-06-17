using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

    [SerializeField] AudioSource selectSource;

    public void Load(int scenePosition) {
        if (selectSource != null) selectSource.Play();
        SceneManager.LoadScene(scenePosition);
    }

    public void Load(string sceneName) {
        if (selectSource != null) selectSource.Play();
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() {
        if (selectSource != null) selectSource.Play();
        Application.Quit();
    }
}
