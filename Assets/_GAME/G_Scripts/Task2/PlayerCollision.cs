using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
public class PlayerCollision : MonoBehaviour
{
    public ParticleSystem HitEffect;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            EventManager.EmitEvent("GotHit");
            HitEffect.Play();
        }
    }
}
