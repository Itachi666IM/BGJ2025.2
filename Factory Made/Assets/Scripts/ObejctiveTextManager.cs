using UnityEngine;
using TMPro;
public class ObejctiveTextManager : MonoBehaviour
{
    public string[] objectives;
    [SerializeField] TMP_Text objectiveText;
    string currentObjective;
    int index = 0;

    private void Start()
    {
        currentObjective = objectives[index];
        objectiveText.text = currentObjective;
    }

    public void NextObjective()
    {
        if(index < objectives.Length-1)
        {
            index++;
            currentObjective = objectives[index];
            objectiveText.text = currentObjective;
        }
        else
        {
            objectiveText.text = "You Survived!";
        }
    }
}
