using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] float detectRange;
    public LayerMask ghostLayer;

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,detectRange,ghostLayer))
        {
            Debug.Log("Ghost Detected");
            hit.collider.GetComponent<Ghost>().GhostDeath();
        }
    }
}
