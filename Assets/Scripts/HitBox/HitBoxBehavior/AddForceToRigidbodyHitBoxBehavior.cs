using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceToRigidbodyHitBoxBehavior : HitBoxBaseBehavior
{
    public Vector3 direction;
    public float force;

    public override void action(GameObject target)
    {
        Rigidbody targetRigidbody = target.GetComponent<Rigidbody>();
        if (null != targetRigidbody)
        {
            Vector3 heading = target.transform.position - transform.position;
            heading.y = 0.0f;
            Vector3 resultDirection = heading.normalized + Vector3.up;
            targetRigidbody.AddForce(resultDirection * force);
            HitParticleManager.SpawnHitPartice(transform.position);
        }
    }
}
