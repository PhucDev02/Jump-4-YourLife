using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text highScore;
    private void Update()
    {
        highScore.text = PlayerPrefs.GetInt("highScore").ToString();
    }
}
