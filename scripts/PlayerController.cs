using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public InputAction MoveAction;
    void Start()
    {
        MoveAction.Enable();
    }

    // Update is called once per frame
    public bool FaceRight = true;

    void Update()
    {
        float horizontal = 0.0f;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -1.0f;

            Vector3 rotate = transform.eulerAngles;
            if (rotate.z == 90)
            {
                rotate.z = 90;
                transform.rotation = Quaternion.Euler(rotate);
            }
            else
            {
                if (rotate.z < 90 || rotate.z >= 270)
                {
                    rotate.z += 1;
                    transform.rotation = Quaternion.Euler(rotate);
                }
                if (rotate.z > 90 && rotate.z < 270)
                {
                    rotate.z -= 1;
                    transform.rotation = Quaternion.Euler(rotate);
                }
            }
            
            

        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 1.0f;
            Vector3 rotate = transform.eulerAngles;
            if (rotate.z == 270)
            {
                rotate.z = 270;
                transform.rotation = Quaternion.Euler(rotate);
            }
            else
            {
                if ((rotate.z < 270 && rotate.z >= 90))
                {
                    rotate.z += 1;
                    transform.rotation = Quaternion.Euler(rotate);
                }
                if (rotate.z < 90 || rotate.z > 270)
                {
                    rotate.z -= 1;
                    transform.rotation = Quaternion.Euler(rotate);
                }
            }
            Debug.Log(rotate.z);

        }
        
        Debug.Log(horizontal);
            
        float vertical = 0.0f;
        if (Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 1.0f;

            Vector3 rotate = transform.eulerAngles;
            if (rotate.z == 0 || rotate.z == 360)
            {
                rotate.z = 0;
                transform.rotation = Quaternion.Euler(rotate);
            }
            else
            {
                if (rotate.z < 360 && rotate.z >= 180)
                {
                    rotate.z += 1;
                    transform.rotation = Quaternion.Euler(rotate);
                }
                if (rotate.z > 0 && rotate.z < 180)
                {
                    rotate.z -= 1;
                    transform.rotation = Quaternion.Euler(rotate);
                }

            }
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -1.0f;
            Vector3 rotate = transform.eulerAngles;
            if (rotate.z == 180)
            {
                rotate.z = 180;
                transform.rotation = Quaternion.Euler(rotate);
            }
            else
            {
                if (rotate.z < 180)
                {
                    rotate.z += 1;
                    transform.rotation = Quaternion.Euler(rotate);
                }
                if (rotate.z > 180)
                {
                    rotate.z -= 1;
                    transform.rotation = Quaternion.Euler(rotate);
                }
            }



        }
        Debug.Log(vertical);
        if (Keyboard.current.leftArrowKey.isPressed && Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 0.8f;
            horizontal = -0.8f;

            Vector3 rotate = transform.eulerAngles;
            if (rotate.z == 45)
            {
                rotate.z = 45;
                transform.rotation = Quaternion.Euler(rotate);
            }
            else
            {
                if ((rotate.z < 45))
                {
                    rotate.z += 1;
                    transform.rotation = Quaternion.Euler(rotate);
                }
                if (rotate.z > 45)
                {
                    rotate.z -= 1;
                    transform.rotation = Quaternion.Euler(rotate);
                }
            }

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
