using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
public class OutOfBoundsTrigger : MonoBehaviour
{

    [SerializeField] private TMP_Text warningText;
    public string[] warningSentences;
    public float typeSpeed;
    private void Awake()
    {
        warningText.text = "";
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
        if(other.tag == "drag")
        {
            StartCoroutine(RestartScene());
           
        }
    }

    IEnumerator RestartScene()
    {
        warningText.text = "";
        string randomSentence = warningSentences[Random.Range(0, warningSentences.Length)];
        StartCoroutine(Type(randomSentence));
        yield return new WaitUntil(() => warningText.text == randomSentence);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
