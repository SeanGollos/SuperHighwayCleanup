using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private LevelLoader levelloader;

    [Header("Movement")]
    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    public Animator animator;
    AudioSource audiosource;

    [Header("Dash")]
    public float dashSpeed = 2f;
    private float dashTime;
    public float startDashTime = 0.1f;
    private float dashDelay;
    public float startDashDelay = 0.3f;
    private bool dash = false;
    public GameObject dashEffect;
    [SerializeField] AudioClip clip;

    Vector2 movement;

    private void Start()
    {
        dashTime = startDashTime;
        dashDelay = 0f;
        audiosource = GetComponent<AudioSource>();
        levelloader = FindObjectOfType<LevelLoader>();
    }

    // Commented out dash delay functionality
    void Update()
    {
        if (Time.time > 4 /*&& dashDelay <=0*/)
        {
            animator.SetBool("Roll", false);
            movement.x = Input.GetAxisRaw("Horizontal"); //Gives a value between -1 and 1
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude); //sqrMagnitude is better optimized than magnitude

            //Dash when player presses space
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dash = true;
                GameObject effect = Instantiate(dashEffect, transform.position, Quaternion.identity);
                audiosource.PlayOneShot(clip);
                animator.SetBool("Roll", true);
                Destroy(effect, 1);
            }
        }//else
        //{
        //    animator.SetFloat("Speed", 0);
        //}
    }

    //Executed on a fixed timer, not based on frame rate like Update
    void FixedUpdate()
    {
        //if (dashDelay <= 0)
        //{
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            if (dash == true && dashTime >= 0)
            {
                dashTime -= Time.fixedDeltaTime;
                rb.MovePosition(rb.position + movement * dashSpeed * Time.fixedDeltaTime);
                dash = true;
            }
            else
            {
                dashTime = startDashTime;
                if (dash == true)
                {
                    dashDelay = startDashDelay;
                }
                dash = false;
            }
            ClampMovement();
        //}else
        //{
        //    dashDelay -= Time.fixedDeltaTime;
        //}
    }

    private void ClampMovement()
    {
        if (rb.position.x > 925)
            rb.MovePosition(new Vector2(925, rb.position.y));
        if(rb.position.x <-925)
            rb.MovePosition(new Vector2(-925, rb.position.y));
        if(rb.position.y >504)
            rb.MovePosition(new Vector2(rb.position.x, 504));
        if (rb.position.y < -504)
            rb.MovePosition(new Vector2(rb.position.x, -504));
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.gameObject.GetComponent<Vehicle>())
        {
            levelloader.LoadGameOver();
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
}
