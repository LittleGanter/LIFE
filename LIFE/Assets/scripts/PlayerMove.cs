using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    public float speed;
    private float moveInput;
    //public float je;
    private Rigidbody2D rb;
    private Animator an;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
    }

    private void Update()
    {
        walk();
        jump();
        CheckingGround();
        CheckLife();
    }

    private void walk()
    {
        
        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput == 0){an.SetBool("run", false);}
        else
        {
            
            an.SetBool("run", true);
            if (moveInput > 0){transform.localRotation = Quaternion.Euler(0, 0, 0);}
            if (moveInput < 0){transform.localRotation = Quaternion.Euler(0, 180, 0);}
        }
    }

    public float jumpForce;
    private bool jumpControl;
    private float jumpIteration = 0;
    public float jumpValueIteration = 60;

    private void jump()
    {
        
        if (Input.GetKey(KeyCode.Space) )
        {
            if (onGround) { jumpControl = true; }
        }
        else { jumpControl = false; }

        if (jumpControl)
        {
            if (jumpIteration++ < jumpValueIteration)
            {
                rb.AddForce(Vector2.up * jumpForce / jumpIteration);
            }
        }
        else { jumpIteration = 0; }

        if (!onGround){an.SetBool("jump", true);} 
        else an.SetBool("jump", false);
    }

    public bool onGround;
    public Transform GroundCheck;
    public float CheckRadius = 0.5f;
    public LayerMask Ground;

    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, Ground);
    }

    public GameObject lasty;
    private void CheckLife()
    {
        if (TextMoney.Coin == 7)
        {
            SceneManager.LoadScene(4);
            TextMoney.Coin = 0;
        }
        if (lasty.transform.position.y > transform.position.y) {
            
            SceneManager.LoadScene(1);
            //Destroy(gameObject);
            TextMoney.Coin = 0;
            Hp.health = 100;
        }
        if (Hp.health <= 0) {
            SceneManager.LoadScene(1);
            //Destroy(gameObject);
            TextMoney.Coin = 0;
            Hp.health = 100;
        }
    }

   

}
