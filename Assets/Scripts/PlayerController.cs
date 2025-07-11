using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
  
    [SerializeField] float speed = 15f; // Speed of the player
    [SerializeField] float boostSpeed = 50f; // Speed when boosted
    SurfaceEffector2D surfaceEffector2D; // Reference to the SurfaceEffector2D component
    Rigidbody2D rb2d;
    bool canMove = true; // Flag to check if the player can move

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost(); 
        }
       
    }

    public void DisableControls()
    {
        // Disable player controls by setting the speed to 0
        surfaceEffector2D.speed = 0f;
        canMove = false; // Set the flag to false to stop player movement
    }
    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed; // Increase the speed of the surface effector
        }
        else
        {
            surfaceEffector2D.speed = speed; // Decrease the speed of the surface effector
        }
    }
    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

   
}
