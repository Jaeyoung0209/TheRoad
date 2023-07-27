using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : Singleton<EventManager>
{
    public int EventNumber = 0;

    public GameObject BlackSquare;
    public GameObject TruckEventTimeline;
    public GameObject TruckEventTimeline2;
    private bool dotruckEvent = true;
    private bool truckEventProcess = false;
    private bool truckEventProcess2 = false;
    private AudioSource DeathGun;
    public AudioClip Gun;
    public Sprite Boysprite;
    public GameObject CutSceneDialogue;
    private bool doNakedEvent = true;
    private void Start()
    {
        DeathGun = GetComponent<AudioSource>();
    }

    public void Talk(int person)
    {
        if(person == 0)
        {
            GameObject.Find("Man").GetComponent<ManScript>().talk(EventNumber);
        }
        else if(person == 1)
        {
            GameObject.Find("Stranger").GetComponent<StrangerScript>().talk();
        }
        else if(person == 2)
        {
            GameObject.Find("Loot").GetComponent<LootScript>().talk();
        }
    }
    private void Update()
    {
        if(GameObject.Find("Boy").transform.position.x > 5.36 && dotruckEvent && !truckEventProcess2)
        {
            MainCharacter.Instance.animator.SetInteger("Walk", 0);
            StartCoroutine("Truck1");
        }

        if (truckEventProcess)
        {
            CutSceneDialogue.SetActive(true);
            CutSceneDialogue.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
            if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
            {
                SceneManager.LoadScene(4);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                CutSceneDialogue.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                MainCharacter.Instance.animator.SetInteger("Walk", 0);
                StartCoroutine("Truck2");
            }
        }

        if(GameObject.Find("Boy").transform.position.x > 10.5 && doNakedEvent)
        {
            doNakedEvent = false;
            MainCharacter.Instance.animator.SetInteger("Walk", 0);
            CutSceneDialogue.transform.GetChild(0).GetChild(6).gameObject.SetActive(true);
            GameObject.Find("Boy").GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine("NakedEvent");
        }

        if (truckEventProcess2)
        {
            CutSceneDialogue.SetActive(true);
            CutSceneDialogue.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
            if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L))
            {
                SceneManager.LoadScene(4);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                truckEventProcess2 = false;
                DeathGun.PlayOneShot(Gun);
                GameObject.Find("Bearded Man").gameObject.transform.localRotation = new Quaternion(0, 0, -90, 0);
                MainCharacter.Instance.Move = true;
                GameObject.Find("Boy").GetComponent<BoyScript>().Move = true;
                GameObject.Find("Boy").GetComponent<SpriteRenderer>().sprite = Boysprite;
                GameObject.Find("Main Camera").GetComponent<CameraFollow>().move = true;
                CutSceneDialogue.transform.GetChild(0).GetChild(5).gameObject.SetActive(false);
                CutSceneDialogue.SetActive(false);
            }
        }
    }

    private IEnumerator NakedEvent()
    {
        MainCharacter.Instance.Move = false;
        GameObject.Find("Boy").GetComponent<BoyScript>().Move = false;
        GameObject.Find("Boy").GetComponent<SpriteRenderer>().sprite = Boysprite;
        CutSceneDialogue.SetActive(true);
        CutSceneDialogue.transform.GetChild(0).GetChild(6).gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        CutSceneDialogue.SetActive(false);
        CutSceneDialogue.transform.GetChild(0).GetChild(6).gameObject.SetActive(false);
        MainCharacter.Instance.Move = true;
    }
    private IEnumerator Truck1()
    {
        dotruckEvent = false;
        MainCharacter.Instance.Move = false;
        GameObject.Find("Boy").GetComponent<BoyScript>().Move = false;
        GameObject.Find("Main Camera").GetComponent<CameraFollow>().move = false;
        TruckEventTimeline.SetActive(true);
        yield return new WaitForSeconds(29.39f);
        truckEventProcess = true;
        CutSceneDialogue.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        CutSceneDialogue.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
        GameObject.Find("Bearded Man").SetActive(true);
    }

    private IEnumerator Truck2()
    {
        truckEventProcess = false;
        CutSceneDialogue.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        CutSceneDialogue.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        CutSceneDialogue.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        CutSceneDialogue.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
        CutSceneDialogue.transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
        TruckEventTimeline2.SetActive(true);
        yield return new WaitForSeconds(4.40f);
        CutSceneDialogue.transform.GetChild(0).GetChild(5).gameObject.SetActive(true);
        truckEventProcess2 = true;
    }
    public void GameOver()
    {
        SceneManager.LoadScene(4);
    }


}
