using UnityEngine;

// Operates the Eichhoernchen/ squirrel
public class E_bewegung : MonoBehaviour
{
    public float MovementSpeed = 1;
    //public float JumpForce = 1; Soon he will be able to jump!
    public Animator animator;
    private Rigidbody2D _rigidbody;
    public GameObject eichhoernchen;
    public bool gameStarted;
    //public SpriteRenderer spriteRenderer;
    public GameObject e_laufen;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameStarted = false;
        e_laufen.SetActive(false);

        /* Early plans for changing layers to walk on the z-axis.
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingLayerName = "Ebene: 1";
        */
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameStarted = true;
        }
        if (gameStarted == true)
        {

            // movement horizontal
            var movementH = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movementH, 0, 0) * Time.deltaTime * MovementSpeed;
            animator.SetFloat("speed", Mathf.Abs(movementH));
            

            // flip player
            Vector3 characterScale = transform.localScale;

            if (characterScale.x == 5.46f)
            {
                if (Input.GetAxis("Horizontal") < 0)
                {
                    // Early plans for a flip-animation.
                    /* 
                    animator.Play("e_uebergang"); // play flip-anim
                    animator.Play("e_laufen"); // play flip-anim
                    */
                    characterScale.x = -5.46f;

                }
            }
            if (characterScale.x == -5.46f)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    // play flip-anim
                    characterScale.x = 5.46f;
                }
            }
            transform.localScale = characterScale;


            // controlls running-audio-object. 
            if (movementH > 0)
            {
                e_laufen.SetActive(true);
            }

            if(movementH == 0) 
            {
                e_laufen.SetActive(false);
            }

            if (movementH < 0)
            {
                e_laufen.SetActive(true);
            }


            // jumping
            /* 
            if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            {
                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
            */


            // move in depth
            /*
            var movementV = Input.GetAxis("Vertical");
            transform.position += new Vector3(0, 0, movementV) * Time.deltaTime * MovementSpeed;
            animator.SetFloat("speed", Mathf.Abs(movementV));


            if (Input.GetAxis("Vertical") > 0)
            {
                Debug.Log("up");

                if (spriteRenderer.sortingLayerName == "Ebene: 1")
                {
                    spriteRenderer.sortingLayerName = "Ebene: -1";
                }

                if (spriteRenderer.sortingLayerName == "Ebene: -1")
                {
                    spriteRenderer.sortingLayerName = "Ebene: -2";
                }

                if (spriteRenderer.sortingLayerName == "Ebene: -2")
                {
                    spriteRenderer.sortingLayerName = "Ebene: -3";
                }

            }

            if (Input.GetAxis("Vertical") < 0)
            {
                Debug.Log("down");

                if (spriteRenderer.sortingLayerName == "Ebene: -3")
                {
                    spriteRenderer.sortingLayerName = "Ebene: -2";
                }

                if (spriteRenderer.sortingLayerName == "Ebene: -2")
                {
                    spriteRenderer.sortingLayerName = "Ebene: -1";
                }

                if (spriteRenderer.sortingLayerName == "Ebene: -1")
                {
                    spriteRenderer.sortingLayerName = "Ebene: 1";
                }

            }
            */

        }
      
    }

}
