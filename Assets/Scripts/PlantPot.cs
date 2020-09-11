using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPot : MonoBehaviour
{
    [SerializeField]
    private Plant _prefab;
    [SerializeField]
    private Transform _root;
    private Plant _currentPlant;
    private bool _hasPlant = false;

    private void Update()
    {
        if (!_hasPlant)
        {
            SpawnPlant();
        }
    }

    private void SpawnPlant()
    {
        _currentPlant = Instantiate(_prefab, _root);
        _currentPlant.OnPickEvent.AddListener(OnPlantDestroyed);
        _hasPlant = true;
    }

    private void OnPlantDestroyed(Plant plant)
    {
        _currentPlant = null;
        _hasPlant = false;
    }
}
