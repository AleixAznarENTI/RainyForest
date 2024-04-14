using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    float yPos;
    float currTime;
    public float speed;

    public GameObject player;
    float audioTimer;
    bool audioResume = false;
    // Start is called before the first frame update
    void Start()
    {
        yPos = transform.position.y;
        gameObject.GetComponent<SpriteRenderer>().flipY = true;
    }

    // Update is called once per frame
    void Update()
    {
        audioTimer += Time.deltaTime;
        if(Vector2.Distance(player.transform.position, transform.position) <= 4)
        {
            if (audioTimer >= 0.5f)
            {
                AudioManager.instance.PlaySFX("FireBall");
                audioTimer = 0;
                audioResume = true;
            }
        }
        else
        {
            if (audioResume)
            {
                AudioSound s = (Array.Find(AudioManager.instance.sfxSounds, x => x.Name == "FireBall"));
                AudioManager.instance.sfxSource.clip = s.clip;
                AudioManager.instance.sfxSource.Stop();
                audioResume = false;
            }
        }
        
        currTime += Time.deltaTime;
        if(transform.position.y <= yPos)
        {
            if(currTime >= 1)
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
                currTime = 0;
                gameObject.GetComponent<Animator>().SetTrigger("Animation");
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            }
        }
    }
}
