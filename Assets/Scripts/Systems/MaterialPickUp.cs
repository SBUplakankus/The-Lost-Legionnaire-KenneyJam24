using System;
using Player;
using UnityEngine;

namespace Systems
{
    public class MaterialPickUp : MonoBehaviour
    {
        [SerializeField] private ResourceTracker resourceTracker;
        [SerializeField] private PlayerAnimation playerAnimation;
        [SerializeField] private Rigidbody rb;
        

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            
            playerAnimation.PickUp();
            AudioManager.instance.PlayMaterial();
            resourceTracker.currentMaterials++;
            rb.velocity /= 2;
            Destroy(gameObject);
        }
    }
}
