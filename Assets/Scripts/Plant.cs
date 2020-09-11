using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Plant : MonoBehaviour
{
    public enum Personality
    {
        NONE = 0,
        Cute = 1,
        Happy = 2,
        Sad = 3,
        Grumpy = 4
    }

    public class PlantEvent : UnityEvent<Plant> { }

    private float _growth = 0f;

    [SerializeField]
    private Personality _personality = Personality.Cute;
    [SerializeField]
    private Transform _root;
    [SerializeField]
    private 
    [SerializeField]
    private float MaxGrowthDuration = 5f;
    [SerializeField]
    private float MaxSize = 5f;

    public PlantEvent OnPickEvent;

    public float GetPlantSize() => Mathf.Lerp(1, MaxSize, _growth / MaxGrowthDuration);
    public bool IsFullyGrown() => _growth >= MaxGrowthDuration;
    public void PickPlant()
    {
        if (!IsFullyGrown()) return;
        OnPickEvent.Invoke(this);
        Destroy(gameObject);
    }

    private void Update()
    {
        _growth += Time.deltaTime;
        _root.localScale = new Vector3(1, GetPlantSize(), 1);
    }
}
