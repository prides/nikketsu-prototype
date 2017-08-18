using UnityEngine;
using System.Collections;

public abstract class BaseInput
{
    public delegate void OnInputEventDelegate(Vector3 delta);

    public event OnInputEventDelegate OnMoveEvent;
    public event OnInputEventDelegate OnRotateEvent;

    public abstract void InputEvent();

    public void OnMove(Vector3 delta, InputStatus status)
    {
        if (null != OnMoveEvent)
        {
            OnMoveEvent(delta);
        }
    }

    public void OnRotate(Vector3 delta, InputStatus status)
    {
        if (null != OnRotateEvent)
        {
            OnRotateEvent(delta);
        }
    }

    public enum InputStatus
    {
        None,
        Down,
        Move,
        Up
    }
}
