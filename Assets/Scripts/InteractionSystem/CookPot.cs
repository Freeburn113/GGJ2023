using System;
using UnityEngine;

namespace InteractionSystem
{
    public class CookPot : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (null != other.GetComponent<Pickup>())
            {
                Destroy(other.gameObject);
            }
        }
    }
}