using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [Header ("--------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;

    [Header("----------- Audio Clip -----------")]
    public AudioClip background;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
