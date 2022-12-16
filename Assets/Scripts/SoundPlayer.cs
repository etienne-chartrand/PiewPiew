using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // Drag and drop the AudioClip that you want to play in the Inspector
    public AudioClip soundToPlay;

    // Drag and drop the UIManager script that has the isDead bool in the Inspector
    public UIManager uiManager;

    // The AudioSource component is used to play audio clips
    private AudioSource audioSource;

    private bool hasPlayed = false;

    void Start()
    {
        // Get the AudioSource component of this game object
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if the isDead bool from the UIManager script is true
        if (uiManager.isDead && !hasPlayed)
        {
            // Play the audio clip
            audioSource.PlayOneShot(soundToPlay);

            hasPlayed = true;
        }
    }
}
