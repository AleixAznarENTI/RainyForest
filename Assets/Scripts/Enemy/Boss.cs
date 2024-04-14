using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject sangre;
    public GameObject PartMuerte;


    public int maxHealth = 100;
    public int currentHealth;

    public Animator animator;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
        else
        {

            StartCoroutine(Hit());


        }
    }

    IEnumerator Die()
    {
        AudioManager.instance.PlaySFX("DieSound");
        GameObject temp = Instantiate(PartMuerte, transform.position, Quaternion.identity);
        Destroy(temp, 2);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        LoadNextLevel("EndGame");
    }
    public void LoadNextLevel(string Scene)
    {
        StartCoroutine(LoadLevel(Scene));
    }

    IEnumerator LoadLevel(string Scene)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(Scene);
    }



    IEnumerator Hit()
    {
        AudioManager.instance.PlaySFX("Attack");
        GameObject temp = Instantiate(sangre, transform.position, Quaternion.identity);
        Destroy(temp, 2);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * 500);
        if (player.transform.position.x > transform.position.x)
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
