using System;
using Player;
using UnityEngine;

namespace Systems
{
    public class MaterialPickUp : MonoBehaviour
    {
        [SerializeField] private ResourceTracker resourceTracker;
        [SerializeField] private PlayerAnimation playerAnimation;
        

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            AudioManager.instance.PlayMaterial();
            playerAnimation.PickUp();
            resourceTracker.currentMaterials++;
            Destroy(gameObject);
        }
    }
}
