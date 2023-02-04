using UnityEngine;

namespace ScriptableEvents
{
    [CreateAssetMenu(fileName = "IntScriptableEvent", menuName = "Events/New Int ScriptableEvent")]
    public class IntScriptableEvent : ScriptableEvent
    {
        public int value;
    }
}