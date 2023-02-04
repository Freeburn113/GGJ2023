using System;
using System.Collections.Generic;
using DefaultNamespace.Quests;
using Events.Events;
using NaughtyAttributes;
using ScriptableEvents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class GGJManager : MonoBehaviour
    {
        [BoxGroup("Game Settings")]
        public float gameTimeInMinutes = 5;
        private float _gameTimeInSeconds;
        private float _timeSinceLastUpdate;

        [SerializeField][BoxGroup("Game Settings")]
        private float _sunStartPosition;
        [SerializeField][BoxGroup("Game Settings")]
        private float _sunEndPosition;
        
        
        private float _gameScore;

        private float _questTimerLeft;
        
        [Expandable]
        public List<QuestScriptable> quests;

        [SerializeField][Expandable][ReadOnly]
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


        [SerializeField][BoxGroup("References")] 
        private Transform _sun;
        
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

            SunLoop();
            
            if (_gameTimeInSeconds < 0)
            {
                // ServiceLocator.GetService<EventQueue>().Add(new TestDataEvent("EndGame;OutOfTime"));
                
            }
        }

        private void SunLoop()
        {
            //TODO ROTATE SUN
            // _sun.Rotate(_sun.rotation.x, Mathf.Lerp()_sun.rotation.y, _sun.rotation.z);
        }
        
        private void HandleQuests()
        {
            QuestScriptable tempQuest = ScriptableObject.CreateInstance<QuestScriptable>();
            
            int rndIndex = Random.Range(0, quests.Count - 1);

            tempQuest.requestedItems = quests[rndIndex].requestedItems;
            tempQuest.rewardScore = quests[rndIndex].rewardScore;
            tempQuest.timeLimitInSeconds = quests[rndIndex].timeLimitInSeconds;

            _currentQuest = tempQuest;

            _newQuestEvent.genericValue = _currentQuest;
            _newQuestEvent.Raise();

        }

        public void EndGame()
        {
            
        }
    }
}