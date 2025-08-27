using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Events;
public class HangarTaskDialog : MonoBehaviour
{
    private TMP_Text hangarTaskText;
    public string[] sentences;
    public float typeSpeed;

    public UnityEvent hangarEvent;

    private void Awake()
    {
        hangarTaskText = GetComponent<TMP_Text>();
        hangarEvent?.Invoke();
    }
    private void Start()
    {
        hangarTaskText.text = "";
        StartCoroutine(HangarDialog());
    }

    IEnumerator HangarDialog()
    {
        for(int i = 0; i< sentences.Length; i++)
        {
            hangarTaskText.text = "";
            string sentenceToDisplay = sentences[i];
            StartCoroutine(Type(sentenceToDisplay));
            yield return new WaitUntil(() => hangarTaskText.text == sentenceToDisplay);
            yield return new WaitForSeconds(3f);
        }
        Destroy(gameObject);
    }

    IEnumerator Type(string sentence)
    {
        foreach(char ch in sentence)
        {
            hangarTaskText.text += ch;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
}
