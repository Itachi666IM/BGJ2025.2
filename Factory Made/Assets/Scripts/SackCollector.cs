using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class SackCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text sackText;
    [SerializeField] private AudioClip yeahSound;
    [SerializeField] private GameObject smokeEffect;
    public UnityEvent InteriorEvent;
    private int totalSacks;
    private int currentSacks;
    private SFX sfxPlayer;
    private void Awake()
    {
        totalSacks = FindObjectsByType<Sack>(FindObjectsSortMode.None).Length;
        sfxPlayer = FindFirstObjectByType<SFX>();
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
            sfxPlayer.PlayAnySFX(yeahSound);
            Instantiate(smokeEffect, transform.position, Quaternion.Euler(0, 90, 0));
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
