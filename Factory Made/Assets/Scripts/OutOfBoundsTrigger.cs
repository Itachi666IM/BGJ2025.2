using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
public class OutOfBoundsTrigger : MonoBehaviour
{

    [SerializeField] private TMP_Text warningText;
    public string[] warningSentences;
    public AudioClip[] sfxClips;
    public float typeSpeed;
    SFX sfx;

    private void Awake()
    {
        warningText.text = "";
        sfx = FindAnyObjectByType<SFX>();
    }
    IEnumerator Type(string sentence)
    {
        foreach(char c in sentence)
        {
            warningText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "drag" && other.GetComponent<Sack>()!=null)
        {
            Destroy(other.gameObject);
            StartCoroutine(RestartScene());
           
        }
    }

    IEnumerator RestartScene()
    {
        warningText.text = "";
        string randomSentence = warningSentences[Random.Range(0, warningSentences.Length)];
        AudioClip randomSFX = sfxClips[Random.Range(0, sfxClips.Length)];
        sfx.PlayAnySFX(randomSFX);
        StartCoroutine(Type(randomSentence));
        yield return new WaitUntil(() => warningText.text == randomSentence);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
