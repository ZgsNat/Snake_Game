using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    [System.Obsolete]
    public void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if(musicObj.Length > 1)
        {
            DestroyObject(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
