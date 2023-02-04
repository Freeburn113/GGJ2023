using UnityEngine;

namespace ScriptableEvents
{
    [CreateAssetMenu(fileName = "StringScriptableEvent", menuName = "TowerDefense/Events/New String ScriptableEvent")]
    public class StringScriptableEvent : ScriptableEvent
    {
        public string value;
    }
}