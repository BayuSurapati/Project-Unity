using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public static GameMenu instance;

    public GameObject theMenu;
    public string GameScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (theMenu.activeInHierarchy)
            {
                //theMenu.SetActive(false);
                //Time.timeScale = 1f;
                Resume();
            }
            else
            {
                theMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void Resume()
    {
        theMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        theMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(GameScene);
        AudioMap.instance.StopMusic();
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("Current_Scene", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat("Player_Position_x", Player2Controller.instance.transform.position.x);
        PlayerPrefs.SetFloat("Player_Position_y", Player2Controller.instance.transform.position.y);
        PlayerPrefs.SetFloat("Player_Position_z", Player2Controller.instance.transform.position.z);
        Debug.Log("Game Have Been Saved");
    }
}
