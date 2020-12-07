using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinTest : MonoBehaviour
{

    Coroutine co;

    void Start()
    {
        co = StartCoroutine(CoExplodeAfterSeconds(3));
        StopCoroutine(co);
    }

    IEnumerator CoExplodeAfterSeconds(float i)
    {
        print("Entered");
        yield return new WaitForSeconds(i);
        print("Exploded");
    }
}