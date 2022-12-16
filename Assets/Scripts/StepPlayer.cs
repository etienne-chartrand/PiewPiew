using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StepPlayer : MonoBehaviour
{
    // Declare the step sounds list and the AudioSource component
    public List<AudioClip> stepSounds;
    public AudioSource audioSource;

    // Other fields and functions go here

    void Update()
    {
        // Check if the player is moving
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            // If the audio is not playing, play a random step sound
            if (!audioSource.isPlaying)
            {
                int index = Random.Range(0, stepSounds.Count);
                audioSource.PlayOneShot(stepSounds[index]);
            }
        }
    }

}

