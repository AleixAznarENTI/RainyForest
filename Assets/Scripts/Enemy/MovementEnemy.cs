using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [Header("Movimiento")]
    public int speed;

    [Header("Deteccion de suelo")]
    [Range(0f, 2f)]
    public float raycastDistance;
    public LayerMask layerMask;
    public bool grounded;

    public Vector2[] points;
    public float currTime;
    private void Update()
    {
        if (speed < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    private void FixedUpdate()
    {
        currTime += Time.deltaTime;
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        if (currTime > 0.5f)
        {
            foreach (Vector2 p in points)
            {


                RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)p, -Vector2.up, raycastDistance, layerMask);
                Debug.DrawRay(transform.position + (Vector3)p, -Vector2.up * raycastDistance, Color.blue);
                Debug.DrawRay(transform.position + (Vector3)p, -Vector2.up * hit.distance, Color.green);
                if (hit.collider == null)
                {
                    speed *= -1;
                    currTime = 0;
                    
                }

            }
        }
    }
}
