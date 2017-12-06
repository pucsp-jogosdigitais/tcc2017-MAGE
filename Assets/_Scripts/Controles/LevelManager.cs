using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //Este script é resposável por todas as trocas de cena
    public Image black; //Mascara do fade
    public Animator mascaraFade; //Animação do fade
	public bool m_AutoLoad = true; //AutoLoad da tela de loading
	public string m_LevelToLoad; //Nome do level a ser carregado
	public GameObject player; 
	string xKey, yKey, zKey, cajado;
    public InGameMenu IGMenu;
	// Use this for initialization
	void Start()
	{
        xKey = "X trasform";
		yKey = "Y trasform";
		zKey = "Z trasform";

		if (m_AutoLoad) //Caso esteja na tela de loading, chama altomaticamente a próxima cena
		{
			Invoke("LoadLevel", 3);
			m_AutoLoad = false;
		}
    }

	public void Quit()
	{
		Application.Quit(); //Desliga o jogo
	}

	public void NewGame() //Cria um novo jogo zerando os dados salvos
	{
		PlayerPrefs.DeleteAll();
		DadosPersistentes.x = -44;
		DadosPersistentes.y = -3;
		DadosPersistentes.z = -4;
		DadosPersistentes.cajado = 0;
        LoadLevel("THELEVEL");
        //SceneManager.LoadScene(s_LevelToLoad);
        //StartCoroutine(FadingScreen(s_LevelToLoad));
    }

	public void SaveGame() //Salva os dados do jogador na memória
	{
        IGMenu.JogoSalvo();
		PlayerPrefs.SetFloat(xKey, player.transform.position.x);
		PlayerPrefs.SetFloat(yKey, player.transform.position.y);
		PlayerPrefs.SetFloat(zKey, player.transform.position.z);
		PlayerPrefs.SetInt(cajado, DadosPersistentes.cajado);
		PlayerPrefs.Save();
        
	}

	public void LoadGame() //Carrega um novo jogo com os dados salvos na memória
	{
        DadosPersistentes.x = PlayerPrefs.GetFloat(xKey);
        DadosPersistentes.y = PlayerPrefs.GetFloat(yKey);
        DadosPersistentes.z = PlayerPrefs.GetFloat(zKey);
        DadosPersistentes.cajado = PlayerPrefs.GetInt(cajado);
        DadosPersistentes.Reload = true;
        LoadLevel("THELEVEL");
        //SceneManager.LoadScene(s_LevelToLoad);
        //StartCoroutine(FadingScreen(s_LevelToLoad));
    }
    public void LoadLevel(string s_LevelToLoad) //Carrega qualquer cena do jogo
    {
        Time.timeScale = 1.5f;
        StartCoroutine(Fading(s_LevelToLoad));
    }

    IEnumerator Fading(string s_LevelToLoad) //Começa o Fade In e o Fade Out
    {       
        mascaraFade.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        DadosPersistentes.NextLevel = s_LevelToLoad;
        SceneManager.LoadScene("Loading");
    }
}
