using UnityEngine;
using UnityEngine.SceneManagement;
public class Ghost : MonoBehaviour
{
    Animator anim;
    HorrorLevelManager levelManager;
    [SerializeField] AudioClip deathSound;
    [SerializeField] GameObject ghostDeathEvent;
    [SerializeField] GameObject newObjective;
    public bool isChasingPlayer = false;
    Rigidbody rb;
    PlayerMovement player;
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    float speed;
    bool once;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        levelManager = FindAnyObjectByType<HorrorLevelManager>();
        rb = GetComponent<Rigidbody>();
        player = FindAnyObjectByType<PlayerMovement>();
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        if(isChasingPlayer)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            rb.MovePosition(pos);
            transform.LookAt(player.transform.position);
            if(Vector3.Distance(player.transform.position, transform.position)<4.0f)
            {
                anim.SetBool("isAttacking", true);
            }
            else
            {
                anim.SetBool("isAttacking", false);
            }
        }
    }

    public void GhostDeath()
    {
        anim.SetTrigger("dead");
        
        Invoke(nameof(KillGhost), 0.5f);
        if(ghostDeathEvent != null && newObjective != null && !once)
        {
            once = true;
            ghostDeathEvent.SetActive(true);
            newObjective.GetComponent<ObejctiveTextManager>().NextObjective();
        }
    }

    public void KillGhost()
    {
        levelManager.PlaySoundEffect(deathSound);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
