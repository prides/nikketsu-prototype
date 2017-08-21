using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class HitParticleController : MonoBehaviour
{
    private ParticleSystem mParticle;
    public ParticleSystem particle
    {
        get
        {
            if (mParticle == null)
            {
                mParticle = GetComponent<ParticleSystem>();
            }
            return mParticle;
        }
    }
    [SerializeField]
    private bool mIsAvailable = true;
    public bool isAvailable
    {
        get { return mIsAvailable; }
    }

    public void hit(Vector3 position)
    {
        if (!mIsAvailable)
        {
            return;
        }
        transform.position = position;
        mIsAvailable = false;
        particle.Play();
        StartCoroutine(ParticleOverEvent(particle.main.duration));
    }

    IEnumerator ParticleOverEvent(float time)
    {
        yield return new WaitForSeconds(time);

        mIsAvailable = true;
        transform.localPosition = Vector3.zero;
    }
}
