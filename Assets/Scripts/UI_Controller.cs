using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image musicButtonImg;
    public Sprite muteMusicImg, allowMusicImg;
    [SerializeField] private Image soundButtonImg;
    public Sprite muteSoundImg, allowSoundImg;
    public GameObject countDownPanel;
    private void Awake()
    {
        musicButtonImg.SetNativeSize();
        soundButtonImg.SetNativeSize();
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("allowMusic") == 1)
        { 
            musicButtonImg.sprite = allowMusicImg;
        }
        else musicButtonImg.sprite = muteMusicImg; 
        if (PlayerPrefs.GetInt("allowSound") == 1)
        {
            soundButtonImg.sprite = allowSoundImg;
        }
        else soundButtonImg.sprite = muteSoundImg;
    }
    public void changeAllowMusic()
    {
        UI_Manager.instance.changeAllowMusic();
    }
    public void changeAllowSound()
    {
        UI_Manager.instance.changeAllowSound();
    }
    public void countDown3s()
    {
        Debug.Log("1");
        countDownPanel.SetActive(true);
        StartCoroutine(CountDown(3.0f));
    }
    IEnumerator CountDown(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        Time.timeScale = 1;
        Debug.Log("2");
        countDownPanel.SetActive(false);
    }
}
