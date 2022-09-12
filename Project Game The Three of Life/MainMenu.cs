using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string NewGameScene;

    public GameObject continueButton;

    public string loadGameScene;
    public AudioSource audioButtonNew;
    public AudioSource audioButtonCont;
    public AudioSource audioButtonExit;

    public float waitToLoad = 1f;
    

    // Start is called before the first frame update
    void OnButtonClick()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Continue()
    {
        audioButtonCont.Play();
        
    }

    public void NewGame()
    {
        
        Time.timeScale = 1f;
        //GameMenu.instance.theMenu.SetActive(false);
        audioButtonNew.Play();
        SceneManager.LoadScene(NewGameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
        audioButtonExit.Play();
    }
}
