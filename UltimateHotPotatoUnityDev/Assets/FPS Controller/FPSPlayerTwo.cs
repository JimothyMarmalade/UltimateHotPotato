using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSPlayerTwo : MonoBehaviour
{

    public int PlayerNum;
    public Potato potatoReference;
    PlayerTwoGamepad controls;

    public CharacterController playerController;
    public Transform groundCheck;

    public Transform spawnLocation;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 4f;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    Vector2 controllerMove;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerTwoGamepad();

        controls.P2.Jump.performed += ctx => Jump();
        controls.P2.Respawn.performed += ctx => Respawn();
        controls.P2.Movement.performed += ctx => controllerMove = ctx.ReadValue<Vector2>();
        controls.P2.Movement.canceled += ctx => controllerMove = Vector2.zero;
        controls.P2.Pickup.performed += ctx => GrabItem();
    }

    private void OnEnable()
    {
        controls.P2.Enable();
    }

    private void OnDisable()
    {
        controls.P2.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        JumpCheck();
        PlayerMove();
    }

    public void GrabItem()
    {
        Debug.Log("Player two, GrabItem()");
        potatoReference.TryPickUp(PlayerNum);
    }
    void Respawn()
    {
        Debug.Log("Hit Respawn");
        transform.SetPositionAndRotation(new Vector3Int(-53, 3, -5), Quaternion.Euler(Vector3.zero));
    }

    void Jump()
    {
        //Debug.Log("Running Jump with isGrounded: " + isGrounded);
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void JumpCheck()
    {
        //Debug.Log("Running groundcheck()");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    public void PlayerMove()
    {
        float x = controllerMove.x;
        float z = controllerMove.y;

        Vector3 move = transform.right * x + transform.forward * z;
        playerController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }
}
