using System;
using Pickups;
using UnityEngine;

namespace InteractionSystem
{
    public class CookPot : MonoBehaviour
    {
        public PickupType wantedPickupType;
        private void OnTriggerEnter(Collider other)
        {
            if (null != other.GetComponent<Pickup>())
            {
                if(other.GetComponent<Pickup>().pickupType == wantedPickupType)
                    Destroy(other.gameObject);
            }
        }
    }
}