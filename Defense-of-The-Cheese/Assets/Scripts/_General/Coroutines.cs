﻿using System.Collections;
using UnityEngine;

public sealed class Coroutines : MonoBehaviour
{
    private static Coroutines m_instance;
    private static Coroutines instance
    {
        get
        {
            if (m_instance == null)
            {
                var go = new GameObject("[COROUTINE MANAGER]");
                m_instance = go.AddComponent<Coroutines>();
                DontDestroyOnLoad(go);
            }
            return m_instance;
        }
    }

    public static Coroutine Start(IEnumerator enumerator)
    {
        return instance.StartCoroutine(enumerator);
    }

    public static void Stop(Coroutine coroutine)
    {
        instance.StopCoroutine(coroutine);
    }
}