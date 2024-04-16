using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
public class Collectible : MonoBehaviour
{
    public string CollectibleType;
    public GameObject CollectEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventManager.EmitEvent(CollectibleType);
            Instantiate(CollectEffect, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
