using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditHomeButton : MonoBehaviour
{

    public string homelol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(homelol);
    }
}
