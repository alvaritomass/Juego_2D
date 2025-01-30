using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 3.0f;
    public float jumpHeight = 3.0f;
    public float gravity = 9.8f;

    public CharacterController characterController;
    public Camera playerCamera;
    private Vector3 moveDirection;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        //Movimiento en el plano XY
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 inputDir = new Vector3(horizontal, 0.0f, vertical);
        Vector3 moveDir = transform.TransformDirection(inputDir);
        moveDirection = new Vector3(moveDir.x * speed, moveDirection.y, moveDir.z * speed);


        //Mover la cámara con el ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseY);
        playerCamera.transform.Rotate(Vector3.left * mouseY);


        //Aplicar gravedad
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }


        //Salto
        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
        }

        //Aplicar movimiento al CharacterController
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
