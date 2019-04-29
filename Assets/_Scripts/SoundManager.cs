using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audio;
    public AudioClip swapSound;
    public AudioClip tickSound;
    public AudioClip rollSound;
    public static SoundManager Instance = null;

    private void Start() {
        if (Instance == null) {
            Instance = this;
        }

        audio = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip) {
        audio.clip = clip;
        audio.Play();
    }
}
