using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentMaker : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] float direction;
    void Start()
    {
        direction = -0.005f;
    }
    void Update()
    {
        if(sprite.color.a<-0.5f||sprite.color.a>1)
        {
            direction *= -1;
        }
        sprite.color += new Color(0, 0, 0, direction); 
    }
}
