using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveDMG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Fireball")
        {
            StartCoroutine(Hit(collision.gameObject));
        }
    }

    IEnumerator Hit(GameObject col)
    {
        AudioManager.instance.PlaySFX("EnemyAttack");
        GameManager.instance.vidas--;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * 500);
        if (transform.position.x > col.transform.position.x)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * 500);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(-gameObject.transform.right * 500);
        }

        yield return new WaitForSeconds(.75f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return 0;
    }
}
