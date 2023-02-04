using System;
using UnityEngine;

namespace Pickups
{
    public class PickupSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _prefabToSpawn;

        [SerializeField]
        private Transform _spawnPosition;

        private void Update()
        {
            if (_spawnPosition)
            {
                if (_spawnPosition.transform.childCount < 1)
                {
                    Instantiate(_prefabToSpawn, _spawnPosition.transform.position, Quaternion.identity, _spawnPosition.transform);
                }
            }
            else
            {
                if (transform.childCount < 1)
                {
                    Instantiate(_prefabToSpawn, this.transform.position, Quaternion.identity, this.transform);
                }    
            }
            
        }
    }
}