using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    public Vector3 rotatePerMinute;

    private Transform mTransform;

    private void Awake()
    {
        mTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        mTransform.Rotate(rotatePerMinute * Time.deltaTime * (1.0f / 60.0f));
    }
}
