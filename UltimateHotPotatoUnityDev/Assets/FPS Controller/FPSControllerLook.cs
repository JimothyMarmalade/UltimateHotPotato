using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSControllerLook : MonoBehaviour
{
    PlayerTwoGamepad controls;

    public float sensitivity = 1f;
    public Transform playerBody;
    float xRotation = 0f;

    Vector2 rotationMove;

    void Awake()
    {
        controls = new PlayerTwoGamepad();

        controls.P2.Camera.performed += ctx => rotationMove = ctx.ReadValue<Vector2>();
        controls.P2.Camera.canceled += ctx => rotationMove = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.P2.Enable();
    }

    private void OnDisable()
    {
        controls.P2.Disable();
    }


    void Update()
    {
        float controllerX = rotationMove.x * sensitivity * Time.deltaTime;
        float controllerY = rotationMove.y * sensitivity * Time.deltaTime;

        xRotation -= controllerY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * controllerX);

    }
}
