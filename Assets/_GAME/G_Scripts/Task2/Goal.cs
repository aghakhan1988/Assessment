using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goalpost"))
        {
            EventManager.EmitEvent("Goal");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goalpost"))
        {
            EventManager.EmitEvent("Goal");
        }
    }
}
