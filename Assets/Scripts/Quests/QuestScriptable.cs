using System.Collections.Generic;
using Pickups;
using UnityEngine;

namespace DefaultNamespace.Quests
{
    [CreateAssetMenu(fileName = "New Quest", menuName = "New Quest")]
    public class QuestScriptable : ScriptableObject
    {
        public float timeLimitInSeconds;
        public float rewardScore;
        
        public List<PickupType> requestedItems;
    }
}