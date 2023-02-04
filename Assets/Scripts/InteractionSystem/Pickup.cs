using System;
using Pickups;
using UnityEngine;

namespace InteractionSystem
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Pickup : MonoBehaviour
    {
        public PickupType pickupType;
        
        private Collider _collider;
        private Rigidbody _rigidbody;
        
        private void Start()
        {
            _collider = GetComponent<Collider>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void TogglePhysics(bool enabled)
        {
            _collider.enabled = enabled;
            _rigidbody.useGravity = enabled;
        }
    }
}