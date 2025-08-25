using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    AudioSource myAudio;
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip horrorMusic;
    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.clip = menuMusic;
        myAudio.Play();
        ManageSingleton();
    }

    void ManageSingleton()
    {
        int instance = FindObjectsByType<AudioManager>(FindObjectsSortMode.None).Length;
        if(instance > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name== "Horror_Scene")
        {
            myAudio.clip = horrorMusic;
        }
        if(!myAudio.isPlaying)
        {
            myAudio.Play();
        }
    }
}
