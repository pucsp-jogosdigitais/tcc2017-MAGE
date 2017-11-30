using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Image black;
    public Animator mascaraFade;
	public bool m_AutoLoad = true;
	public string m_LevelToLoad;
	public GameObject player, bk;
	string xKey, yKey, zKey, cajado;
	// Use this for initialization
	void Start()
	{
        xKey = "X trasform";
		yKey = "Y trasform";
		zKey = "Z trasform";
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

	public void Quit()
	{
		Application.Quit();
	}

	public void NewGame()
	{
		PlayerPrefs.DeleteAll();
		DadosPersistentes.x = 0;
		DadosPersistentes.y = 0;
		DadosPersistentes.z = -4;
		DadosPersistentes.cajado = 0;
        LoadLevel("THELEVEL");
        //SceneManager.LoadScene(s_LevelToLoad);
        //StartCoroutine(FadingScreen(s_LevelToLoad));
    }

	public void SaveGame()
	{
		PlayerPrefs.SetFloat(xKey, player.transform.position.x);
		PlayerPrefs.SetFloat(yKey, player.transform.position.y);
		PlayerPrefs.SetFloat(zKey, player.transform.position.z);
		PlayerPrefs.SetInt(cajado, DadosPersistentes.cajado);
		PlayerPrefs.Save();
	}

	public void LoadGame()
	{
		DadosPersistentes.x = PlayerPrefs.GetFloat(xKey);
		DadosPersistentes.y = PlayerPrefs.GetFloat(yKey);
		DadosPersistentes.z = PlayerPrefs.GetFloat(zKey);
		DadosPersistentes.cajado = PlayerPrefs.GetInt(cajado);
        LoadLevel("THELEVEL");
        //SceneManager.LoadScene(s_LevelToLoad);
        //StartCoroutine(FadingScreen(s_LevelToLoad));
    }
    public void LoadLevel(string s_LevelToLoad)
    {
        Time.timeScale = 1.5f;
        StartCoroutine(Fading(s_LevelToLoad));
    }

    IEnumerator Fading(string s_LevelToLoad)
    {       
        mascaraFade.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        DadosPersistentes.NextLevel = s_LevelToLoad;
        SceneManager.LoadScene("Loading");
    }
}
