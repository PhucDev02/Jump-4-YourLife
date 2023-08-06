using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinStoreManager : MonoBehaviour
{
    [SerializeField] private Text descriptionPlayer;
    [SerializeField] private Image imagePlayer;
    [SerializeField] private Image skinDisplayInMenu;
    [SerializeField] private List<SkinPlayer> skin; //list nay se dua vao content
    GameObject skinTmp;
    GameObject objTmp;
    public Transform content;
    public int idSkinChoose;
    // Start is called before the first frame update
    private void Awake()
    {
        skinTmp = content.GetChild(0).gameObject;
        for (int i = 0; i < skin.Count; i++)
        {
            objTmp=Instantiate(skinTmp, content);
            objTmp.GetComponent<SkinDisplay>().skin = skin[i];
            objTmp.GetComponent<Button>().AddEventListener(i, OnSkinChoose);
        }
        Destroy(skinTmp); 
        content.GetChild(PlayerPrefs.GetInt("idSkinChoose")).GetChild(1).gameObject.SetActive(true);
        Debug.Log(PlayerPrefs.GetInt("idSkinChoose"));
    }
    void Start()
    {
        //set choose skin
        for (int i = 0; i < skin.Count; i++)
        {
            if (i == PlayerPrefs.GetInt("idSkinChoose"))
            {
                content.GetChild(i).GetComponent<Button>().interactable = false;
                content.GetChild(i).GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                content.GetChild(i).GetComponent<Button>().interactable = true;
                content.GetChild(i).GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    private void OnSkinChoose(int index)
    {
        //Debug.Log(index);
        PlayerPrefs.SetInt("idSkinChoose", index);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < skin.Count; i++)
        {
            if (i == PlayerPrefs.GetInt("idSkinChoose"))
            {
                content.GetChild(i).GetComponent<Button>().interactable = false;
                content.GetChild(i).GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                content.GetChild(i).GetComponent<Button>().interactable = true;
                content.GetChild(i).GetChild(1).gameObject.SetActive(false);
            }
        }
        content.GetChild(PlayerPrefs.GetInt("idSkinChoose")).GetComponent<Button>().interactable = false;
        content.GetChild(PlayerPrefs.GetInt("idSkinChoose")).GetChild(1).gameObject.SetActive(true);

        skinDisplayInMenu.sprite = skin[PlayerPrefs.GetInt("idSkinChoose")].skinImage;

        descriptionPlayer.text = content.GetChild(PlayerPrefs.GetInt("idSkinChoose")).GetComponent<SkinDisplay>().skin.name;
    }
    public Sprite getSkinImage()
    {
        return skin[PlayerPrefs.GetInt("idSkinChoose")].skinImage;
    }
}
