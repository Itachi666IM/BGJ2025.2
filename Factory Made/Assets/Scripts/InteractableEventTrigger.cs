using UnityEngine;
using UnityEngine.Events;
public class InteractableEventTrigger : MonoBehaviour
{
    public UnityEvent interactableEventTrigger;

    public void UseEvent()
    {
        interactableEventTrigger?.Invoke();
    }
}
