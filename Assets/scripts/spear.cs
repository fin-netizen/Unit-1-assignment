using System.Threading;
using UnityEngine;

public class spear : MonoBehaviour
{
    public float Timer;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Timer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            Destroy(gameObject);
            Timer = 5;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("tag=" + collision.gameObject.tag);
        if (collision.gameObject.tag == "spear")
        {
            print("i've been hit by a spear");
            Destroy(gameObject); 
        }
    }

}
