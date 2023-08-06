using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
    }
    public void changeAllowMusic()
    {
        PlayerPrefs.SetInt("allowMusic", 1 - PlayerPrefs.GetInt("allowMusic"));
    }
    public void changeAllowSound()
    {
        PlayerPrefs.SetInt("allowSound", 1 - PlayerPrefs.GetInt("allowSound"));
    }
}
