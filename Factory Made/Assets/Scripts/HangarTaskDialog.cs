using UnityEngine;
using TMPro;
using System.Collections;
public class HangarTaskDialog : MonoBehaviour
{
    private TMP_Text hangarTaskText;
    public string[] sentences;
    public float typeSpeed;

    private void Awake()
    {
        hangarTaskText = GetComponent<TMP_Text>();
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
