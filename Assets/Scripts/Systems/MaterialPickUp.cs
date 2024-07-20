using System;
using Player;
using UnityEngine;

namespace Systems
{
    public class MaterialPickUp : MonoBehaviour
    {
        private ResourceTracker _resourceTracker;

        private void Start()
        {
            _resourceTracker = ResourceTracker.instance;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Plank Entered");
            if (!other.gameObject.CompareTag("Player")) return;
            
            _resourceTracker.currentMaterials++;
            Destroy(gameObject);
        }
    }
}
