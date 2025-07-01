using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float timeToReload = 0.5f; // Time in seconds before the scene reloads
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Invoke("ReloadScene", timeToReload); // Call ReloadScene after a delay
        }
    }
    
     private void ReloadScene()
    {
        SceneManager.LoadScene(0); // Reload the current scene

    }
}
