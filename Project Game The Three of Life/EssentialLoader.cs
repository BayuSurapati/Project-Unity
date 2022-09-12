using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialLoader : MonoBehaviour
{
    public GameObject UIScreen;

    public GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        if(UIFade.instance == null)
        {
            Instantiate(UIScreen);
        }
        if(Player2Controller.instance == null)
        {
            Instantiate(player);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
