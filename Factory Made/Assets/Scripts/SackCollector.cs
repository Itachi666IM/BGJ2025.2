using UnityEngine;
using TMPro;
public class SackCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text sackText;
    private int totalSacks;
    private int currentSacks;

    private void Awake()
    {
        totalSacks = FindObjectsByType<Sack>(FindObjectsSortMode.None).Length;
        currentSacks = 0;
    }
    private void Start()
    {
        UpdateSackText();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "drag")
        {
            currentSacks++;
            UpdateSackText();
        }
    }

    private void UpdateSackText()
    {
        sackText.text = $"Sacks : {currentSacks}/{totalSacks}";
    }
}
