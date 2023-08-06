using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHolder : MonoBehaviour
{
    [SerializeField] GameObject[] barPrefabs;
    [SerializeField] List<GameObject> bars;
    [SerializeField] List<GameObject> sideBars;
    [SerializeField] private float limitPositionY;
    [SerializeField] private float DistanceEachBar;
    [SerializeField] GameObject player;
    [SerializeField] List<Theme> themes;
    [SerializeField] SpriteRenderer background;
    float distance;
    private void Awake()
    {
        limitPositionY = 20;
        DistanceEachBar = 3.5f;
    }
    int RandomBar()
    {
        if (bars.Count < 10)
            return 2;
        else if (bars.Count < 25)
            return Random.Range(1, 2);
        else
            return Random.Range(0, 1);
    }
    void Start()
    {
        setupSideBar();
        executeTheme();
        Debug.Log(Screen.currentResolution);
        bars[0].GetComponent<PlatformController>().setBase();
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        //
        float pivotY = bars[bars.Count - 1].GetComponent<PlatformController>().PivotY;
        while (bars.Count < 150)
        {
            pivotY -= DistanceEachBar;
            bars.Add(Instantiate(barPrefabs[RandomBar()]));
            Vector3 position = bars[bars.Count - 1].transform.position;
            bars[bars.Count - 1].transform.position = new Vector3(position.x, pivotY, 0);
            bars[bars.Count - 1].transform.parent = GameObject.FindGameObjectWithTag("PlatformHolder").transform;
            //  
            makeDifficult();
            bars[bars.Count - 1].GetComponent<PlatformController>().PivotY = pivotY;
            bars[bars.Count - 1].GetComponent<PlatformController>().speed *= -bars[bars.Count - 2].GetComponent<PlatformController>().speedSign();

        }
    }
    // Update is called once per frame
    void executeTheme()
    {
        Theme tmp = themes[PlayerPrefs.GetInt("idThemeChoose")];
        //adjust sidebar
        sideBars[0].GetComponent<SpriteRenderer>().sprite = tmp.SideBarSprite;
        sideBars[1].GetComponent<SpriteRenderer>().sprite = tmp.SideBarSprite;
        //adjust background
        background.sprite = tmp.background;
        //adjust bar
        for (int i = 0; i < 3; i++)
        {
            barPrefabs[i].GetComponent<PlatformController>().bar = tmp.barSprite[i];
            barPrefabs[i].GetComponent<PlatformController>().barBroke = tmp.brokeBarSprite[i];
        }
        bars[0].GetComponent<PlatformController>().bar = tmp.barSprite[2];
        bars[0].GetComponent<PlatformController>().barBroke = tmp.brokeBarSprite[2];
    }
    void Update()
    {
        //update Bar
        //if (player.GetComponent<PlayerController>().isJumping==false)
        {
            foreach (GameObject bar in bars)
            {
                if (bar.gameObject.GetComponent<PlatformController>().collisionWithPlayer)
                    distance = 3 - bar.transform.position.y;
            }
            foreach (GameObject bar in bars)
            {
                bar.GetComponent<PlatformController>().moveUp(distance);
            }
        }
        //update sidebar
        sideBars[0].transform.position = Vector3.MoveTowards(sideBars[0].transform.position, sideBars[0].transform.position + new Vector3(0, distance, 0), 10 * Time.deltaTime);
        sideBars[1].transform.position = Vector3.MoveTowards(sideBars[1].transform.position, sideBars[1].transform.position + new Vector3(0, distance, 0), 10 * Time.deltaTime);
        if (sideBars[0].transform.position.y > 9)
        {
            sideBars[0].transform.position = new Vector3(sideBars[0].transform.position.x, -9, 0);
            sideBars[1].transform.position = new Vector3(sideBars[1].transform.position.x, -9, 0);
        }
        //Instantiate new bar
        while (bars[0].transform.position.y > limitPositionY)
        {
            Destroy(bars[0]);
            bars.Remove(bars[0]);
        }
    }
    void setupSideBar()
    {
        if (Screen.height / Screen.width == 2)
        {
            Debug.Log("18:9");
            sideBars[0].transform.position = new Vector3(-2.5f, sideBars[0].transform.position.y, 0);
            sideBars[1].transform.position = new Vector3(2.5f, sideBars[1].transform.position.y, 0);
        }
        else //16:9
        {
            Debug.Log("16:9");
            sideBars[0].transform.position = new Vector3(-2.8125f, sideBars[0].transform.position.y, 0);
            sideBars[1].transform.position = new Vector3(2.8125f, sideBars[1].transform.position.y, 0);
        }
    }
    void makeDifficult()
    {
        if (bars.Count < 10)
        {
            bars[bars.Count - 1].GetComponent<PlatformController>().speed = Random.Range(1.0f,1.3f);
            bars[bars.Count - 1].GetComponent<PlatformController>().makeChanceDiagonal();
            bars[bars.Count - 1].GetComponent<PlatformController>().diagonalMove = 0;
            bars[bars.Count - 1].GetComponent<PlatformController>().speedTransparent = 0;
        }
        else if (bars.Count < 25)
        {
            bars[bars.Count - 1].GetComponent<PlatformController>().speed = Random.Range(1.5f,2.0f);
            bars[bars.Count - 1].GetComponent<PlatformController>().makeChanceDiagonal();
            bars[bars.Count - 1].GetComponent<PlatformController>().makeChanceTransparent();
        }
        else
        {
            bars[bars.Count - 1].GetComponent<PlatformController>().speed = 3;
            bars[bars.Count - 1].GetComponent<PlatformController>().makeChanceDiagonal();
            bars[bars.Count - 1].GetComponent<PlatformController>().makeChanceTransparent();
        }
    }
}