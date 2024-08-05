using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sainna.Utils
{
    public class CircleSpawner : MonoBehaviour
    {
        [SerializeField] GameObject _ToSpawn = null;

        [SerializeField] Transform _LookTransform = null;

        [SerializeField] float _Radius = 1;

        [SerializeField] int _NmbrOfItem = 7;

        [SerializeField, Range(1.0f, 360.0f)] float _Angle = 360.0f;

        [SerializeField] bool _Behind = true;

        public List<GameObject> SpawnedItems { get; private set; } = new List<GameObject>();

        void Awake()
        {
            SpawnItems();
        }

        public void RemoveItems()
        {
            foreach (GameObject go in SpawnedItems)
            {
                Destroy(go);
            }

            SpawnedItems.Clear();
        }

        public void SpawnItems()
        {
            if (SpawnedItems.Count != 0)
            {
                RemoveItems();
            }

            float angleDistance = (1.0f / (float)_NmbrOfItem) * (_Angle * Mathf.Deg2Rad);
            float currentAngle = angleDistance;
            for (int i = 0; i < _NmbrOfItem; i++)
            {
                Vector3 spawnPosition = new Vector3(_Radius * Mathf.Cos(currentAngle + (_Behind ? Mathf.PI : 0)), 0,
                    _Radius * Mathf.Sin(currentAngle + (_Behind ? Mathf.PI : 0)));
                spawnPosition += transform.position;
                GameObject spawnedGo = Instantiate(_ToSpawn,
                    spawnPosition,
                    Quaternion.LookRotation(
                        (_LookTransform == null ? transform.position : _LookTransform.position) - spawnPosition,
                        transform.up));

                SpawnedItems.Add(spawnedGo);
                currentAngle += angleDistance;
            }
        }
    }
}