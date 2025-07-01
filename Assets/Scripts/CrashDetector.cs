using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float timeToReload = 0.5f; // Time in seconds before the scene reloads
    [SerializeField] ParticleSystem crashEffect; // Particle effect to play on crash
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground") )
        {
            crashEffect.Play(); // Play the crash effect
            Invoke("ReloadScene", timeToReload); // Call ReloadScene after a delay
        }
    }
    
     private void ReloadScene()
    {
        SceneManager.LoadScene(0); // Reload the current scene

    }
}
