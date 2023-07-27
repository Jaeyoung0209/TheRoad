using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManScript : MonoBehaviour
{
    private int DialogueCounter = 0;
    private Dictionary<int, string[]> DialogueDict = new Dictionary<int, string[]>();

    private void Start()
    {
        string[] Event0Dialogue = { "Dialogue1", "Dialogue2", "Dialogue3" };
        DialogueDict.Add(0, Event0Dialogue);
    }
    public void talk(int EventNumber)
    {
        if(EventNumber == 0)
        {
            if (DialogueCounter >= 3)
            {
                DialogueCounter = 0;
                DialogueManager.Instance.CloseDialogue();
            }
            else
            {
                DialogueManager.Instance.PrintDialogue("Man", DialogueDict[0][DialogueCounter]);
                DialogueCounter += 1;
            }


        }
    }
}
