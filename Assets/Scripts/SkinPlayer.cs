using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Skin",menuName ="Skin Player")]
public class SkinPlayer : ScriptableObject
{
    public string skinName;
    public Sprite skinImage;
    public GameObject playerPrefabs;
}
