using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Theme",menuName ="Theme")]
public class Theme : ScriptableObject
{
    [SerializeField] public Sprite avatar;
    [SerializeField] public string name;
    [SerializeField] public Sprite background;
    [SerializeField] public Sprite SideBarSprite;
    [SerializeField] public Sprite[] barSprite,brokeBarSprite;
}
