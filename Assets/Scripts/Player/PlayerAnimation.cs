using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator _animator;
        private Rigidbody _rb;
        private const float MaxSpeed = 3.5f;
        private const float Threshold = 0.01f;
        private float _velocityMagnitude;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _velocityMagnitude = _rb.velocity.magnitude;
            if (_velocityMagnitude < Threshold)
            {
                _velocityMagnitude = 0f;
            }
            _animator.SetFloat("Speed", _velocityMagnitude / MaxSpeed);
            
        }
    }
}
