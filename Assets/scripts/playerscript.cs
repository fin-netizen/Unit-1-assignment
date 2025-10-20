using UnityEngine;

public class playerscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    public LayerMask groundLayer;
    bool isGrounded;
    public bool isFacingRight;
    public Animator anim;
    helperScript helper;
    public int lives;
    public GameObject weapon;
    public int movedirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
        helper = gameObject.AddComponent<helperScript>();
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded();
        spear();
        float xvel, yvel;
        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;

        if (Input.GetKey("a"))
        {
            
            helper.DoFlipObject(true);
            
            xvel = -4;
        }
        if (Input.GetKey("d"))
        {
            helper.DoFlipObject(false);
            xvel = 4;
        }
        // I've added a leap
        if (Input.GetKey(KeyCode.LeftAlt) && isGrounded)
        {
            xvel = 5;
            yvel = 7;
        }
        if (Input.GetKey(KeyCode.RightShift) && isGrounded)
        {
            xvel = -5;
            yvel = 7;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", true); 
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey("d") && isGrounded)
        {
            xvel = 7;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey("a") && isGrounded)
        {
            xvel = -7;
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            yvel = 7;
        }
       
        /*
        if(!isFacingRight && xvel < 0f)
        {
            flip();
        }
        else if (isFacingRight && xvel > 0f)
        {
            flip();
        }
        */
        if (xvel >= 0.1 || xvel <= -0.1)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
        rb.linearVelocity = new Vector3(xvel, yvel, 0);
        
        if (Input.GetKeyDown("y"))
        {
            if(xvel > 0)
            { 
                GameObject clone;
                clone = Instantiate(weapon, transform.position, transform.rotation);

                Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

                rb.linearVelocity = new Vector2(12, 0); 

                rb.transform.position = new Vector3(transform.position.x + 2, transform.position.y + 1, transform.position.z + 1);
            }

            if (xvel < 0)
            {
                GameObject clone;
                clone = Instantiate(weapon, transform.position, transform.rotation);

                Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

                rb.linearVelocity = new Vector2(-12, 0);

                rb.transform.position = new Vector3(transform.position.x - 2, transform.position.y + 1, transform.position.z + 1);
            }
        }

    }


    void IsGrounded()
    {
        Color color = Color.red;
        isGrounded = false;

        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            isGrounded = true;
            color = Color.green;

        }

        Debug.DrawRay(position, direction, color);
        hit = Physics2D.Raycast(position, direction, distance, groundLayer);


    }
    
    private void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    void spear()
    {

    }
    
}
