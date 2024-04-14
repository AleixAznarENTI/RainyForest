using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class MovementPlayer : MonoBehaviour
{
    [Header("Movimiento")]
    public int speed;
    public int jumpForce;
    float audioTimer;


    [Header("Deteccion de suelo")]
    [Range(0f, 2f)]
    public float raycastDistance;
    public LayerMask layerMask;
    public bool grounded;

    [Header("Animation")]
    public Animator animator;

    [Header("Ataque")]
    public GameObject ataque;


    public Vector2[] points;
    // Start is called before the first frame update
   private void Start()
    {
        //AudioManager.instance.musicSource.Stop();
        AudioManager.instance.musicSource.Stop();
        AudioManager.instance.PlayMusic("GamePlaySong");
    }

    // Update is called once per frame
   private void Update()
    {
        audioTimer += Time.deltaTime;
        Jump();

        if (gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            //Izq.
            ataque.transform.position = gameObject.transform.position + new Vector3(-0.46f, -0.11f, 0);
        }
        else
        {
            //Derecha
            ataque.transform.position = gameObject.transform.position + new Vector3(0.46f, -0.11f, 0);

        }

    }

    private void FixedUpdate()
    {
        animator.SetFloat("Y vel", gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetAxis("Horizontal") > 0f) {
            if(audioTimer > 0.25f && grounded)
            {
                AudioManager.instance.PlaySFX("Steps");
                audioTimer = 0f;
            }
            animator.SetBool("Run", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        
        }
        else if(Input.GetAxis("Horizontal") < 0f)
        {
            if (audioTimer > 0.25f && grounded)
            {
                AudioManager.instance.PlaySFX("Steps");
                audioTimer = 0f;
            }
            animator.SetBool("Run", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        else if(Input.GetAxis("Horizontal") == 0){
            animator.SetBool("Run", false);
        }

        grounded = false;
        bool isParent = false;
        foreach (Vector2 p in points)
        {
            

            RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)p, -Vector2.up, raycastDistance, layerMask);
            Debug.DrawRay(transform.position + (Vector3)p, -Vector2.up * raycastDistance, Color.blue);
            Debug.DrawRay(transform.position + (Vector3)p, -Vector2.up * hit.distance, Color.green);
            if(hit.collider != null)
            {
                grounded = true;
                if(hit.collider.tag == "PlataformaMovil")
                {
                    isParent = true;
                }
                
            }
            else
            {
                isParent |= false;
            }
            if (isParent)
            {
                if (hit.collider != null)
                {
                    this.transform.SetParent(hit.collider.transform);
                }
            }
            else
            {
                this.transform.SetParent(null);
            }




        }
        animator.SetBool("Grounded", grounded);

    }

    void Jump()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (Input.GetButtonDown("Jump") && grounded)
        {
            
            rb.gravityScale = 1;
            rb.AddForce(transform.up * jumpForce);
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
        if (Input.GetButtonUp("Jump"))
        {
            rb.gravityScale = 3;
        }
    }



}
