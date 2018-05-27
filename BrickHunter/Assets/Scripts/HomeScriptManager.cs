using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScriptManager : MonoBehaviour {

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
