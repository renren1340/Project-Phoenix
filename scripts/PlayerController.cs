using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public InputAction MoveAction;
    public float turnSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 lastPosition;
    void Start()
    {
        MoveAction.Enable();
        rb = GetComponent<Rigidbody2D>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    public bool FaceRight = true;
    

    void Update()
    {

        Vector2 direction;
        if (rb != null && rb.linearVelocity.magnitude > 0.1f)
        {
            direction = rb.linearVelocity.normalized;
        }
        else
        {
            direction = ((Vector2)transform.position - lastPosition).normalized;
            lastPosition = transform.position;
        }

        if (direction.magnitude > 0.01f)
        {
            float targetAngle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        }


        float horizontal = 0.0f;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -1.0f;            
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 1.0f;
        }
        
        Debug.Log(horizontal);
            
        float vertical = 0.0f;
        if (Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 1.0f;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -1.0f;
        }
        Debug.Log(vertical);

        if (Keyboard.current.leftArrowKey.isPressed && Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 0.8f;
            horizontal = -0.8f;
        }

        else if(Keyboard.current.rightArrowKey.isPressed && Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 0.8f;
            horizontal = 0.8f;
        }
        else if (Keyboard.current.leftArrowKey.isPressed && Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -0.8f;
            horizontal = -0.8f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed && Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -0.8f;
            horizontal = 0.8f;
        }

        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal;
        position.y = position.y + 0.1f * vertical;
        transform.position = position;
    }
}

