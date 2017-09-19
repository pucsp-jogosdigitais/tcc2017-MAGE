using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool m_AutoLoad = true;
    public string m_LevelToLoad;
    // Use this for initialization
    void Start()
    {
        if (m_AutoLoad)
        {
            Invoke("LoadLevel", 3);
            m_AutoLoad = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel()
    {
        DadosPersistentes.NextLevel = m_LevelToLoad;
        SceneManager.LoadScene("Loading");
    }

    public void LoadLevel(string s_LevelToLoad)
    {

        DadosPersistentes.NextLevel = s_LevelToLoad;
        SceneManager.LoadScene("Loading");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
