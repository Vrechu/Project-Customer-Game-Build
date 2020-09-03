﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager GetMainManager()
    {
        return currentManager;
    }
    static MainGameManager currentManager = null;
    
    void Awake()
    {
        if (currentManager == null){
            currentManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);            
        }
    }

    void OnDestroy()
    {
    }

    void Start()
    {
        
    }

    void Update()
    {
    }    
}