using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticleManager : MonoBehaviour
{
    private static HitParticleManager instance;

    void Awake()
    {
        if (null != instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public HitParticleController[] hitParticleControllers;

    public static void SpawnHitPartice(Vector3 position)
    {
        if (null != instance)
        {
            instance.spawn(position);
        }
    }

    private void spawn(Vector3 position)
    {
        foreach (HitParticleController controller in hitParticleControllers)
        {
            if (controller.isAvailable)
            {
                controller.hit(position);
            }
        }
    }
}
