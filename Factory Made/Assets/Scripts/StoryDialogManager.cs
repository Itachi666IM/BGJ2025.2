using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StoryDialogManager : MonoBehaviour
{
    [SerializeField] float typeSpeed;
    [SerializeField] AudioClip clickSound;
    public string[] sentences;
    public TMP_Text textArea;
    public GameObject continueButton;
    public GameObject startGameButton;
    private int index;

    private SFX sfxPlayer;


    void Start()
    {
        sfxPlayer = FindFirstObjectByType<SFX>();
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textArea.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void NextSentence()
    {
        sfxPlayer.PlayAnySFX(clickSound);
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textArea.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textArea.text = "";
            continueButton.SetActive(false);
        }

    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
 
    void Update()
    {
        if (textArea.text == sentences[index] && index != sentences.Length - 1)
        {
            continueButton.SetActive(true);
        }
        else if (textArea.text == sentences[index] && index == sentences.Length - 1)
        {
            startGameButton.SetActive(true);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
