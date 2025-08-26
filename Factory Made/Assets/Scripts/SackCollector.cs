using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class SackCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text sackText;
    public UnityEvent InteriorEvent;
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
    private void Update()
    {
        if(currentSacks == totalSacks)
        {
            InteriorEvent?.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "drag")
        {
            currentSacks++;
            Destroy(other);
            UpdateSackText();
        }
    }

    private void UpdateSackText()
    {
        sackText.text = $"Sacks : {currentSacks}/{totalSacks}";
    }
}
