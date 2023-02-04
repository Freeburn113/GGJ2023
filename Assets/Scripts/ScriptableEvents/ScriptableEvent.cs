using System.Collections.Generic;
using UnityEngine;

namespace ScriptableEvents
{
    [CreateAssetMenu(fileName = "ScriptableEvent", menuName = "TowerDefense/Events/New ScriptableEvent")]
    public class ScriptableEvent : ScriptableObject
    {
        private List<IScriptableEventListener> _listeners = new List<IScriptableEventListener>();

        public void Raise()
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].Invoke();
        }

        public void RegisterListener(IScriptableEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void UnregisterListener(IScriptableEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}