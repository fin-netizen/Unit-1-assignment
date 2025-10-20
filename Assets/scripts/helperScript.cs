using UnityEngine;

public class helperScript : MonoBehaviour
{


    public void DoFlipObject(bool flip)
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = flip;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            print("attack");
        }
    }
}
