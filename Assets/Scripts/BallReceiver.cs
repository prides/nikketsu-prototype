using UnityEngine;

public class BallReceiver : MonoBehaviour
{
    public Transform ballHolder;
    public GameObject targetBall;

    public bool OnBallStick(GameObject ball)
    {
        targetBall = ball;
        targetBall.transform.parent = ballHolder;
        targetBall.transform.localPosition = Vector3.zero;
        targetBall.GetComponent<Rigidbody>().isKinematic = true;
        return true;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (null != targetBall)
            {
                targetBall.transform.parent = null;
                Rigidbody ballRigidbody = targetBall.GetComponent<Rigidbody>();
                ballRigidbody.isKinematic = false;
                ballRigidbody.AddForce((transform.forward + transform.forward + transform.up).normalized * 1000);
                targetBall.SendMessage("OnBallFree");
                targetBall = null;
            }
        }
    }
}
