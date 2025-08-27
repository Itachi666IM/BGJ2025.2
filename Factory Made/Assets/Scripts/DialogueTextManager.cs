using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueTextManager : MonoBehaviour
{
    public string[] dialogs;
    string currentDialogue;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] float waitTime;
    int index = 0;

    private void Start()
    {
        currentDialogue = dialogs[index];
        dialogueText.text = "";
    }

    public void ViewTextOnScreen()
    {
        if(index < dialogs.Length-1)
        {
            StartCoroutine(DisplayText());
            index++;
            currentDialogue = dialogs[index];
        }
        else
        {
            StartCoroutine(DisplayText());
        }
    }

    IEnumerator DisplayText()
    {
        foreach( char c in  currentDialogue.ToCharArray())
        {
            dialogueText.text += c.ToString();
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(waitTime);
        dialogueText.text = "";
    }
}
