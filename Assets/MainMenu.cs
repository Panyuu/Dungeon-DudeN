using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void continueGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void newGame() {

        SceneManager.LoadScene(1);

    }

    public void exit() {


        Debug.Log("QUIT!");
        Application.Quit();

    }

}
