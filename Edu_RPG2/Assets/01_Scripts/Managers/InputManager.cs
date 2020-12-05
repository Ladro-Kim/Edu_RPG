using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    public void OnKeyboard()
    {
        if (Input.anyKey && KeyAction != null) 
            KeyAction.Invoke();
    }

    public void OnMouse()
    {
        if (Input.GetMouseButtonDown(0))
            MouseAction.Invoke(Define.MouseEvent.Down_0);

        if (Input.GetMouseButton(0))
            MouseAction.Invoke(Define.MouseEvent.Press_0);

        if (Input.GetMouseButtonUp(0))
            MouseAction.Invoke(Define.MouseEvent.Up_0);

    }


}
