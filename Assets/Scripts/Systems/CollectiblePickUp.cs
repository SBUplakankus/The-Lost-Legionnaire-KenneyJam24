using Player;
using UnityEngine;

namespace Systems
{
    public class CollectiblePickUp : MonoBehaviour
    {
        [SerializeField] private ResourceTracker resourceTracker;
        [SerializeField] private PlayerAnimation playerAnimation;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            
            AudioManager.instance.PlayCollectible();
            playerAnimation.PickUp();
            resourceTracker.collectiblesFound++;
            Destroy(gameObject);
        }
    }
}
