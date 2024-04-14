using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCondition : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject victory;
    public GameObject defeat;
    void Start()
    {
        if(GameManager.instance.vidas > 0)
        {
            victory.SetActive(true);
        }
        else
        {
            defeat.SetActive(true);
        }

        GameManager.instance.vidas = 3;
        GameManager.instance.finished = false;
        GameManager.instance.initialX = 0;
        GameManager.instance.initialY = 0;

    }
}
