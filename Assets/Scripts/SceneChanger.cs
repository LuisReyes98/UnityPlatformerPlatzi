﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    public static void ChangeSceneTo(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
    public void ChangeCurrentSceneTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void NextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
