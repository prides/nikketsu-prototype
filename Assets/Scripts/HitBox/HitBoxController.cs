using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class HitBoxController : MonoBehaviour
{
    public string contactTag = "Enemy";

    private BoxCollider mHitBoxCache;
    private BoxCollider hitBox
    {
        get
        {
            if (null == mHitBoxCache)
            {
                mHitBoxCache = GetComponent<BoxCollider>();
            }
            return mHitBoxCache;
        }
    }

    private HitBoxBaseBehavior mHitBoxBehaviorCache;
    private HitBoxBaseBehavior hitBoxBehavior
    {
        get
        {
            if (null == mHitBoxBehaviorCache)
            {
                mHitBoxBehaviorCache = GetComponent<HitBoxBaseBehavior>();
            }
            return mHitBoxBehaviorCache;
        }
    }

    public void SetHitBoxEnabled()
    {
        hitBox.enabled = true;
    }

    public void SetHitBoxDisabled()
    {
        hitBox.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == contactTag && other.isTrigger)
        {
            Debug.Log("hit " + other.name);
            if (null != hitBoxBehavior)
            {
                hitBoxBehavior.action(other.gameObject);
            }
            else
            {
                Debug.LogWarning("HitBoxBaseBehavior is not exist in gameobject " + gameObject.name);
            }
        }
    }
}
