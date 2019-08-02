using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigi;
    Animator anim;
    [SerializeField] private float moveSpeed, jumpForce;
    public static float hori;

    [SerializeField] private bool isGround = false;
   
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        Reset();
        
    }
    private void Reset()
    {

        rigi.gravityScale = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CameraChanger.canMove == true)
        {
            Move();
            Jump();
            if (Ladder.canClimb == true)
            {
                Climb();
            }
            else if (isGround == true)
            {
                rigi.gravityScale = 1;
            }
        }
        
        
    }
    void Move()
    {
        Vector3 rotation = Vector3.zero;
        if(Input.GetKeyDown(KeyCode.A))
        {
            hori = -1;
            transform.rotation = Quaternion.Euler(0, 180, 0);

            anim.SetInteger("Speed", 1);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            hori = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);

            anim.SetInteger("Speed", 1);
            

        }
        float move = Input.GetAxisRaw("Horizontal");
        rigi.velocity = new Vector2(move * moveSpeed * Time.deltaTime, rigi.velocity.y);
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("Speed", 0);
        }

        
        


    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            rigi.AddForce(new Vector2(0, jumpForce));
            isGround = false;
            anim.SetBool("isGround", false);
        }

        
    }

    



   

    void Climb()
    {
        rigi.gravityScale = 0;
        float climb = Input.GetAxisRaw("Vertical");
        rigi.velocity = new Vector2(rigi.velocity.x, climb * moveSpeed * Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
            anim.SetBool("isGround", true);
           
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
            anim.SetBool("isGround", true);
        }
    }*/

}
