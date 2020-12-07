using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public BaseScene currentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }

    public void LoadScene(Define.Scene sceneName)
    {
        currentScene.Clear();
        SceneManager.LoadScene($"{Enum.GetName(typeof(Define.Scene), sceneName)}");
    }


}
