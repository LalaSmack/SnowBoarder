using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{   
    [SerializeField] float timeToReload = 2f; // Time in seconds before the scene reloads
    [SerializeField] ParticleSystem finishEffect; // Particle effect to play at the finish line
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            finishEffect.Play(); // Play the finish effect
            GetComponent<AudioSource>().Play(); // Play the audio source attached to this GameObject
            Invoke("ReloadScene", timeToReload); // Call ReloadScene after a delay 
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0); // Reload the current scene

    }
}
