using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    public void StartGame()
    {
        SceneManager.LoadScene("Scene_01");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
