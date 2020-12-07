using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        sceneType = Define.Scene.Login;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Managers._scene.LoadScene(Define.Scene.Game); 
        }
    }


    public override void Clear()
    {
        Debug.Log("LoginScene Clear");
    }

}
