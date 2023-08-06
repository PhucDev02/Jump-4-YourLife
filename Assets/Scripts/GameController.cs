using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public void playAgain()
    {
        SceneManager.LoadScene("GamePlay");
        AudioManager.instance.stopMusic = false;
        AudioManager.instance.StopGameoverSound();
        changeStopGame();
    }
    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
        AudioManager.instance.stopMusic = false;
        AudioManager.instance.StopGameoverSound();

    }
    public void changeStopGame()
    {
        Time.timeScale = 1 - Time.timeScale; 
    }
}
