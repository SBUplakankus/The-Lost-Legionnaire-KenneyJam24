using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform[] respawns;
        [SerializeField] private BridgeManager bridgeManager;

        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.CompareTag("Water"))
               Respawn();
        }

        /// <summary>
        /// Respawn the player when they hit the water
        /// </summary>
        private void Respawn()
        {
            transform.position = respawns[bridgeManager.progressIndex].position;
        }
    }
}
