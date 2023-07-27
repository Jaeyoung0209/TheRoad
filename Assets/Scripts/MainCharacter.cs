using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacter : Singleton<MainCharacter>
{
    public bool Move = true;

    public Animator animator;
    public float speed;
    public AudioClip Door;
    private AudioSource audiosource;
    private Vector3 vector;

    public float interactradius;
    private GameObject InteractObject = null;
    private bool playdoor = true;

    private BoxCollider2D boxCollider;
    public LayerMask layerMask1;
    public LayerMask layerMask2;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (InteractObject != null && Input.GetKeyDown("k"))
        {
            if(InteractObject.name == "Man")
                EventManager.Instance.Talk(0);
        }

        if(transform.position.x < 11 && transform.position.x > 10.8 && transform.position.y > -0.69)
        {
            if(playdoor)
                StartCoroutine("nextscene");
        }


        if (Move)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                vector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

                if (vector.x != 0)
                    vector.y = 0;

                RaycastHit2D hit1;
                RaycastHit2D hit2;
                Vector2 start = transform.position;
                Vector2 end = start + new Vector2(vector.x * speed, vector.y * speed);

                boxCollider.enabled = false;
                hit1 = Physics2D.Linecast(start, end, layerMask1);
                hit2 = Physics2D.Linecast(start, end, layerMask2);
                boxCollider.enabled = true;

                if (hit1.transform == null && hit2.transform == null)
                {
                    InteractObject = null;
                    if (vector.x != 0)
                    {
                        transform.Translate(vector.x * speed, 0, 0);
                        animator.SetInteger("Walk", 2);
                        if (vector.x >= 0)
                            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                        else
                            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                    }
                    else if (vector.y != 0)
                    {
                        transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                        transform.Translate(0, vector.y * speed, 0);
                        if(vector.y >= 0)
                            animator.SetInteger("Walk", 3);
                        else
                            animator.SetInteger("Walk", 1);
                    }

                }
                else
                {
                    animator.SetInteger("Walk", 0);
                    if (hit2.distance <= interactradius && hit2.transform != null)
                    {
                        InteractObject = hit2.transform.gameObject;
                    }
                    else
                    {
                        InteractObject = null;
                    }
                }
            }
            else
                animator.SetInteger("Walk", 0);
        }

    }

    private IEnumerator nextscene()
    {
        playdoor = false;
        audiosource.PlayOneShot(Door);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
}
