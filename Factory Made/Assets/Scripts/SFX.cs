using UnityEngine;
using UnityEngine.UI;
public class SFX : MonoBehaviour
{
    AudioSource myAudio;
    [SerializeField] Slider volumeSlider;
    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        ManageSingleton();
    }

    void ManageSingleton()
    {
        int instance = FindObjectsByType<SFX>(FindObjectsSortMode.None).Length;
        if(instance > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayAnySFX(AudioClip audioClip)
    {
        myAudio.PlayOneShot(audioClip);
    }

    public void UpdateVolume()
    {
        myAudio.volume = volumeSlider.value;
    }
}
