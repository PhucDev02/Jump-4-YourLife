using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] public Sprite barBroke, bar;
    [SerializeField] private new Collider2D collider;
    [SerializeField] private Collider2D perfectCollider;
    [Header("Check Attribute")]
    [SerializeField] public int isDiagonal;
    [SerializeField] public int isTransparent;
    [SerializeField] public bool collisionWithPlayer;
    private int collisionWithSide;
    [SerializeField] public float speedTransparent;
    [Header("Xmovement")]
    public float speed;
    [Header("Ymovement")]
    [SerializeField] public float diagonalMove;
    [Header("MoveUp")]
    private float upSpeed;
    [SerializeField] public bool isMovingUp = false;
    private float targetPositionY;
    [SerializeField] private float pivotY;
    public float PivotY
    {
        get { return pivotY; }
        set { pivotY = value; }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        speed = Random.Range(1,3) * (Random.Range(0, 100) > 50 ? 1 : -1);
        PivotY = transform.position.y;
        collisionWithSide = 0;
        upSpeed = 18;
        collisionWithPlayer = false;
        //set diagonal
        makeChanceDiagonal();
        //set transparent
        makeChanceTransparent();
        //set random X
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
    void Start()
    {
        sprite.sprite = bar;
        //get player instantiate from game manager
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        //RandomSpeed();
        //update transparent
        if (sprite.color.a < -0.25f || sprite.color.a > 1)
        {
            speedTransparent *= -1;
        }
        sprite.color += new Color(0, 0, 0, speedTransparent * Time.deltaTime);
        //update movement
        if (isMovingUp)
        {
            transform.Translate(Vector3.up * upSpeed * Time.deltaTime);
            if (transform.position.y >= targetPositionY)
            {
                Vector3 position = transform.position;
                transform.position = new Vector3(position.x, targetPositionY, position.z);
                isMovingUp = false;
            }
        }
        transform.position += new Vector3(speed, diagonalMove, 0) * Time.deltaTime;
    }
    public void moveUp(float distance)
    {
        isMovingUp = true;
        targetPositionY = transform.position.y + distance;
        pivotY += distance;
    }
    public void setBase()
    {
        speed = 0;
        isDiagonal = 0;
        diagonalMove = 0;
        isTransparent = 0;
        speedTransparent = 0;
        sprite.sprite = bar;
        transform.position = new Vector3(0, 3, 0);
        transform.GetChild(0).gameObject.SetActive(false);
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collisionWithPlayer = false;
            collider.isTrigger = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("SideBar"))
        {
            speed *= -1;
            diagonalMove *= -1;
            if (collisionWithPlayer == true)
            {
                collisionWithSide++;
                AudioManager.instance.playBreakSound();
                if (collisionWithSide == 1)
                {
                   sprite.sprite = barBroke;
                }
                else if (collisionWithSide == 2)
                {
                    sprite.sprite = null;
                    player.GetComponent<PlayerController>().isJumping = true;
                    collider.isTrigger = true;
                    collisionWithPlayer = false;
                    player.transform.SetParent(null);
                }
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collisionWithPlayer = true;
            collision.gameObject.transform.SetParent(gameObject.transform);
            perfectCollider.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SideBar"))
        {
            speed *= -1;
            diagonalMove *= -1;
        }
    }
    public void makeChanceTransparent()
    {
        isTransparent = (Random.Range(0, 100) > 80) ? 1 : 0;
        if (isTransparent == 1 && isDiagonal == 0) speedTransparent = -0.5f;
        else speedTransparent = 0;
    }
    public void makeChanceDiagonal()
    {
        isDiagonal = (Random.Range(0, 100) > 70) ? 1 : 0;
        if (isDiagonal == 1)
            diagonalMove = speed * Mathf.Tan(Mathf.PI / 18) * ((Random.Range(0, 100) > 50) ? -1 : 1);
        else diagonalMove = 0;
    }

    public float speedSign()
    {
        if (speed == 0) return 1;
        return speed / Mathf.Abs(speed);
    }
}