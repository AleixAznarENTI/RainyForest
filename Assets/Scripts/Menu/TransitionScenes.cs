using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScenes : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        AudioManager.instance.PlaySFX("Click");
        LoadNextLevel("SampleScene");
    }
    public void Quit()
    {
        AudioManager.instance.PlaySFX("Click");
        Application.Quit();
    }

    public void Credits()
    {
        AudioManager.instance.PlaySFX("Click");
        LoadNextLevel("Credits");
    }

    public void MainMenu()
    {
        AudioManager.instance.PlaySFX("Click");
        LoadNextLevel("MainMenu");
    }


    public void LoadNextLevel(string Scene)
    {
        StartCoroutine(LoadLevel(Scene));
    }

    IEnumerator LoadLevel(string Scene)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(Scene);
    }
}
