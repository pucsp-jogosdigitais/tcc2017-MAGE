using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public bool m_AutoLoad = true;
	public string m_LevelToLoad;
	public GameObject player;
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

	public void LoadLevel()
	{
		DadosPersistentes.NextLevel = m_LevelToLoad;
		SceneManager.LoadScene("Loading");
	}

	public void LoadLevel(string s_LevelToLoad)
	{
		Time.timeScale = 1.8f;
		DadosPersistentes.NextLevel = s_LevelToLoad;
		SceneManager.LoadScene("Loading");
		Fading.Instance.Fade(true, 1.25f);
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void NewGame(string s_LevelToLoad)
	{
		PlayerPrefs.DeleteAll();
		DadosPersistentes.x = 0;
		DadosPersistentes.y = 0;
		DadosPersistentes.z = -4;
		DadosPersistentes.cajado = 0;

		LoadLevel(s_LevelToLoad);
	}

	public void SaveGame()
	{
		PlayerPrefs.SetFloat(xKey, player.transform.position.x);
		PlayerPrefs.SetFloat(yKey, player.transform.position.y);
		PlayerPrefs.SetFloat(zKey, player.transform.position.z);
		PlayerPrefs.SetInt(cajado, DadosPersistentes.cajado);
		PlayerPrefs.Save();
	}

	public void LoadGame(string s_LevelToLoad)
	{
		DadosPersistentes.x = PlayerPrefs.GetFloat(xKey);
		DadosPersistentes.y = PlayerPrefs.GetFloat(yKey);
		DadosPersistentes.z = PlayerPrefs.GetFloat(zKey);
		DadosPersistentes.cajado = PlayerPrefs.GetInt(cajado);
		LoadLevel(s_LevelToLoad);
	}
}
