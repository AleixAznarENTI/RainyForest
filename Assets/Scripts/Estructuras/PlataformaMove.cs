using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMove : MonoBehaviour
{
    float comp;
    float count = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(comp < 5 && comp > -5)
        {
            transform.position += new Vector3(count,0,0)*Time.deltaTime;
            comp += count*Time.deltaTime;
        }
        else
        {
            count*=-1;
            transform.position += new Vector3(5*count, 0, 0)*Time.deltaTime;
            comp = 0;
        }
    }
}
