using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField]
    private GameObject Dialoguebox;
    private Text Person;
    private Text Context;
    private Text FirstOption;
    private Text SecondOption;
    private Text ThirdOption;
    void Start()
    {
        Person = Dialoguebox.transform.GetChild(0).GetComponent<Text>();
        Context = Dialoguebox.transform.GetChild(1).GetComponent<Text>();
        FirstOption = Dialoguebox.transform.GetChild(2).GetComponent<Text>();
        SecondOption = Dialoguebox.transform.GetChild(3).GetComponent<Text>();
        ThirdOption = Dialoguebox.transform.GetChild(4).GetComponent<Text>();
    }


    public void PrintDialogue(string person, string context)
    {
        MainCharacter.Instance.Move = false;
        Person.gameObject.SetActive(true);
        Context.gameObject.SetActive(true);
        FirstOption.gameObject.SetActive(false);
        SecondOption.gameObject.SetActive(false);
        ThirdOption.gameObject.SetActive(false);
        Person.text = person;
        Context.text = context;
        Dialoguebox.SetActive(true);
    }

    public void CloseDialogue()
    {
        Dialoguebox.SetActive(false);
        MainCharacter.Instance.Move = true;
    }

    public void PrintOptions(string person, string option1, string option2, string option3, int rightoption)
    {
        FirstOption.text = option1;
        SecondOption.text = option2;
        ThirdOption.text = option3;
        Person.gameObject.SetActive(false);
        Context.gameObject.SetActive(false);
        FirstOption.gameObject.SetActive(true);
        SecondOption.gameObject.SetActive(true);
        ThirdOption.gameObject.SetActive(true);


        if((Input.GetKeyDown("1") && rightoption == 1) || (Input.GetKeyDown("1") && rightoption == 1) || (Input.GetKeyDown("1") && rightoption == 1))
        {
            CloseDialogue();
            EventManager.Instance.EventNumber += 1;
        }
        else
        {
            EventManager.Instance.GameOver();
        }
    }
}
