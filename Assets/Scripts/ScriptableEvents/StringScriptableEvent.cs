using UnityEngine;

namespace ScriptableEvents
{
    [CreateAssetMenu(fileName = "StringScriptableEvent", menuName = "Events/New String ScriptableEvent")]
    public class StringScriptableEvent : ScriptableEvent
    {
        public string value;
    }
}