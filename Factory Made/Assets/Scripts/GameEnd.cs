using UnityEngine;

public class GameEnd : MonoBehaviour
{
    HorrorLevelManager levelManager;
    private void Awake()
    {
        levelManager = FindAnyObjectByType<HorrorLevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            levelManager.DelayInLoadingScene();
        }
    }
}
