using Pickups;
using UnityEngine;

namespace ScriptableEvents
{
    [CreateAssetMenu(fileName = "PickupTypeScriptableEvent", menuName = "Events/New PickupType ScriptableEvent")]
    public class PickupTypeScriptableEvent : ScriptableEvent
    {
        public PickupType value;
    }
}

