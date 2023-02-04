using Pickups;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents
{
    public class PickupTypeScriptableEventListener : MonoBehaviour, IScriptableEventListener
    {
        [SerializeField] private PickupTypeScriptableEvent Event;

        public UnityEvent<PickupType> response;
        
        [SerializeField] private bool disableObjectAfterRegister;
        private void Awake()
        {
            Event.RegisterListener(this);
            
            if(disableObjectAfterRegister) gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            Event.UnregisterListener(this);
        }
        
        public void Invoke()
        {
            response.Invoke(Event.value);
        }
    }
}