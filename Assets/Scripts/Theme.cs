using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theme : MonoBehaviour
{
    private static Theme instance = null;
    private AudioSource bgm;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance == this) return;
        Destroy(gameObject);
    }

    void Start()
    {
        bgm = GetComponent<AudioSource>();
        bgm.Play();
    }
}
