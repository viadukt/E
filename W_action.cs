using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Operates the Parent_W/ the wild hog, the title screen and the game's music
public class W_action : MonoBehaviour
{
    public GameObject push;
    public float MovementSpeed = 1;
    public Animator animator;
    public bool alreadyRunning;
    public bool startMovement;
    public bool chasing;
    public bool dead;
    public bool startedgame;
    public GameObject auge;
    public GameObject nebel0;
    public GameObject nebel1;
    public GameObject player;
    public GameObject big_W;
    public GameObject warmMusic;
    public GameObject buzzing;
    public GameObject chasingMusic;
    public GameObject deepForestMusic;
    public Rigidbody2D wildschwein;
    public GameObject titleScreen;
    public GameObject schock;
    public GameObject grunzen;
    public GameObject laufen;


    // Start is called before the first frame update
    void Start()
    {
        // title screen
        startedgame = false;
        titleScreen.SetActive(true);

        // wild hog
        push.SetActive(false);
        alreadyRunning = false;
        startMovement = false;
        chasing = false;
        auge.SetActive(true);
        nebel0.SetActive(true);
        nebel1.SetActive(true);
        dead = false;

        // music and wild hog's sounds
        warmMusic.SetActive(false);
        buzzing.SetActive(false);
        deepForestMusic.SetActive(false);
        chasingMusic.SetActive(false);
        schock.SetActive(false);
        grunzen.SetActive(false);
        laufen.SetActive(false);      
        
    }


    // Update is called once per frame
    void Update()
    {
        // title screen
        if (startedgame == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                titleScreen.SetActive(false);
                startedgame = true;
                warmMusic.SetActive(true);
                buzzing.SetActive(true);
                deepForestMusic.SetActive(true);
            }
        }

        // wild hog's movement
        if (startMovement == true)
        {
            wildschwein.velocity = new Vector2(-21, 0);
        }

        // kills player and game
        if(dead == true || Input.GetButtonDown("Cancel"))
        {
            startedgame = false;
            string scene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
            
        }

        // Wildschwein-Debug
        /*
        var movementH = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movementH, 0, 0) * Time.deltaTime * MovementSpeed;
        animator.SetFloat("speed", Mathf.Abs(movementH));

        
        Vector3 characterScale = transform.localScale;
        if (characterScale.x == -1)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                characterScale.x = 1;

            }
        }
        if (characterScale.x == 1)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {

                characterScale.x = -1;
            }
        }
        transform.localScale = characterScale;
        */
    }

    [SerializeField] private Animator animationController;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(alreadyRunning == false)
        {
            if (collider.gameObject.tag == "Player")
            {
                push.SetActive(true);
            }
        }
               
    }

    // first contact starts chasing, second kill player and game
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetButtonDown("Jump"))
            {
                push.SetActive(false);
                nebel1.SetActive(false);
                schock.SetActive(true);
                warmMusic.SetActive(false);
                buzzing.SetActive(false);
                deepForestMusic.SetActive(false);
                alreadyRunning = true;
                StartCoroutine("WaitForSec");

            }

            if (chasing == true)
            {
                Destroy(player);
                dead = true;
                               
            }

        }

        // kills the wild hog if very left tree is touched
        if (collision.gameObject.tag == "leftTree")
        {
            Destroy(big_W);

        }


    }

    // shock and chasing
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(1);
        animationController.SetBool("w_laufen", true);
        grunzen.SetActive(true);
        chasingMusic.SetActive(true);
        laufen.SetActive(true);
        yield return new WaitForSeconds(1);
        startMovement = true;
        chasing = true;

        /*
        while (true)
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * MovementSpeed;
        }
        */
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            push.SetActive(false);
        }
    }


}
