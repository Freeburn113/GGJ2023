using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents
{
    public class FloatScriptableEventListener : MonoBehaviour, IScriptableEventListener
    {
        [SerializeField] private FloatScriptableEvent Event;

        public UnityEvent<float> response;
        
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