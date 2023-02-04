using System;
using System.Collections.Generic;
using DefaultNamespace.Quests;
using NaughtyAttributes;
using ScriptableEvents;
using UnityEngine;

namespace DefaultNamespace
{
    public class GGJManager : MonoBehaviour
    {
        [BoxGroup("Game Settings")]
        public float gameTimeInMinutes = 5;
        private float _gameTimeInSeconds;
        private float _timeSinceLastUpdate;
        
        private float _gameScore;

        private float _questTimerLeft;
        
        [Expandable]
        public List<QuestScriptable> quests;

        private QuestScriptable _currentQuest;

        [SerializeField][BoxGroup("ScriptableEvents")] 
        private IntScriptableEvent _timerUpdateEvent;
        [SerializeField][BoxGroup("ScriptableEvents")]
        private ScriptableEvent _newQuestEvent;
        [SerializeField][BoxGroup("ScriptableEvents")]
        private ScriptableEvent _questCompletedEvent;
        [SerializeField][BoxGroup("ScriptableEvents")]
        private IntScriptableEvent _scoreUpdateEvent;
        [SerializeField][BoxGroup("ScriptableEvents")]
        private IntScriptableEvent _questTimerUpdateEvent;
        
        
        private void Start()
        {
            _gameTimeInSeconds = gameTimeInMinutes * 60;
        }

        private void Update()
        {
            _gameTimeInSeconds -= Time.deltaTime;
            _timeSinceLastUpdate += Time.deltaTime;
            if (_timeSinceLastUpdate > 1)
            {
                _timerUpdateEvent.value = Mathf.RoundToInt(_gameTimeInSeconds);
                _timerUpdateEvent.Raise();
                _timeSinceLastUpdate = 0;
            }
            
            if (_gameTimeInSeconds < 0)
            {
                // ServiceLocator.GetService<EventQueue>().Add(new TestDataEvent("EndGame;OutOfTime"));
                
            }
        }

        private void HandleQuests()
        {
            
        }

        public void EndGame()
        {
            
        }
    }
}