using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float timeToReload = 0.5f; // Time in seconds before the scene reloads
    [SerializeField] ParticleSystem crashEffect; // Particle effect to play on crash
    [SerializeField] AudioClip crashSound; // Sound effect to play on crash
    bool isCrashed = false; // Flag to check if the player has crashed
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground") )
        {
            FindAnyObjectByType<PlayerController>().DisableControls(); // Disable player controls
            if (!isCrashed) // Check if the player has not already crashed
            {
                isCrashed = true; // Set the crash flag to true
                GetComponent<AudioSource>().PlayOneShot(crashSound); // Play the crash sound
                
            }
            crashEffect.Play(); // Play the crash effect
            
            Invoke("ReloadScene", timeToReload); // Call ReloadScene after a delay
        }
    }
    
     private void ReloadScene()
    {
        SceneManager.LoadScene(0); // Reload the current scene

    }
}
