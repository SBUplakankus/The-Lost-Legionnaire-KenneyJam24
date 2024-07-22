using Player;
using UnityEngine;

namespace Systems
{
    public class CollectiblePickUp : MonoBehaviour
    {
        [SerializeField] private ResourceTracker resourceTracker;
        [SerializeField] private PlayerAnimation playerAnimation;
        [SerializeField] private Rigidbody rb;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            
            playerAnimation.PickUp();
            AudioManager.instance.PlayCollectible();
            resourceTracker.collectiblesFound++;
            rb.velocity = rb.velocity /= 2;
            Destroy(gameObject);
        }
    }
}
