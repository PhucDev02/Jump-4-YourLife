using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager instance;
    [SerializeField] AudioSource gameMusic;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource gameOverSound;
    [SerializeField] AudioSource breakSound;
    [SerializeField] public bool stopMusic;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
           Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("allowMusic")==1)
        {
            if (stopMusic == false)
                gameMusic.UnPause();
            else gameMusic.Pause();
        }
        else
        {
            gameMusic.Pause();
        }
    }
    public void PlayJumpSound()
    {
        if(PlayerPrefs.GetInt("allowSound")==1)
        {
            jumpSound.Play();
        }
    }
    public void PlayGameoverSound()
    {
        if(PlayerPrefs.GetInt("allowSound")==1)
        {
            gameOverSound.Play();
           // PlayerPrefs.SetInt("allowMusic",0);
        }
    }
    public void StopGameoverSound()
    {
            gameOverSound.Stop();
    }
    public void resetGameMusic()
    {
        gameMusic.Play();
        //gameMusic.Pause();
    }
    public void playBreakSound()
    {
        if(PlayerPrefs.GetInt("allowSound")==1)
        {
            breakSound.Play();
        }
    }
}
