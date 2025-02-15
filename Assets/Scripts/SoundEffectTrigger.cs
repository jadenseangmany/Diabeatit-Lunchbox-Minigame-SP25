using UnityEngine;

public class SoundEffectTrigger : MonoBehaviour
{
    public AudioSource audioSource;  // Reference to the AudioSource
    public AudioClip soundEffect;    // Reference to the AudioClip

    // Method to be called by the button click event
    public void PlaySoundEffect()
    {
        // Play the assigned sound effect
        audioSource.PlayOneShot(soundEffect);
    }
}