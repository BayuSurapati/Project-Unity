using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterDialog : MonoBehaviour
{
    public float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            UIController.instance.EndingScreen.SetActive(true);

            timer += 3;
            if(timer <= 0 )
            {
                SceneManager.LoadScene("GameMenu");
            }
        }
    }
}
