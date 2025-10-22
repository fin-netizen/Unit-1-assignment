using TMPro;
using UnityEngine;

public class secretRoute : MonoBehaviour
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
        print("??? says: SO EXCALIBUR FAILED? NO MATTER");
        dialogue.text = "???: SO EXCALIBUR FAILED? NO MATTER";

    }
}
