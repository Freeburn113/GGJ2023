using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents
{
    public class IntScriptableEventListener : MonoBehaviour, IScriptableEventListener
    {
        [SerializeField] private IntScriptableEvent Event;

        public UnityEvent<int> response;
        
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