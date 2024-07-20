using Player;
using UnityEngine;

namespace Systems
{
    public class CollectiblePickUp : MonoBehaviour
    {
        [SerializeField] private ResourceTracker resourceTracker;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            
            resourceTracker.collectiblesFound++;
            Destroy(gameObject);
        }
    }
}
