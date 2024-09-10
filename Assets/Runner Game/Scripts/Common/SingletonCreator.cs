using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonCreator<T> : MonoBehaviour where T:MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get => instance;
        set => instance = value;
    }
    protected virtual void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(gameObject);
            return;
        }
        instance = GetComponent<T>();
        //DontDestroyOnLoad(instance);
    }
}
