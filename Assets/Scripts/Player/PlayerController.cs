using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform[] respawns;
        [SerializeField] private BridgeManager bridgeManager;
        [SerializeField] private ResourceTracker resourceTracker;

        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.CompareTag("Water"))
               Respawn();
        }

        /// <summary>
        /// Respawn the player when they hit the water
        /// </summary>
        public void Respawn()
        {
            transform.position = respawns[bridgeManager.progressIndex].position;
            resourceTracker.respawns++;
        }
    }
}
