using UnityEngine;

public class HangarDoorManager : MonoBehaviour
{
    [SerializeField] private GameObject hangarDoor;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            hangarDoor.SetActive(true);
            Destroy(gameObject);
        }
    }
}
