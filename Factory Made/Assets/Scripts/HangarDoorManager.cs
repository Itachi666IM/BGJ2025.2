using UnityEngine;

public class HangarDoorManager : MonoBehaviour
{
    [SerializeField] private AudioClip doorCloseSound;
    [SerializeField] private GameObject hangarDoor;

    private SFX sfxPlayer;
    private void Start()
    {
        sfxPlayer = FindFirstObjectByType<SFX>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            hangarDoor.SetActive(true);
            sfxPlayer.PlayAnySFX(doorCloseSound);
            Destroy(gameObject);
        }
    }
}
