using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyScript : MonoBehaviour
{
    public bool Move = true;
    public bool Movable = true;
    private Animator animator;
    public float speed;
    public float Maxdistance;
    public float Mindistance;
    public Transform Man;
    private bool CanCallDad = true;

    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    
    void Update()
    {
        if (Move)
        {
            if (Movable || transform.position.x - Man.position.x <= Mindistance)
            {
                Movable = true;
                CanCallDad = true;
                animator.SetInteger("Walk", 2);
                transform.localScale = new Vector3(-1, 1, 1);
                transform.Translate(speed, 0, 0);
            }
            if (transform.position.x - Man.position.x > Maxdistance && CanCallDad == true)
            {
                StartCoroutine("CallDad");
            }
        }
        else
        {
            animator.SetInteger("Walk", 0);
        }
    }

    private IEnumerator CallDad()
    {
        Movable = false;
        CanCallDad = false;
        animator.SetInteger("Walk", 0);
        transform.localScale = new Vector3 (1, 1, 1);
        DialogueManager.Instance.PrintDialogue("Boy", "Dad Hurry Up!");
        yield return new WaitForSeconds(2);
        DialogueManager.Instance.CloseDialogue();
    }
}
