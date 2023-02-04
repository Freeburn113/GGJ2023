using System.Collections.Generic;
using Events;
using Events.Events;
using NaughtyAttributes;
using Pickups;
using ScriptableEvents;
using UnityEngine;

namespace InteractionSystem
{
    public class BeerBarrel : MonoBehaviour
    {
        [SerializeField]
        private int _amountNeededForBrewing;
        [SerializeField]
        private int _amountOfServingsPerBrewing;
        
        [ReadOnly][SerializeField]
        private int _amountDroppedOff;
        [ReadOnly][SerializeField]
        private int _servingsLeft;

        [SerializeField]
        private IntScriptableEvent _servingsLeftUpdateEvent;

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
        
        protected void OnTriggerEnter(Collider other)
        {
            if (null != other.GetComponent<Pickup>())
            {
                Pickup pk = other.GetComponent<Pickup>();
                if(PickupTypeWanted(pk.pickupType))
                {
                    _amountDroppedOff++;

                    if (_amountDroppedOff >= _amountNeededForBrewing)
                    {
                        _amountDroppedOff = 0;
                        _servingsLeft += _amountOfServingsPerBrewing;
                        _servingsLeftUpdateEvent.value = _servingsLeft;
                        _servingsLeftUpdateEvent.Raise();
                    }
                    
                    _eventQueue.Add(new PickupReceivedEvent(pk.pickupType));
                    Destroy(other.gameObject);
                }
            }
        }
    }
}