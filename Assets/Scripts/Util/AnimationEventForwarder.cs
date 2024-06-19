using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventForwarder : MonoBehaviour
{
    [SerializeField] private List<ForwardEvent> forwardEvents;
    
    public void Forward(string eventName)
    {
        forwardEvents.Find(e => e.name == eventName).Call();
    }

    [System.Serializable]
    public struct ForwardEvent
    {
        public string name;
        
        [SerializeField] private UnityEvent onEvent;

        public void Call() => onEvent.Invoke();
    }
}
