using UnityEngine;
using UnityEngine.SceneManagement;

public class HorrorLevelManager : MonoBehaviour
{
    SFX sfx;
    
    GameObject currentEvent;
    bool canInteract = false;
    private void Awake()
    {
        sfx = FindAnyObjectByType<SFX>();
        if(sfx == null )
        {
            Debug.Log("No SFX detected");
        }
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        if( sfx != null )
        {
            sfx.PlayAnySFX(clip);
        }
    }

    public void CanInteractWithObject(GameObject eventTrigger)
    {
        canInteract = true;
        currentEvent = eventTrigger;
        
    }

    public void Interact()
    {
        currentEvent.SetActive(true);
        currentEvent.GetComponent<InteractableEventTrigger>().UseEvent();
    }

    private void Update()
    {
        if(canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
                canInteract = false;
            }
            
        }
    }

    void WinScene()
    {
        SceneManager.LoadScene("Win");
    }

    public void DelayInLoadingScene()
    {
        Invoke(nameof(WinScene), 0.25f);
    }

}
