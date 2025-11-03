using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class runAway : MonoBehaviour
{
    public Animator anim;
    Rigidbody2D rb;
    float timer;
    float xvel, yvel;
    public TextMeshProUGUI dialogue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xvel = 9f;
        yvel = 0f;
        timer = 1;
        print("excalibur says: guards get him!");
        dialogue.text = ("excalibur: Not you again, guards stall him!");
    }

    // Update is called once per frame
    void Update()
    {
        yvel = rb.linearVelocity.y;
        rb.linearVelocity = new Vector3(xvel, yvel, 0);
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject); 
        }
    }
}
