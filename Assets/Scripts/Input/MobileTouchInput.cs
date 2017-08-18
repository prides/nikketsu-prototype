using UnityEngine;

public class MobileTouchInput : BaseInput
{
    private int lastTouchCount;

    public override void InputEvent()
    {
        if (Input.touchCount != lastTouchCount)
        {
            if (Input.touchCount > lastTouchCount)
            {
                int touchIndex = Input.touchCount - 1;
                Touch touch = Input.GetTouch(touchIndex);
                OnTouchMove(touchIndex, touch.deltaPosition, InputStatus.Down);
            }
            else
            {
                int touchIndex = lastTouchCount - 1;
                if (touchIndex < 0)
                {
                    return;
                }
                OnTouchMove(touchIndex, Vector3.zero, InputStatus.Up);
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                int touchIndex = Input.touchCount - 1;
                Touch touch = Input.GetTouch(touchIndex);
                OnTouchMove(touchIndex, touch.deltaPosition, InputStatus.Move);
            }
        }

        lastTouchCount = Input.touchCount;
    }

    private void OnTouchMove(int touchIndex, Vector3 delta, InputStatus status)
    {
        Debug.Log("touchCount: " + touchIndex + " InputStatus: " + status);
        if (0 == touchIndex)
        {
            OnRotate(delta, status);
        }
        else if (1 == touchIndex)
        {
            OnMove(delta, status);
        }
    }
}
