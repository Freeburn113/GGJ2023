using ScriptableEvents;
using UnityEngine;

namespace InteractionSystem
{
    public class BeerBarrel : DropOff
    {
        [SerializeField]
        private int _amountNeededForBrewing;
        [SerializeField]
        private int _amountOfServingsPerBrewing;
        
        private int _amountDroppedOff;
        private int _servingsLeft;

        [SerializeField]
        private IntScriptableEvent _servingsLeftUpdateEvent;

        protected override void OnTriggerEnter(Collider other)
        {
            _amountDroppedOff++;

            if (_amountDroppedOff >= _amountNeededForBrewing)
            {
                _amountDroppedOff = 0;
                _servingsLeft += _amountOfServingsPerBrewing;
            }
            
            base.OnTriggerEnter(other);
        }
    }
}