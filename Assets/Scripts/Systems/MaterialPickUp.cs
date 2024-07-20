using System;
using Player;
using UnityEngine;

namespace Systems
{
    public class MaterialPickUp : MonoBehaviour
    {
        [SerializeField] private ResourceTracker resourceTracker;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            
            resourceTracker.currentMaterials++;
            Destroy(gameObject);
        }
    }
}
