using UnityEngine;
using System.Collections;

public class PolarSystemTransform : MonoBehaviour
{
    private Transform mTransform;

    [SerializeField]
    private Coordinate mCurrentCoordinate;


    private Vector3 mBasePosition = Vector3.zero;
    private Vector3 mAdditionalPosition;

    private void Awake()
    {
        mTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        MoveTo(mCurrentCoordinate);
    }

    private IEnumerator MoveTo(Coordinate pos, float duration)
    {
        float progess = 0.0f;
        float step = Time.deltaTime / duration;
        while (progess <= 1.0f)
        {
            progess += step;
            MoveTo(Coordinate.Lerp(mCurrentCoordinate, pos, progess));
            yield return new WaitForEndOfFrame();
        }
    }

    public void SetBasePosition(Vector3 position)
    {
        mBasePosition = position;
        MoveTo(mCurrentCoordinate);
    }

    public void GoToPosition(Coordinate destination, float duration)
    {
        StartCoroutine(MoveTo(destination, duration));
    }

    public void MoveTo(Coordinate coordinate)
    {
        mCurrentCoordinate = coordinate;
        mAdditionalPosition = Converter.CoordinateToVector3(mCurrentCoordinate);
        mTransform.position = mBasePosition + mAdditionalPosition;
    }

    public void LookAt()
    {
        LookAt(mBasePosition);
    }

    public void LookAt(Vector3 target)
    {
        mTransform.LookAt(target);
    }

    public void Move(Vector3 delta)
    {
        mBasePosition += mTransform.TransformVector(delta);
        MoveTo(mCurrentCoordinate);
    }

    public void Rotate(Vector3 delta)
    {
        mCurrentCoordinate.Latitude += delta.y;
        mCurrentCoordinate.Longitude += delta.x;
        mCurrentCoordinate.Altitude += delta.z;
        MoveTo(mCurrentCoordinate);
    }
}
