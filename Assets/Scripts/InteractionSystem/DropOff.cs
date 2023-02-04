using System.Collections.Generic;
using Events;
using Events.Events;
using Pickups;
using UnityEngine;

namespace InteractionSystem
{
    public class DropOff : MonoBehaviour
    {
        public List<PickupType> wantedPickupTypes;

        private EventQueue _eventQueue;

        private void Start()
        {
            _eventQueue = ServiceLocator.GetService<EventQueue>();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (null != other.GetComponent<Pickup>())
            {
                Pickup pk = other.GetComponent<Pickup>();
                if(wantedPickupTypes.Contains(pk.pickupType))
                {
                    _eventQueue.Add(new PickupReceivedEvent(pk.pickupType));
                    Destroy(other.gameObject);
                }
                    
            }
        }
    }
}