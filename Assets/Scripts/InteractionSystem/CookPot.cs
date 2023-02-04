
using System;
using ScriptableEvents;
using UnityEngine;

namespace InteractionSystem
{
    public class CookPot : DropOff
    {
        [SerializeField]
        private int _amountFuelLeft;
        [SerializeField]
        private int _amountFuelPerRoot;

        [SerializeField]
        private IntScriptableEvent _fuelLeftUpdateEvent;
        
        private void Update()
        {
            //TODO something here with _fuelLeftUpdateEvent.Raise()
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if (PickupTypeWanted(other.GetComponent<Pickup>().pickupType))
            {
                _amountFuelLeft += _amountFuelPerRoot;
                _fuelLeftUpdateEvent.value = _amountFuelLeft;
                _fuelLeftUpdateEvent.Raise();
            }
            base.OnTriggerEnter(other);
        }
    }
}