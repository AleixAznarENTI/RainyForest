using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject sangre;
    public GameObject PartMuerte;

    public string whatis;


    public int maxHealth = 100;
    public int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmg) { 
        currentHealth -= dmg;

        if (currentHealth <= 0) {
            Die();
        }
        else
        {

            StartCoroutine(Hit());
            

        }
    }

    void Die()
    {
        AudioManager.instance.PlaySFX("DieSound");
        GameObject temp = Instantiate(PartMuerte, transform.position,Quaternion.identity);
        Destroy(temp, 2);
        if(whatis == "Boss")
        {
            GameManager.instance.finished = true;
        }
        gameObject.SetActive(false);
    }


    

    IEnumerator Hit()
    {
        AudioManager.instance.PlaySFX("Attack");
        GameObject temp = Instantiate(sangre, transform.position, Quaternion.identity);
        Destroy(temp, 2);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * 500);
        if(player.transform.position.x > transform.position.x)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(-gameObject.transform.right * 500);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * 500);
        }

        yield return new WaitForSeconds(.75f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return 0;
    }
}
