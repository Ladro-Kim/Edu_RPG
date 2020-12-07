using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers Instance;
    public static Managers managers { get { Init(); return Instance; } }

    InputManager inputManager = new InputManager();
    ResourceManager resourceManager = new ResourceManager();
    SceneManagerEx sceneManager = new SceneManagerEx();
    AudioManager audioManager = new AudioManager();
    PoolManager poolManager = new PoolManager();
    DataManager datamanager = new DataManager();

    public static InputManager _input { get { return managers.inputManager; } }
    public static ResourceManager _resource { get { return managers.resourceManager; } }
    public static SceneManagerEx _scene { get { return managers.sceneManager; } }
    public static AudioManager _audio { get { return managers.audioManager; } }
    public static PoolManager _pool { get { return managers.poolManager; } }
    public static DataManager _data { get { return managers.datamanager; } }

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

            Instance.audioManager.Init();
            Instance.datamanager.Init();
        }

    }

}
