using UnityEngine;

public class PlayerReach : MonoBehaviour
{
    public float reachDistance;
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.green);
            Debug.Log("Object hit: " + hit.collider.gameObject.name);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * reachDistance, Color.green);
        }
    }

    public bool IsRaycastHit()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit raycast;

        return Physics.Raycast(ray, out raycast, reachDistance);
        
    }
}
