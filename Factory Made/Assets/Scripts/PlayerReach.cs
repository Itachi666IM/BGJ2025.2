using UnityEngine;

public class PlayerReach : MonoBehaviour
{
    public float reachDistance;

    public bool IsRaycastHit()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit raycast;

        return Physics.Raycast(ray, out raycast, reachDistance);
        
    }
}
