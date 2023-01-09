using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public AudioSource mouseClickAudioSource;


    private bool makeMouseClickNoise = true; 
    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayClickNoise();
    }

    private void PlayClickNoise()
    {
        if (makeMouseClickNoise && Input.GetMouseButtonDown(0))
        {
            mouseClickAudioSource.Play();
        }
    }
}
