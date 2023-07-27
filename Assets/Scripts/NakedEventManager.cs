using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NakedEventManager : MonoBehaviour
{
    public GameObject CutSceneDialogue;
    public GameObject Basement;
    public bool BeActive = false;
    public GameObject Timeline2;
    void Start()
    {
        StartCoroutine("TimelineCoroutine1");
    }

    private void Update()
    {
        if (BeActive)
        {
            Basement.SetActive(true);
            CutSceneDialogue.SetActive(true);
            CutSceneDialogue.transform.GetChild(0).GetChild(4).gameObject.SetActive(true);

            if(Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L))
            {
                SceneManager.LoadScene(4);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                BeActive = false;
                CutSceneDialogue.SetActive(false);
                Timeline2.SetActive(true);
                StartCoroutine("TimelineCoroutine2");
            }
        }
    }

    private IEnumerator TimelineCoroutine1()
    {
        MainCharacter.Instance.Move = false;
        yield return new WaitForSeconds(29.12f);
        BeActive = true;
    }

    private IEnumerator TimelineCoroutine2()
    {
        yield return new WaitForSeconds(1.45f);
        SceneManager.LoadScene(3);
    }
}
