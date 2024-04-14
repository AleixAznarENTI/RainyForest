using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Image> lifes;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = lifes.Count; i > 0; i--)
        {
            if(GameManager.instance.vidas < i)
            {
                lifes[i - 1].color = Color.red;
            }
            else
            {
                lifes[i-1].color = Color.green;
            }
        }
    }
}
