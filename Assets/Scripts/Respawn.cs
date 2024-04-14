using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    [Header("Posicion Inicial")]
    public float initYLvl;
    public float initXLvl;


    [Header("Max Coords")]
    public float maxY;
    public float maxX;
    // Start is called before the first frame update

    public Animator animator;
    public Animator transitor;

    void Start()
    {
        initYLvl = GameManager.instance.initialY;
        initXLvl = GameManager.instance.initialX;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.finished)
        {
            StartCoroutine(Win());
        }
        if(transform.position.y <= maxY)
        {
            transform.position = new Vector3(GameManager.instance.initialX, GameManager.instance.initialY, 0);
            GameManager.instance.vidas--;
        }
        
            if (GameManager.instance.vidas <= 0)
            {

                StartCoroutine(Die());
                

            }
        
    }

    IEnumerator Die()
    {
        AudioManager.instance.PlaySFX("DieSound");
        animator.SetBool("Die", true);
        yield return new WaitForSeconds(.75f);
        transitor.SetTrigger("Start");
        animator.SetBool("Die", false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("EndGame");
        
    }
    IEnumerator Win()
    {
        
        yield return new WaitForSeconds(1f);
        transitor.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("EndGame");

    }
}
