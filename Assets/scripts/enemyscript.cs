using JetBrains.Annotations;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    public Animator anim;
    Rigidbody2D rb;
    public bool isFacingRight;
    bool isGrounded;
    public LayerMask groundLayer;
    public LayerMask spear;
    float xvel, yvel;
    public playerscript playerscript;
    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xvel = -1.5f;
        yvel = 0f;
        print("Enemy says: the player has " + playerscript.lives + " lives");
    }

    // Update is called once per frame
    void Update()
    {
        yvel = rb.linearVelocity.y;
        if (xvel < 0)
        {
            if (ExtendedRayCollisionCheck(-1, 0) == false)
            {
                flip();
                xvel = -xvel;
            }
        }
        if (xvel > 0)
        {
            if (ExtendedRayCollisionCheck(1, 0) == false)
            {
                flip();
                xvel = -xvel;
            }
        }
        if (spearcheck(0, 2) == true)
        {
            Destroy(gameObject); 
        }

        rb.linearVelocity = new Vector3(xvel, yvel, 0);
        if (!isFacingRight && xvel < 0f)
        {
            flip();
        }
        else if (isFacingRight && xvel > 0f)
        {
            flip();
        }
        if (xvel >= 0.1 || xvel <= -0.1)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }


        rb.linearVelocity = new Vector3(xvel, yvel, 0);
        if (!isFacingRight && xvel < 0f)
        {
            flip();
        }
        else if (isFacingRight && xvel > 0f)
        {
            flip();
        }
        if (xvel >= 0.1 || xvel <= -0.1)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
    private void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f;
        bool hitSomething = false;

        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayer);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {

            hitColor = Color.green;
            hitSomething = true;
        }
        Debug.DrawRay(transform.position + offset, -Vector3.up * rayLength, hitColor);

        return hitSomething;

    }
    public bool spearcheck(float xoffs, float yoffs)
    {
        float rayLength = 1.5f;
        bool hitSomething = false;

        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, spear);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {

            hitColor = Color.green;
            hitSomething = true;
        }
        Debug.DrawRay(transform.position + offset, -Vector3.up * rayLength, hitColor);

        return hitSomething;

    }
}
