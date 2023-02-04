using UnityEngine;

namespace ScriptableEvents
{
    [CreateAssetMenu(fileName = "FloatScriptableEvent", menuName = "Events/New Float ScriptableEvent")]
    public class FloatScriptableEvent : ScriptableEvent
    {
        public float value;
    }
}