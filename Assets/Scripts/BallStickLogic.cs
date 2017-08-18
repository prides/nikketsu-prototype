using UnityEngine;
using System.Collections;

public class BallStickLogic : MonoBehaviour
{
    public string targetTag = "Player";
    public bool isAvailable = true;

    void OnTriggerEnter(Collider other)
    {
        if (isAvailable && other.tag == targetTag)
        {
            if (other.gameObject.GetComponent<BallReceiver>().OnBallStick(gameObject))
            {
                isAvailable = false;
            }
        }
    }

    void OnBallFree()
    {
        StartCoroutine(setAvailable(1.0f));
    }

    IEnumerator setAvailable(float delay)
    {
        yield return new WaitForSeconds(delay);
        isAvailable = true;
    }
}
