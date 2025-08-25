using UnityEngine;

public class HorrorLevelManager : MonoBehaviour
{
    SFX sfx;

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
}
