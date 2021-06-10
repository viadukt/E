using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Operates the Bienenstock/ bee hive
public class B_action : MonoBehaviour
{
    public GameObject push;
    public GameObject buzz1;
    public GameObject buzz2;
    public GameObject buzz3;

    public bool listenedBees;


    // Start is called before the first frame update
    void Start()
    {
        push.SetActive(false);
        buzz1.SetActive(false);
        buzz2.SetActive(false);
        buzz3.SetActive(false);
        listenedBees = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (listenedBees == false)
        {
            push.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (listenedBees == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                push.SetActive(false);
                StartCoroutine("WaitForSec");
                buzz1.SetActive(true);

            }
        }
    }

    IEnumerator WaitForSec()
    {
        if (listenedBees == false)
        {
            listenedBees = true;
            yield return new WaitForSeconds(1);
            buzz1.SetActive(false);
            buzz2.SetActive(true);
            yield return new WaitForSeconds(1);
            buzz2.SetActive(false);
            buzz3.SetActive(true);
            yield return new WaitForSeconds(1);
            buzz3.SetActive(false);

            listenedBees = false;
            yield break;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        push.SetActive(false);
    }


}
