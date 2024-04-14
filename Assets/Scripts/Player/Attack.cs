using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public Animator animator;

    public Transform AttackArea;
    public float area = 0.5f;
    public LayerMask enemyLayer;

    public float tiempoEntreAtaque = 1.0f;
    public float siguienteAtaque;

    public GameObject canAttack;

    public Sprite one;
    public Sprite two;

    void Start()
    {
        
    }

    void Update()
    {
        siguienteAtaque += Time.deltaTime;
        if (siguienteAtaque >= tiempoEntreAtaque)
        {
            Collider2D[] enemy = Physics2D.OverlapCircleAll(AttackArea.position, area, enemyLayer);
            foreach (Collider2D collider in enemy)
            {
                canAttack.GetComponent<Image>().sprite = two;
            }
            if(enemy.Length == 0)
            {
                canAttack.GetComponent<Image>().sprite = one;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                AudioManager.instance.PlaySFX("Whip");
                animator.SetTrigger("Attack");

                enemy = Physics2D.OverlapCircleAll(AttackArea.position, area, enemyLayer);
                foreach (Collider2D collider in enemy)
                {

                    collider.gameObject.GetComponent<Enemy>().TakeDamage(25);
                }
                siguienteAtaque = 0;
            }
        }
        else
        {
            canAttack.GetComponent<Image>().sprite = one;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(AttackArea.position, area);
    }
}
