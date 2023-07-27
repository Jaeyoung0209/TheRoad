using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeachEventManager : MonoBehaviour
{
    private bool beachevent = false;
    public GameObject cutscenedialogue;
    public GameObject Timeline2;
    
    void Start()
    {
        StartCoroutine("Beachscene");   
    }

    // Update is called once per frame
    void Update()
    {
        if (beachevent)
        {
            cutscenedialogue.SetActive(true);
            cutscenedialogue.transform.GetChild(0).GetChild(10).gameObject.SetActive(false);
            cutscenedialogue.transform.GetChild(0).GetChild(11).gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
            {
                SceneManager.LoadScene(4);
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                beachevent = false;
                cutscenedialogue.SetActive(false);
                Timeline2.SetActive(true);
            }
        }
    }

    private IEnumerator Beachscene()
    {
        yield return new WaitForSeconds(45.08f);
        beachevent = true;
        cutscenedialogue.transform.GetChild(0).GetChild(10).gameObject.SetActive(false);
    }
}
