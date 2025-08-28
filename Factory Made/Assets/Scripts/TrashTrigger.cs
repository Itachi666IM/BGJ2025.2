using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashTrigger : MonoBehaviour
{
    [SerializeField] private TMP_Text trashText;
    [SerializeField] private TMP_Text trashEndSceneText;
    [SerializeField] private AudioClip thudSound;
    [SerializeField] private AudioClip applause;
    private SFX sfxPlayer;
    public string[] sentences;
    private int totalTrash;
    private int currentTrash;
    public float typeSpeed;
    private bool endDialogStarted = false;


    private void Awake()
    {
        sfxPlayer = FindFirstObjectByType<SFX>();
        totalTrash = FindObjectsByType<Trash>(FindObjectsSortMode.None).Length;
        currentTrash = 0;
    }
    private void Start()
    {
        UpdateTrashText();
    }
    private void Update()
    {
        if (currentTrash == totalTrash && !endDialogStarted)
        {
            endDialogStarted = true;
            StartCoroutine(EndScene());
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "drag")
        {
            sfxPlayer.PlayAnySFX(thudSound);
            currentTrash++;
            Destroy(other);
            UpdateTrashText();
        }
    }

    private void UpdateTrashText()
    {
        trashText.text = $"Trash : {currentTrash}/{totalTrash}";
    }

    IEnumerator EndScene()
    {
        sfxPlayer.PlayAnySFX(applause);
        for(int i = 0; i< sentences.Length; i++)
        {
            trashEndSceneText.text = "";
            string sentence = sentences[i];
            StartCoroutine(Type(sentence));
            yield return new WaitUntil(() => trashEndSceneText.text == sentence);
            yield return new WaitForSeconds(2f);
        }
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Type(string sentence)
    {
        foreach(char ch in sentence)
        {
            trashEndSceneText.text += ch;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
}
