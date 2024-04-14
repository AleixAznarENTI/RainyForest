using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cartel : MonoBehaviour
{
    // Start is called before the first frame update
    bool canRead;
    public Sprite uno;
    public Sprite dos;
    public string[] dialogueLines;
    public GameObject DialoguePanel;
    

    public GameObject key;
    public TMP_Text ola;
    bool dialogueStarted;
    int lineIndex;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (canRead)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = dos;
            key.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!dialogueStarted)
                {
                    StartDialogue();
                }
                else if (ola.text == dialogueLines[lineIndex])
                {
                    NextDialogueLine();
                }
                else
                {
                    StopAllCoroutines();
                    ola.text = dialogueLines[lineIndex];
                }
                
            }

        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = uno;
            key.SetActive(false);
        }


    }

    void StartDialogue()
    {
        dialogueStarted = true;
        DialoguePanel.SetActive(true);
        key.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0;
        StartCoroutine(ShowLine());
    }

    void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            Time.timeScale = 1;
            dialogueStarted = false;
            DialoguePanel.SetActive(false);
            key.SetActive(true);
        }
    }
    IEnumerator ShowLine()
    {
        ola.text = string.Empty;
        foreach(char ch in dialogueLines[lineIndex])
        {
            AudioManager.instance.PlaySFX("Click");
            ola.text += ch;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canRead = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canRead = false;
        }
    }
}
