using System;
using ScriptableEvents;
using UnityEngine;

namespace InteractionSystem
{
    public class Phone : MonoBehaviour, IScriptableEventListener
    {

        [SerializeField]
        private ScriptableEvent _newQuestEvent;

        private void Start()
        {
            _newQuestEvent.RegisterListener(this);
        }

        private void OnDestroy()
        {
            _newQuestEvent.UnregisterListener(this);
        }

        public void Invoke()
        {
            PlayRinging();
        }


        public void PlayRinging()
        {
            Debug.Log("ring ring");
        }
        
    }
}