using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Transform mTransform;

    public Transform target;

    private void Awake()
    {
        mTransform = transform;
    }

    private void LateUpdate()
    {
        mTransform.LookAt(target);
    }
}
