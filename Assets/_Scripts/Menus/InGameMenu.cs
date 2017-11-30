using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{

    public List<GameObject> menus;
    public GameObject book, bk;
    public Animator bookAnim;
    public LevelManager levelManager;
    public InputManager input;
    bool pausing;

    public void Resume()
    {
        menus[0].SetActive(true);
        menus[1].SetActive(false);
        menus[4].SetActive(false);

        bookAnim.SetTrigger("Descer");
        Time.timeScale = 1.5f;
        pausing = false;
        StartCoroutine(AnimTime("resume"));
    }
    public void Pause(bool button)
    {
        if(button)
        {
            if (!pausing)
            {
                if (!menus[4].activeInHierarchy)
                {
                    pausing = true;
                    book.SetActive(true);
                    bookAnim.SetTrigger("Subir");                   
                    menus[0].SetActive(false);
                    StartCoroutine(AnimTime("pause"));
                }
            }
            else
            {
                Resume();
            }
        }
    }
    public void Chekpoint()
    {
        {
            if (!menus[1].activeInHierarchy)
            {
                book.SetActive(true);                
                bookAnim.SetTrigger("Subir");
                pausing = true;
                menus[0].SetActive(false);
                StartCoroutine(AnimTime("checkpoint"));
            }
        }

        if (input.m_Pause && pausing)
        {
            Resume();
        }
    }
    public void Options()
    {
        menus[1].SetActive(false);
        menus[4].SetActive(false);
        menus[2].SetActive(true);
    }
    public void Magics()
    {
        menus[1].SetActive(false);
        menus[4].SetActive(false);
        menus[3].SetActive(true);
    }
    public void MagicsSelect()
    {
        menus[1].SetActive(false);
        menus[4].SetActive(false);
        menus[5].SetActive(true);
    }
    public void GoToPause()
    {
        menus[1].SetActive(true);
        menus[2].SetActive(false);
        menus[3].SetActive(false);
    }
    public void GoToCheckpoint()
    {
        menus[4].SetActive(true);
        menus[2].SetActive(false);
        menus[5].SetActive(false);
    }

    IEnumerator AnimTime(string name)
    {
        yield return new WaitForSeconds(2);
        if (name == "checkpoint")
        {
            //menus[0].SetActive(false);
            menus[4].SetActive(true);
            Time.timeScale = 0;
        }
        else if(name == "pause")
        {
            //menus[0].SetActive(false);
            menus[1].SetActive(true);
            Time.timeScale = 0;
        }
        else if(name == "resume")
        {
            book.SetActive(false);
        }
    }
}
