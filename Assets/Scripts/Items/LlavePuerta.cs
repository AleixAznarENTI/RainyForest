using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LlavePuerta : MonoBehaviour
{
    // Start is called before the first frame update
    public bool keyAble;
    public char doorToUnlock;

    public GameObject Panel;
    string Alert = "Now you have the key!";
    public TMP_Text texto;

    public GameObject particles;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (keyAble)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioManager.instance.PlaySFX("KeyObtained");
                GameManager.instance.unlock.Add(doorToUnlock);
                
                StartCoroutine(AlertPanel());
                gameObject.GetComponent<SpriteRenderer>().sprite = null;
                GameObject temp = Instantiate(particles, transform.position, Quaternion.identity);
                Destroy(temp, 1);
                
            }
        }
    }

    IEnumerator AlertPanel()
    {
        Panel.SetActive(true);
        foreach(char ch in Alert)
        {
            texto.text += ch;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2f);

        Panel.SetActive(false);
        gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        keyAble = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        keyAble = false;
    }

}
