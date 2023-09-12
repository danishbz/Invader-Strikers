using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject gameOverCanvas, pauseCanvas, tutorialCanvas;
    [SerializeField] private AudioSource bgmManager, sfxManager;
    [SerializeField] private float tutorialDuration; // Tutorial Duration

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
        gameOverCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        StartCoroutine(TutorialCloseCoroutine());
    }
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
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
    public void Pause()
    {
        bgmManager.Pause();
        sfxManager.Pause();
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
    }
    public void Play()
    {
        bgmManager.UnPause();
        sfxManager.UnPause();
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
    }

    public void GameOver()
    {
        sfxManager.Stop();
        bgmManager.Stop();
        SFXManager.instance.playGameOver();
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void TitleScreen(string name)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }
    private IEnumerator TutorialCloseCoroutine()
    {
        yield return new WaitForSeconds(tutorialDuration);
        tutorialCanvas.SetActive(false);
    }
}
