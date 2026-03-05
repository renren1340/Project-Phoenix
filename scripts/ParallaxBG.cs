using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class ParallaxBG : MonoBehaviour
{

    public InputAction MoveAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = 0.0f;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -0.8f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 0.8f;
        }

        Debug.Log(horizontal);



        float vertical = 0.0f;
        if (Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 0.8f;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -0.8f;
        }
        Debug.Log(vertical);



        if (Keyboard.current.leftArrowKey.isPressed && Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 0.7f;
            horizontal = -0.7f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed && Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 0.7f;
            horizontal = 0.7f;
        }
        else if (Keyboard.current.leftArrowKey.isPressed && Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -0.7f;
            horizontal = -0.7f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed && Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -0.7f;
            horizontal = 0.7f;
        }

        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal;
        position.y = position.y + 0.1f * vertical;
        transform.position = position;
    }
}

