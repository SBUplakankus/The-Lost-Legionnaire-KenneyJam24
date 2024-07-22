using System;
using Systems;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Movement")]
        private ThirdPersonActions _playerActionsAsset;

        [SerializeField] private UIController ui;
        private InputAction _move;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float movementForce = 1f;
        [SerializeField] private float maxSpeed = 5f;
        private Vector3 _forceDirection = Vector3.zero;
        [SerializeField] private Camera playerCamera;
        
        [Header("Player Info")]
        [SerializeField] private Transform[] respawns;
        [SerializeField] private BridgeManager bridgeManager;
        [SerializeField] private ResourceTracker resourceTracker;

        private void Awake()
        {
            _playerActionsAsset = new ThirdPersonActions();
        }

        private void OnEnable()
        {
            _move = _playerActionsAsset.Player.Move;
            _playerActionsAsset.Player.Enable();
        }

        private void OnDisable()
        {
            _playerActionsAsset.Player.Disable();
        }

        private void FixedUpdate()
        {
            _forceDirection += GetCameraRight(playerCamera) * (_move.ReadValue<Vector2>().x * movementForce);
            _forceDirection += GetCameraForward(playerCamera) * (_move.ReadValue<Vector2>().y * movementForce);
            
            rb.AddForce(_forceDirection, ForceMode.Impulse);
            _forceDirection = Vector3.zero;

            var horizontalVelocity = rb.velocity;
            horizontalVelocity.y = 0;
            if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
                rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;
            
            LookAt();

        }

        private static Vector3 GetCameraForward(Camera playerCamera)
        {
            var forward = playerCamera.transform.forward;
            forward.y = 0;
            return forward.normalized;
        }

        private static Vector3 GetCameraRight(Camera playerCamera)
        {
            var right = playerCamera.transform.right;
            right.y = 0;
            return right.normalized;
        }

        private void LookAt()
        {
            var direction = rb.velocity;
            direction.y = 0f;

            if (_move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
                rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
            else
                rb.angularVelocity = Vector3.zero;

        }

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
            AudioManager.instance.PlaySplash();
            transform.position = respawns[bridgeManager.progressIndex].position;
            resourceTracker.respawns++;
        }
    }
}
