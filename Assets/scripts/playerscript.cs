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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded();
        float xvel, yvel;
        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;

        if (Input.GetKey("a"))
        {
            helper.DoFlipObject(true);
            xvel = -3;
        }
        if (Input.GetKey("d"))
        {
            helper.DoFlipObject(false);
            xvel = 3;
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            yvel = 7;
        }
        rb.linearVelocity = new Vector3(xvel, yvel, 0);
        
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
    /*
    private void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    */
}
