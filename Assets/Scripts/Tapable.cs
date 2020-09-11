using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tapable : MonoBehaviour, ITapable
{
    public UnityEvent OnTappedEvent = new UnityEvent();
    public void IsTapped()
    {
        OnTappedEvent.Invoke();
    }
}
