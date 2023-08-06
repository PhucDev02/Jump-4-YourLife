using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    [SerializeField] GameObject player;
    [SerializeField] Text scoreText, scoreGameOver;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gamePlayPanel;
    [SerializeField] GameObject guideTapPanel;
    [SerializeField] GameObject perfectImage;
    [SerializeField] Animator perfectUI;
    [SerializeField] Sprite newRecordSprite;
    [SerializeField] Image newRecord;
    [SerializeField] List<GameObject> players;
    public int score;
    bool gameOver;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            score = 0;
            gameOver = false;
            //player
            GameObject tmp = players[PlayerPrefs.GetInt("idSkinChoose")];
            tmp.GetComponent<PlayerController>().perfectAnimator = perfectUI.GetComponent<Animator>();
            tmp.transform.position = new Vector3(0, 6f, 0);
            player = Instantiate(tmp);
        }
    }
    void Start()
    {
        Time.timeScale = 1;
        guideTapPanel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            guideTapPanel.SetActive(false); 
        }
        if (player == null) executeGameOver();
        if (player.transform.position.y < -4.8)
        {
            gameOver = true;
            if (gameOver == true)
                executeGameOver();
        }
        scoreText.text = score.ToString();
    }
    void executeGameOver()
    {
        Time.timeScale = 0;
        gameOver = false;
        scoreGameOver.text = scoreText.text.ToString();
        if (score > PlayerPrefs.GetInt("highScore"))
        {
            newRecord.sprite = newRecordSprite;
            PlayerPrefs.SetInt("highScore", score);
        }
        gameOverPanel.SetActive(true);
        gamePlayPanel.SetActive(false);
        player.transform.position += new Vector3(0, 25, 0);
        AudioManager.instance.stopMusic = true;
        AudioManager.instance.PlayGameoverSound();
    }
    public void addScore(int score)
    {
        this.score += score;
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
}
