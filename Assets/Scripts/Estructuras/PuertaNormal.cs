using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaNormal : MonoBehaviour
{
    public GameObject player;
    public char letter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.transform.position, transform.position) < 5)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach(char a in GameManager.instance.unlock)
                {
                    if(a == letter)
                    {
                        AudioManager.instance.PlaySFX("DoorOpened");
                        gameObject.SetActive(false);
                        GameManager.instance.unlock.Remove(a);
                        break;
                    }
                }
            }
        }
    }
}
