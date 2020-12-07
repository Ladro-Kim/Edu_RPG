using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    class Pool
    {

    }

    Dictionary<string, Pool> _pool = new Dictionary<string, Pool>();
    Transform root;

    public void Init()
    {
        if (root == null)
        {
            root = new GameObject { name = "@Pool_Root" }.transform;
            Object.DontDestroyOnLoad(root);
        }
    }

    public void Push()
    {

    }

    public Transform Pop(GameObject original, Transform parent = null)
    {
        // Managers._resource.Instantiate
        return null;
    }

    public void GetOriginal(string path)
    {

    }


}
