using System;
using UnityEngine;

public class Level_Menu : MonoBehaviour
{
    private static Level_Menu m_Instance;
    public AudioSource buttonSound;

    Action m_AfterFadeIn;

    public static Level_Menu Instance
    {
        get { return m_Instance; }
    }

    private void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //[SerializeField] string firstlevel;
    //[SerializeField] string HubLevel;

    [SerializeField]
    Animator livro;
    [SerializeField]
    Animator menuAnim;
    [SerializeField]
    CanvasGroup m_CanvasGroup;

    public void FadeIn()
    {
        menuAnim.SetTrigger("FadeIn");
    }

    public void FadeInStarted()
    {
        if (m_AfterFadeIn != null)
        {
            m_AfterFadeIn.Invoke();
        }
    }

    public void FadeOut()
    {
        FadeOut(null, -1);
    }

    public void FadeOut(Action func)
    {
        FadeOut(func, -1);
    }

    public void FadeOut(Action func, int direction)
    {
        LivroControl.Instance.PageDirection = direction;
        menuAnim.SetTrigger("FadeOut");
        m_AfterFadeIn = func;
    }

    public void PlaySound()
    {
        buttonSound.Play();
    }

    public void NewGame()
    {
        //SceneManager.LoadScene(firstlevel);
    }


    public void Continue()
    {
        //SceneManager.LoadScene(HubLevel);
    }


    public void Quit()
    {
        //Application.Quit();

    }

}
