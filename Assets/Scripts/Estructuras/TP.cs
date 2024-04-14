using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    public Sprite activated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Checkpoint")
        {
            GameManager.instance.initialX = collision.gameObject.transform.position.x;
            GameManager.instance.initialY = collision.gameObject.transform.position.y;
            collision.GetComponent<SpriteRenderer>().sprite = activated;
            AudioManager.instance.PlaySFX("CheckPoint");
        }
    }
}
