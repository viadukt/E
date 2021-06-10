using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Makes sure, "Push SPACE"-Text is not shown, if player is outside trigger when animal has not yet stopped talking (WaitForSeconds is not over yet).
public class PushDisabler : MonoBehaviour
{
    public GameObject push;

   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        push.SetActive(false);
    }



}
