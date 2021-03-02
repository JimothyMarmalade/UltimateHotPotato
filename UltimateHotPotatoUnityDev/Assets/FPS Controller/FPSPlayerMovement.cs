using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerMovement : MonoBehaviour
{
    public int PlayerNum;

    public CharacterController playerController;
    public Transform groundCheck;
    public Transform player2;

    public Potato potatoReference;

    public Transform spawnLocation;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 4f;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        PlayerMove();

        if (Input.GetKeyDown("q"))
        {
            Debug.Log("Hit Q");
            transform.SetPositionAndRotation(new Vector3(-6, 3, -5), Quaternion.Euler(Vector3.zero));
            player2.transform.SetPositionAndRotation(new Vector3(-53, 3, -5), Quaternion.Euler(Vector3.zero));
            potatoReference.Respawn();

        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Player One, potatoReference.TryPickUp");
            potatoReference.TryPickUp(PlayerNum);
        }

        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("Quitting Application...");
            Application.Quit();

        }

    }

   
    public void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    public void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal1");
        float z = Input.GetAxis("Vertical1");

        Vector3 move = transform.right * x + transform.forward * z;
        playerController.Move(move* speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump1") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }
}
