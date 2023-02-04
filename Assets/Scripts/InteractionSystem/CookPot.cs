
using System;
using System.Collections.Generic;
using Events;
using Events.Events;
using Pickups;
using ScriptableEvents;
using UnityEngine;

namespace InteractionSystem
{
    public class CookPot : MonoBehaviour
    {
        [SerializeField]
        private int _amountFuelLeft;
        [SerializeField]
        private int _amountFuelPerRoot;

        [SerializeField]
        private IntScriptableEvent _fuelLeftUpdateEvent;

        [SerializeField]
        private PickupType _rootPickUpType;
        
        public List<PickupType> wantedPickupTypes;

        private EventQueue _eventQueue;

        private void Start()
        {
            _eventQueue = ServiceLocator.GetService<EventQueue>();
        }

        protected bool PickupTypeWanted(PickupType other)
        {
            return wantedPickupTypes.Contains(other);
        }
        
        private void Update()
        {
            //TODO something here with _fuelLeftUpdateEvent.Raise()
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (null != other.GetComponent<Pickup>())
            {
                Pickup pk = other.GetComponent<Pickup>();
                if (PickupTypeWanted(pk.pickupType))
                {
                    if (pk.pickupType == _rootPickUpType)
                    {
                        _amountFuelLeft += _amountFuelPerRoot;
                        _fuelLeftUpdateEvent.value = _amountFuelLeft;
                        _fuelLeftUpdateEvent.Raise();
                    }
                    else
                    {
                        _eventQueue.Add(new PickupReceivedEvent(pk.pickupType));
                    }

                    Destroy(pk.gameObject);
                }
            }
        }
    }
}