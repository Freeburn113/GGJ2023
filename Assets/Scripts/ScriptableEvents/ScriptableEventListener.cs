using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents
{
    public class ScriptableEventListener : MonoBehaviour, IScriptableEventListener
    {
        [SerializeField] private ScriptableEvent Event;

        public UnityEvent response;

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
            response.Invoke();
        }
    }
}