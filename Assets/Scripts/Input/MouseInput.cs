using UnityEngine;

public class MouseInput : BaseInput
{
    private const string MOUSE_WHEEL_KEY = "Mouse ScrollWheel";
    private const int MOUSE_WHEEL_POWER = 10;

    private Vector3[] mLastMousePosition = new Vector3[2];

    public override void InputEvent()
    {
        for (int i = 0; i < 2; i++)
        {
            if (Input.GetMouseButtonDown(i))
            {
                mLastMousePosition[i] = Input.mousePosition;
                OnMouseMove(i, Vector3.zero, InputStatus.Down);
            }
            if (Input.GetMouseButton(i))
            {
                OnMouseMove(i, Input.mousePosition - mLastMousePosition[i], InputStatus.Move);
                mLastMousePosition[i] = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(i))
            {
                OnMouseMove(i, Input.mousePosition - mLastMousePosition[i], InputStatus.Up);
                mLastMousePosition[i] = Vector3.zero;
            }
        }

        OnMouseMove(1, Input.GetAxis(MOUSE_WHEEL_KEY) * MOUSE_WHEEL_POWER * Vector3.forward, InputStatus.Move);
    }

    private void OnMouseMove(int button, Vector3 delta, InputStatus status)
    {
        if (0 == button)
        {
            OnMove(delta, status);
        }
        else if(1 == button)
        {
            OnRotate(delta, status);
        }
    }
}
