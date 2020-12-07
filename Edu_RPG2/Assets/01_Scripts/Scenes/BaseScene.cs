using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    Define.Scene _sceneType;
    public Define.Scene sceneType { get; protected set; } = Define.Scene.Unknown;

    void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        Object go = GameObject.FindObjectOfType(typeof(EventSystem));
        if (go == null)
        {
            Managers._resource.Instantiate("UI/EventSystem");
        }
    }

    public abstract void Clear();


}
