using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas canvas;
    public GameObject startPanel; 
    public GameObject gamePanel;  
    public Animation countdownAnimation; 
    public AudioSource audioSource; 

    private bool isGameRunning = false;

    private void Start()
    {
        // Initialize the game state
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        countdownAnimation.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        // Launching the game
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        StartCoroutine(CountdownAndStartGame());
    }

    private IEnumerator CountdownAndStartGame()
    {
        countdownAnimation.gameObject.SetActive(true);
        countdownAnimation.Play("CountdownAnimation");
        yield return new WaitForSeconds(countdownAnimation.clip.length); // Wait for the countdown animation to complete
        isGameRunning = true;
        
    }

    public void ExitGame()
    {
        // Quit the game
        Application.Quit();
    }

    private void Update()
    {
        if (isGameRunning)
        {
            // Logic when the game is running
        }
    }

    public void PlayBackgroundMusic()
    {
        // Play background music
        audioSource.Play();
    }

    public void PauseBackgroundMusic()
    {
        // Pause background music
        audioSource.Pause();

        


    }
    //当点击 Start 
    public void OnStartButton()
    {
        //与点击开始按钮后同步进行的函数
        StartCoroutine(PlayStartCountDown());

        //Start声音，声音源在原点位置
        AudioSource.PlayClipAtPoint(startClip, Vector3.zero);

        //隐藏开始按钮的页面
        startPanel.SetActive(false);
    }


    //点击Exit后退出游戏
    public void OnExitButton()
    {
        Application.Quit();
    }
}
