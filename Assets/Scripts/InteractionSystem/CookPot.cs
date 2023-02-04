
using UnityEngine;

namespace InteractionSystem
{
    public class CookPot : DropOff
    {
        [SerializeField]
        private int _amountFuelLeft;
        [SerializeField]
        private int _amountFuelPerRoot;

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
        }
    }
}