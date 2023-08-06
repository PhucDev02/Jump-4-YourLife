using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Theme theme;
    [SerializeField] Text themeName;
    [SerializeField] Image themeImage;
    void Start()
    {
        themeName.text = theme.name;
        themeImage.sprite = theme.avatar;
    }
}
