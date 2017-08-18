using UnityEngine;

[RequireComponent(typeof(PolarSystemTransform))]
public class OrbitControl : MonoBehaviour
{
    public Transform currentTarget;

    private BaseInput mInput;
    private PolarSystemTransform mPolarSystemTransform;

    [SerializeField]
    private ControlType currentType;

    private void Start()
    {
        mPolarSystemTransform = GetComponent<PolarSystemTransform>();

        switch (currentType)
        {
            default:
            case ControlType.Mouse:
                mInput = new MouseInput();
                break;
            case ControlType.Touch:
                mInput = new MobileTouchInput();
                break;
        }

        if (null != mInput && currentType != ControlType.None)
        {
            mInput.OnMoveEvent += OnMove;
            mInput.OnRotateEvent += OnRotate;
        }
    }

    private void Update()
    {
        if (null != currentTarget)
        {
            mPolarSystemTransform.SetBasePosition(currentTarget.position);
        }
        if (null != mInput)
        {
            mInput.InputEvent();
        }
        mPolarSystemTransform.LookAt();
    }

    private void OnDestroy()
    {
        if (null != mInput)
        {
            mInput.OnMoveEvent -= OnMove;
            mInput.OnRotateEvent -= OnRotate;
        }
    }

    private void OnMove(Vector3 delta)
    {
        mPolarSystemTransform.Move(delta);
    }

    private void OnRotate(Vector3 delta)
    {
        mPolarSystemTransform.Rotate(delta);
    }

    public enum ControlType
    {
        None,
        Mouse,
        Touch
    }
}
