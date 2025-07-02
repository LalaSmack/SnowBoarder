using UnityEngine;

public class Dustrails : MonoBehaviour
{
    [SerializeField] ParticleSystem snowParticleSystem; // Reference to the snow particle system

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            snowParticleSystem.Play(); // Play the snow particle system when the player enters the trigger
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            snowParticleSystem.Stop(); // Stop the snow particle system when the player exits the trigger
        }
    }
}
