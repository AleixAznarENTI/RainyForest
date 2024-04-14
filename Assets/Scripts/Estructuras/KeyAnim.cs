using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnim : MonoBehaviour
{
    public Sprite[] keysSprites;
    float currTime;
    int count = 1;
    int mathCount = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if(currTime >= .5f)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = keysSprites[count];
            count += mathCount;
            mathCount *= -1;
            currTime = 0;
        }
    }
}
