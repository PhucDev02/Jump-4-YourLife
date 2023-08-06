using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void Awake()
    {
        Debug.Log("Awake");
    }
    void Start()
    {
        Debug.Log("Start");
    }
    private void OnEnable()
    {
        Debug.Log("Onenable");
    }
    private void OnDisable()
    {
        Debug.Log("Disable");
    }

    //private void Update()
    //{
    //    Debug.Log(Time.deltaTime);
    //    Debug.Log(Time.fixedDeltaTime);
    //}
    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("ffff");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
