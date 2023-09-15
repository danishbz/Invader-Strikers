using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject gameOverCanvas, pauseCanvas, tutorialCanvas; //Canvases
    [SerializeField] private AudioSource bgmManager, sfxManager; //Audio Sources
    [SerializeField] private float tutorialDuration; //Tutorial Duration

    private void Awake()
    {
        instance = this;

        //Set original states
        Time.timeScale = 1f;
        gameOverCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        StartCoroutine(TutorialCloseCoroutine()); //Close tutorial after duration
    }
    private void Update()
    {
        //If esc button is pressed...
        if (Input.GetKeyDown("escape"))
        {
            //If game is not paused, pause the game, else unpause game
            if(!pauseCanvas.activeSelf)
            {
                Pause();
            }
            else
            {
                Play();
            }
        }
    }
    //Pause game
    public void Pause()
    {
        bgmManager.Pause();
        sfxManager.Pause();
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
    }
    //Unpause/Play game
    public void Play()
    {
        bgmManager.UnPause();
        sfxManager.UnPause();
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
    }
    //Game Over
    public void GameOver()
    {
        sfxManager.Stop();
        bgmManager.Stop();
        SFXManager.instance.playGameOver();
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
    //Restart Game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //Back to title screen
    public void TitleScreen(string name)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }
    //Close tutorial coroutine
    private IEnumerator TutorialCloseCoroutine()
    {
        yield return new WaitForSeconds(tutorialDuration);
        tutorialCanvas.SetActive(false);
    }
}
