﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PilihKarakter : MonoBehaviour
{

    public string lol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pilihKarakter()
    {
        SceneManager.LoadScene(lol);
    }
}
