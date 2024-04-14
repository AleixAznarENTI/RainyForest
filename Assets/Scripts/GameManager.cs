using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [Header("Player")]
    public int vidas = 3;
    public bool finished = false;
    public float initialX = -7.6f;
    public float initialY = 2.89f;

    [Header("Desbloqueable")]
    public List<char> unlock;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Destroy(this);
        }
    }
}
