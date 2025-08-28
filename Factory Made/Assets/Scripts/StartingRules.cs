using TMPro;
using UnityEngine;
using System.Collections;
public class StartingRules : MonoBehaviour
{
    private TMP_Text startingRulesText;

    public string[] sentences;
    public float typeSpeed;


    private void Awake()
    {
        startingRulesText = GetComponent<TMP_Text>();
    }
    private void Start()
    {
        startingRulesText.text = "";
        StartCoroutine(HangarDialog());
    }

    IEnumerator HangarDialog()
    {
        for (int i = 0; i < sentences.Length; i++)
        {
            startingRulesText.text = "";
            string sentenceToDisplay = sentences[i];
            StartCoroutine(Type(sentenceToDisplay));
            yield return new WaitUntil(() => startingRulesText.text == sentenceToDisplay);
            yield return new WaitForSeconds(3f);
        }
        Destroy(gameObject);
    }

    IEnumerator Type(string sentence)
    {
        foreach (char ch in sentence)
        {
            startingRulesText.text += ch;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
}
