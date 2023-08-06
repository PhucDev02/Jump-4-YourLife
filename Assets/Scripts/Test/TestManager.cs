using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestManager : MonoBehaviour
{
    public static TestManager Instance { get; private set; }

    public int integer;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else { 
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(Instance);
    }

    public void DoSomething()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
