using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeStoreManager : MonoBehaviour
{
    [SerializeField] private List<Theme> themes; //list nay se dua vao content
    GameObject skinTmp;
    GameObject objTmp;
    public Transform content;
    public int idThemeChoose;
    // Start is called before the first frame update
    private void Awake()
    {
        skinTmp = content.GetChild(0).gameObject;
        for (int i = 0; i < themes.Count; i++)
        {
            objTmp = Instantiate(skinTmp, content);
            objTmp.GetComponent<ThemeDisplay>().theme = themes[i];
            objTmp.GetComponent<Button>().AddEventListener(i, OnSkinChoose);
        }
        Destroy(skinTmp);
        content.GetChild(PlayerPrefs.GetInt("idThemeChoose")).GetChild(1).gameObject.SetActive(true);
    }
    void Start()
    {
        //set choose skin
        for (int i = 0; i < themes.Count; i++)
        {
            if (i == PlayerPrefs.GetInt("idThemeChoose"))
            {
                content.GetChild(i).GetComponent<Button>().interactable = false;
                content.GetChild(i).GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                content.GetChild(i).GetComponent<Button>().interactable = true;
                content.GetChild(i).GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    private void OnSkinChoose(int index)
    {
        //Debug.Log(index);
        PlayerPrefs.SetInt("idThemeChoose", index);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < themes.Count; i++)
        {
            if (i == PlayerPrefs.GetInt("idThemeChoose"))
            {
                content.GetChild(i).GetComponent<Button>().interactable = false;
                content.GetChild(i).GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                content.GetChild(i).GetComponent<Button>().interactable = true;
                content.GetChild(i).GetChild(2).gameObject.SetActive(false);
            }
        }
        content.GetChild(PlayerPrefs.GetInt("idThemeChoose")).GetComponent<Button>().interactable = false;
        content.GetChild(PlayerPrefs.GetInt("idThemeChoose")).GetChild(2).gameObject.SetActive(true);
    }
}
