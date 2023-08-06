using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Animator animator;
    public Animator perfectAnimator;
    [SerializeField] public int perfectJump;
    public bool isJumping;
    void Start()
    {
        jumpForce = 150;
        isJumping = true;
        perfectJump = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if ((Input.GetButtonDown("Jump"))  && isJumping == false)
        if (IsMouseOverUI() == false)
            if (Input.GetMouseButtonDown(0) && isJumping == false && transform.position.y >= 2.98 && Time.timeScale == 1)
                Jump();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PerfectSensor") && isJumping == true)
        {
            perfectJump = 2;
            isJumping = false;
            //show perfectUI 
            perfectAnimator.Play("PerfectUI");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            int tmp_score = (int)(3.5 - collision.transform.position.y) / 3;
            if (tmp_score < 3)
            {
                GameManager.instance.addScore(tmp_score * perfectJump);
                perfectJump = 1;
            }
            animator.SetBool("isJumping", false);
            //StartCoroutine(AfterJump(0.6f));
            isJumping = false;
        }
    }
    IEnumerator AfterJump(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isJumping = false;
    }
    public bool IsMouseOverUI()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return true;

        //check touch
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                return true;
        }

        return false;
    }
    public void Jump()
    {
        rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
        isJumping = true;
        animator.SetBool("isJumping", true);
        gameObject.transform.SetParent(null);
        AudioManager.instance.PlayJumpSound();
    }
}
