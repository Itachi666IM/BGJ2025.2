using UnityEngine;
using UnityEngine.Events;

public class HorrorEventTrigger : MonoBehaviour
{
    BoxCollider myCollider;
    public UnityEvent triggerEvent;
    bool once;
    private void Awake()
    {
        myCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(!once)
            {
                triggerEvent?.Invoke();
                once = true;
            }
        }
    }
}
