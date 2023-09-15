using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    //Start Game by Loading Scene
    public void StartGame(string name)
    {
        SceneManager.LoadScene(name);
    }
    //Quit Game (Works on .exe only)
    public void QuitGame()
    {
        Application.Quit();
    }
}
