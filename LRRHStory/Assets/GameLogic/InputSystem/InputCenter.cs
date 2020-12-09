using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XFramework;

public class InputCenter : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            EventSystem.SendEvent(EventId.KEY_W_DOWN);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            EventSystem.SendEvent(EventId.KEY_W_UP);
        }

        if (Input.GetKey(KeyCode.W))
        {
            EventSystem.SendEvent(EventId.KEY_W);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            EventSystem.SendEvent(EventId.KEY_S_DOWN);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            EventSystem.SendEvent(EventId.KEY_S_UP);
        }

        if (Input.GetKey(KeyCode.S))
        {
            EventSystem.SendEvent(EventId.KEY_S);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            EventSystem.SendEvent(EventId.KEY_A_DOWN);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            EventSystem.SendEvent(EventId.KEY_A_UP);
        }

        if (Input.GetKey(KeyCode.A))
        {
            EventSystem.SendEvent(EventId.KEY_A);  
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            EventSystem.SendEvent(EventId.KEY_D_DOWN);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            EventSystem.SendEvent(EventId.KEY_D_UP);
        }

        if (Input.GetKey(KeyCode.D))
        {
            EventSystem.SendEvent(EventId.KEY_D);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventSystem.SendEvent(EventId.KEY_SPACE_DOWN);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            EventSystem.SendEvent(EventId.KEY_SPACE_UP);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            EventSystem.SendEvent(EventId.KEY_SPACE);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            EventSystem.SendEvent(EventId.KEY_X_DOWN);
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            EventSystem.SendEvent(EventId.KEY_X_UP);
        }

        if (Input.GetKey(KeyCode.X))
        {
            EventSystem.SendEvent(EventId.KEY_X);
        }
    }
}
