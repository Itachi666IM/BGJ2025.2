using UnityEngine;

public class Ghost : MonoBehaviour
{
    Animator anim;
    HorrorLevelManager levelManager;
    [SerializeField] AudioClip deathSound;
    [SerializeField] GameObject ghostDeathEvent;
    [SerializeField] GameObject newObjective;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        levelManager = FindAnyObjectByType<HorrorLevelManager>();
    }

    public void GhostDeath()
    {
        anim.SetTrigger("dead");
        levelManager.PlaySoundEffect(deathSound);
        Invoke(nameof(KillGhost), 1f);
        if(ghostDeathEvent != null && newObjective != null)
        {
            ghostDeathEvent.SetActive(true);
            newObjective.GetComponent<ObejctiveTextManager>().NextObjective();
        }
    }

    public void KillGhost()
    {
        Destroy(gameObject);
    }
}
