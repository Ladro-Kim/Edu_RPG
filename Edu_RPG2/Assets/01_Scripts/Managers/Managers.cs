using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers Instance;
    public static Managers managers { get { Init(); return Instance; } }

    InputManager inputManager = new InputManager();
    ResourceManager resourceManager = new ResourceManager();


    public static InputManager _input { get { return Instance.inputManager; } }
    public static ResourceManager _resource { get { return Instance.resourceManager; } }



    // Start is called before the first frame update
    void Awake()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        _input.OnKeyboard();
        _input.OnMouse();
    }

    static void Init()
    {
        if (Instance == null)
        {
            GameObject go_managers = GameObject.Find("@Managers");
            if (go_managers == null)
            {
                go_managers = new GameObject { name = "@Managers" };
                go_managers.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go_managers);
            Instance = go_managers.GetComponent<Managers>();
        }
    }

}
