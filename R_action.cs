using System.Collections;
using UnityEngine;

// Operates Rotkehlchen's/ Robin's  dialogue etc.
public class R_action : MonoBehaviour
{
    public Animator animator;
    public GameObject push;
    public GameObject pushNot;
    public GameObject tweet;
    public GameObject schimpfen;

    public GameObject info1;
    public GameObject info2;
    public GameObject info3;
    public GameObject info4;
    public GameObject info5;

    public GameObject angry1;
    public GameObject angry2;
    public GameObject angry3;
    public GameObject angry4;
    public GameObject angry4_2;

    public GameObject rot_die;
    
    public GameObject halterung;

    public bool listened = false;
    public bool finishedTalking1 = false;
    public bool finishedTalking2 = false;
    public bool finishedTalking3 = false;
    public bool finishedTalking4 = false;
    public bool finishedTalking5 = false;
    public bool finishedTalking6 = false;
    public bool loop = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animationController.SetBool("sprechen", false);
        push.SetActive(false);
        pushNot.SetActive(false);
        tweet.SetActive(false);
        schimpfen.SetActive(false);

        info1.SetActive(false);
        info2.SetActive(false);
        info3.SetActive(false);
        info4.SetActive(false);
        info5.SetActive(false);

        angry1.SetActive(false);
        angry2.SetActive(false);
        angry3.SetActive(false);
        angry4.SetActive(false);
        angry4_2.SetActive(false);

        halterung.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Trigger Listener
    [SerializeField] private Animator animationController;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (listened == false)
        {
            //Debug.Log("ENTER: Da's'en SCHLÜSSEEL!");
            //animationController.SetBool("sprechen", true);
            push.SetActive(true);
        }

        if (finishedTalking1 == true)
        {
            push.SetActive(true);
        }

        if (finishedTalking2 == true)
        {
            push.SetActive(true);
        }

        if (finishedTalking3 == true)
        {
            push.SetActive(true);
        }

        if (finishedTalking4 == true)
        {
            push.SetActive(true);
        }

        if (finishedTalking5 == true)
        {
            push.SetActive(true);
        }

        if (finishedTalking6 == true)
        {
            pushNot.SetActive(true);
        }

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        //Debug.Log("STAY: Da's'en SCHLÜSSEEL!");
        if (listened == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                push.SetActive(false);
                StartCoroutine("WaitForSec");
                tweet.SetActive(true);
                info1.SetActive(true);
                animationController.SetBool("sprechen", true);

            }
        }

        if (finishedTalking1 == true)
        {
            //Debug.Log("STAY: finishedTalking1 = true");
            if (Input.GetButtonDown("Jump"))
            {
                //Debug.Log("finishedTalking1 = true,info5.SetActive(true), animationController.SetBool(sprechen, true)");
                push.SetActive(false);
                StartCoroutine("WaitForSec");
                tweet.SetActive(true);
                info5.SetActive(true);
                animationController.SetBool("sprechen", true);
            }
        }

        if (finishedTalking2 == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                push.SetActive(false);
                StartCoroutine("WaitForSec");
                tweet.SetActive(true);
                angry1.SetActive(true);
                animationController.SetBool("sprechen", true);
            }
        }

        if (finishedTalking3 == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                push.SetActive(false);
                StartCoroutine("WaitForSec");
                tweet.SetActive(true);
                angry2.SetActive(true);
                animationController.SetBool("sprechen", true);
            }
        }

        if (finishedTalking4 == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                push.SetActive(false);
                StartCoroutine("WaitForSec");
                tweet.SetActive(true);
                angry3.SetActive(true);
                animationController.SetBool("sprechen", true);
            }
        }

        if (finishedTalking5 == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                push.SetActive(false);
                StartCoroutine("WaitForSec");
                tweet.SetActive(true);
                angry4.SetActive(true);
                animationController.SetBool("sprechen", true);
            }
        }
        
        if (finishedTalking6 == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                pushNot.SetActive(false);
                loop = false;
            }
        }

    }

    IEnumerator WaitForSec()
    {
        if (listened == false)
        {
            listened = true;
            yield return new WaitForSeconds(3);
            info1.SetActive(false);
            info2.SetActive(true);
            yield return new WaitForSeconds(4);
            info2.SetActive(false);
            info3.SetActive(true);
            yield return new WaitForSeconds(3);
            info3.SetActive(false);
            info4.SetActive(true);
            yield return new WaitForSeconds(4);
            info4.SetActive(false);
            info5.SetActive(true);
            yield return new WaitForSeconds(3);
            info5.SetActive(false);
            animationController.SetBool("sprechen", false);
            finishedTalking1 = true;
            push.SetActive(true);
            tweet.SetActive(false);

            yield break;
        }

        if (finishedTalking1 == true)
        {
            yield return new WaitForSeconds(3);
            info5.SetActive(false);
            animationController.SetBool("sprechen", false);
            finishedTalking1 = false;
            finishedTalking2 = true;
            push.SetActive(true);
            tweet.SetActive(false);

            yield break;
        }

        if (finishedTalking2 == true)
        {
            yield return new WaitForSeconds(3);
            angry1.SetActive(false);
            animationController.SetBool("sprechen", false);
            finishedTalking2 = false;
            finishedTalking3 = true;
            push.SetActive(true);
            tweet.SetActive(false);

            yield break;
        }

        if (finishedTalking3 == true)
        {
            yield return new WaitForSeconds(3);
            angry2.SetActive(false);
            animationController.SetBool("sprechen", false);
            finishedTalking3 = false;
            finishedTalking4 = true;
            push.SetActive(true);
            tweet.SetActive(false);

            yield break;
        }

        if (finishedTalking4 == true)
        {
            yield return new WaitForSeconds(3);
            angry3.SetActive(false);
            animationController.SetBool("sprechen", false);
            finishedTalking4 = false;
            finishedTalking5 = true;
            push.SetActive(true);
            tweet.SetActive(false);

            yield break;
        }

        if (finishedTalking5 == true)
        {
            finishedTalking5 = false;
            Renderer render = GetComponent<Renderer>();
            render.material.color = Color.red;

            pushNot.SetActive(true);

            while (loop)
            {
                schimpfen.SetActive(true);
                yield return new WaitForSeconds(1);
                angry4.SetActive(false);
                angry4_2.SetActive(true);
                yield return new WaitForSeconds(1);
                angry4_2.SetActive(false);
                angry4.SetActive(true);
                finishedTalking6 = true;
                schimpfen.SetActive(false);
            }
            schimpfen.SetActive(true);
            rot_die.SetActive(true);
            angry4.SetActive(false);
            angry4_2.SetActive(false);
            yield return new WaitForSeconds(1);
            rot_die.SetActive(false);
            finishedTalking6 = false;
            schimpfen.SetActive(false);

            halterung.SetActive(false);
            animationController.SetBool("sprechen", false);
            animationController.SetBool("sterben", true);
            render.material.color = Color.grey;
            yield break;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (listened == false)
        {
            //Debug.Log("EXIT: Da's'en SCHLÜSSEEL!");
            animationController.SetBool("sprechen", false);
            push.SetActive(false);
        }

        push.SetActive(false);
        pushNot.SetActive(false);

    }

}
