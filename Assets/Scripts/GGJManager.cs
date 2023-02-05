using System;
using System.Collections.Generic;
using DefaultNamespace.Quests;
using Events;
using Events.Events;
using NaughtyAttributes;
using Pickups;
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

        [BoxGroup("Game Settings")] 
        [SerializeField] float _timeBetweenQuests = 10;

        private float _timeTillNextQuest = 10;
        
        private float _gameScore;

        
        public List<List<PickupType>> quests;

        [BoxGroup("Game Settings")][SerializeField]
        private List<PickupType> _pickupTypes;

        [SerializeField][BoxGroup("ScriptableEvents")] 
        private IntScriptableEvent _timerUpdateEvent;
        [SerializeField][BoxGroup("ScriptableEvents")]
        private IntScriptableEvent _newQuestEvent;
        [SerializeField][BoxGroup("ScriptableEvents")]
        private IntScriptableEvent _questCompletedEvent;
        [SerializeField][BoxGroup("ScriptableEvents")]
        private IntScriptableEvent _scoreUpdateEvent;
        [SerializeField][BoxGroup("ScriptableEvents")]
        private IntScriptableEvent _questTimerUpdateEvent;

        [SerializeField] [BoxGroup("Refs")] private QuestUI _ui1;
        [SerializeField] [BoxGroup("Refs")] private QuestUI _ui2;
        [SerializeField] [BoxGroup("Refs")] private QuestUI _ui3;

        private List<QuestUI> _uis;
        private void Start()
        {
            _gameTimeInSeconds = gameTimeInMinutes * 60;

            PickupReceivedEvent.Handlers += PickupReceivedHandler;
            quests = new List<List<PickupType>>();

            _uis = new List<QuestUI>();
            _uis.Add(_ui1);
            _uis.Add(_ui2);
            _uis.Add(_ui3);
        }

        private void OnDestroy()
        {
            PickupReceivedEvent.Handlers -= PickupReceivedHandler;
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


            QuestLoop();

            if (_gameTimeInSeconds < 0)
            {
                // ServiceLocator.GetService<EventQueue>().Add(new TestDataEvent("EndGame;OutOfTime"));
                
            }
        }


        private void QuestLoop()
        {
            _timeTillNextQuest -= Time.deltaTime;
            if (_timeTillNextQuest <= 0)
            {
                if (quests.Count < 3)
                {
                    GenerateNewQuest();
                }
                
                _timeTillNextQuest = _timeBetweenQuests;
            }
        }

        private void GenerateNewQuest()
        {
            List<PickupType> newQuest = new List<PickupType>();
            int meshid = 0;
            switch (Random.Range(0, 100))
            {
                case int n when (n <= 66):
                    for (int i = 0; i < 3; i++)
                    {
                        newQuest.Add(GenerateNewPickup());
                    }

                    meshid = 0;
                    break;
                case int n when (n <= 90):
                    for (int i = 0; i < 5; i++)
                    {
                        newQuest.Add(GenerateNewPickup());
                    }

                    meshid = 1;
                    break;
                case int n when (n >= 91):
                    for (int i = 0; i < 5; i++)
                    {
                        newQuest.Add(GenerateNewPickup(true));
                    }

                    meshid = 2;
                    break;
            }

            quests.Add(newQuest);
            _newQuestEvent.value = quests.IndexOf(newQuest);
            _newQuestEvent.Raise();

            
            _uis[quests.IndexOf(newQuest)].FillQuestUI(newQuest);
            
            
            CustomerEvent evt = new CustomerEvent(quests.IndexOf(newQuest), meshid);
            ServiceLocator.GetService<EventQueue>().Add(evt);
        }

        private PickupType GenerateNewPickup(bool IsRare = false)
        {
            int mod = (IsRare) ? 0 : 20;

            switch (Random.Range(0, 100))
            {
                case int n when (n + mod <= 20):
                    return _pickupTypes[0];
                case int n when (n + mod <= 40):
                    return _pickupTypes[1]; 
                case int n when (n + mod <= 50):
                    return _pickupTypes[2];
                case int n when (n + mod <= 60):
                    return _pickupTypes[3];
                case int n when (n + mod <= 70):
                    return _pickupTypes[4];
                case int n when (n + mod <= 80):
                    return _pickupTypes[5];
                case int n when (n + mod <= 90):
                    return _pickupTypes[6];
                case int n when (n + mod <= 94):
                    return _pickupTypes[7];
                case int n when (n + mod <= 97):
                    return _pickupTypes[8];
                case int n when (n + mod <= 100):
                    return _pickupTypes[9];
                case int n when (n + mod > 100):
                    return _pickupTypes[9];
            }

            return _pickupTypes[1];
        }
        
        public void EndGame()
        {
            
        }
        
        private void PickupReceivedHandler(PickupReceivedEvent e)
        {
            foreach (List<PickupType> quest in quests)
            {
                if (quest.Contains(e.pickupType))
                {
                    _gameScore += e.pickupType.value;
                    quest.Remove(e.pickupType);
                    _uis[quests.IndexOf(quest)].FillQuestUI(quest);
                    if (quest.Count <= 0)
                    {
                        _questCompletedEvent.value = quests.IndexOf(quest);
                        quests.Remove(quest);
                        _questCompletedEvent.Raise();
                        //finish quest 
                    }
                }
            }
        }
    }
}