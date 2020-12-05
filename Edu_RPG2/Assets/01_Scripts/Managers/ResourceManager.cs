using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string objectName, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{objectName}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : Prefabs/{objectName}");
            return null;
        }
        return Object.Instantiate(prefab, parent);
    }

    public void Destroy(GameObject go, int time = 0)
    {
        Object.Destroy(go, time);
    }



}
