using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float WalkSpeed = 4f;
    public float AirSpeed = 3f;
    public float GravityForce = -9.81f;
    public float JumpForce = 10f;
    public bool Grounded = false;

    public Vector3 PlayerInput = Vector3.zero;
    public Vector3 Velocity = Vector3.zero;

    public CharacterController Controller;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = Controller.isGrounded;
        
        // Gather Input for Grounded Movement
        PlayerInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Controller.Move(PlayerInput * WalkSpeed * Time.deltaTime);

        // Apply Gravity
        if (Grounded && Velocity.y < 0f)
        {
            Velocity.y = 0f;
        }

        // Jump
        if (Input.GetButtonDown("Jump") && Grounded)
        {
            Velocity.y += JumpForce;
        }

        // Apply Gravity Acceleration & Move
        Velocity.y += GravityForce * Time.deltaTime;
        Controller.Move(Velocity * Time.deltaTime);
    }
}
