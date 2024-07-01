using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject infoScreen;

    void Start() {
        infoScreen.SetActive(false);
    }
    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    public void Info() {
        infoScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
