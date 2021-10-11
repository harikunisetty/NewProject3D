using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu<T> : Menu where T : Menu<T>
{
    private static T instance;
    public static T Instance => instance;

    protected virtual void Awake()
    {
        if (Instance != null)
            DestroyImmediate(this.gameObject);
        else
            instance = (T)this;

        DontDestroyOnLoad(this);
    }

    protected virtual void OnDestory()
    {
        instance = null;
    }
 }

public abstract class Menu : MonoBehaviour
{
    //private static Menu instance;
    //public static Menu Instance { get { return instance; } }

    //void Awake()
    //{
    //    if (Instance != null)
    //        DestroyImmediate(this.gameObject);
    //    else
    //        instance = this;
    //}

    //void OnDestory()
    //{
    //    instance = null;
    //}

    public virtual void BackButton()
    {
        if (MenuManager.Instance != null)
        {
            MenuManager.Instance.CloseMenu();
        }
    }
}
    

