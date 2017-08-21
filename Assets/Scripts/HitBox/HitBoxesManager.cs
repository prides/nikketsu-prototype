using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxesManager : MonoBehaviour
{
    public HitBoxController[] hitBoxControllers;

    void OnHitBoxEnable(int index)
    {
        Debug.Log("OnHitBoxEnable: " + index);
        if (hitBoxControllers.Length > index)
        {
            hitBoxControllers[index].SetHitBoxEnabled();
        }
    }

    void OnHitBoxDisable(int index)
    {
        Debug.Log("OnHitBoxDisable: " + index);
        if (hitBoxControllers.Length > index)
        {
            hitBoxControllers[index].SetHitBoxDisabled();
        }
    }
}
