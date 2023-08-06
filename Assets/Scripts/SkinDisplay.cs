using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinDisplay : MonoBehaviour
{
    public SkinPlayer skin;
    [SerializeField] Image skinImage;
    // Start is called before the first frame update
    void Start()
    {
        skinImage.sprite = skin.skinImage;
    }

}
