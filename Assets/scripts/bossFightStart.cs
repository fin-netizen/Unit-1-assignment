using TMPro;
using UnityEngine;

public class bossFightStart : MonoBehaviour
{
    public TextMeshProUGUI dialogue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        print("excalibur says: fine, i'll deal with him myself");
        dialogue.text = ("excalibur: fine, i'll deal with him myself");
    }

}
