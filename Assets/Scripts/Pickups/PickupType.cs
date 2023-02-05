using UnityEngine;

namespace Pickups
{
    [CreateAssetMenu(fileName = "New PickupType", menuName = "New PickupType", order = 0)]
    public class PickupType : ScriptableObject
    {
        public int value;
    }
}