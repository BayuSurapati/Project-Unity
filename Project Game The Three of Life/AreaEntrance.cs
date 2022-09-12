using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string transitionName;
    // Start is called before the first frame update
    void Start()
    {
        if(transitionName == Player2Controller.instance.areaTransitionName)
        {
            Player2Controller.instance.transform.position = transform.position;
        }

        UIFade.instance.fadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
