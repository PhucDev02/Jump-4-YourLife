using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SkinStoreManager store;
    [SerializeField] Image skinStore;
    private void Awake()
    {
        skinStore.sprite = store.getSkinImage();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void openMyFacebook()
    {
        Application.OpenURL("https://www.facebook.com/100010587756741");
    }
}
