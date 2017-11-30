using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSwitch : MonoBehaviour
{
	public List<GameObject> Tiles;
    public GameObject livro;
    public Animator livroAnim;

    private void Awake()
    {
        //Animator overAnimator = Tiles[0].GetComponent<Animator>();

        //overAnimator.SetTrigger("FadeOutFast");
    }

    public void PauseEnable(bool Pause)
	{
		if (Pause)
		{
            livro.SetActive(true);
            livroAnim.SetTrigger("Subir");

            Tiles[0].SetActive(false);
			Tiles[1].SetActive(true);
			
		}
	}

    public void ReturnGame()
    {
        MainMenu.Instance.FadeOut(ReturnGameEnded, 1);
    }

    public void ReturnGameEnded()
	{       
        Time.timeScale = 1.8f;
        livroAnim.SetTrigger("Descer");
        StartCoroutine(esperar("Fechar"));
        Tiles[0].SetActive(true);
		Tiles[1].SetActive(false);
        Tiles[2].SetActive(false);
        Tiles[3].SetActive(false);
        Tiles[4].SetActive(false);
        Tiles[5].SetActive(false);
        Tiles[6].SetActive(false);
        Tiles[7].SetActive(false);
        Tiles[8].SetActive(false);
        Tiles[9].SetActive(true);
        Tiles[10].SetActive(false);
    }

	public void OptionOpen()
	{
        MainMenu.Instance.FadeOut(OptionOpenEnded);
	}

    private void OptionOpenEnded()
    {
        Tiles[0].SetActive(false);
        Tiles[1].SetActive(true);
    }

    public void ReturnPauseMenu()
	{
        MainMenu.Instance.FadeOut(ReturnPauseMenuEnded, 1);
    }

    private void ReturnPauseMenuEnded()
    {
        Tiles[0].SetActive(true);
        Tiles[1].SetActive(false);
        Tiles[2].SetActive(false);
        Tiles[3].SetActive(false);
        Tiles[4].SetActive(false);
    }

    public void MapOpen()
	{
		Tiles[1].SetActive(false);
		Tiles[3].SetActive(true);
	}

	public void MagicOpen()
	{
		Tiles[1].SetActive(false);
		Tiles[4].SetActive(true);
	}
    
    public void StoryOpen()
	{
        MainMenu.Instance.FadeOut(StoryOpenEnded);
	}

    public void StoryOpenEnded()
    {
        Tiles[0].SetActive(false);
        Tiles[2].SetActive(true);
        Tiles[9].SetActive(false);
        Tiles[10].SetActive(true);
    }

    public void PageJumpRight()
    {
        MainMenu.Instance.FadeOut(PageJumpRightEnded, -1);
    }

    public void PageJumpLeft()
    {
        MainMenu.Instance.FadeOut(PageJumpLeftEnded, 1);
    }

    public void PageJumpRightEnded()
    {
        if (Tiles[2].active)
        {
            Tiles[2].SetActive(false);
            Tiles[3].SetActive(true);
        }
        else if (Tiles[3].active)
        {

            Tiles[3].SetActive(false);
            Tiles[4].SetActive(true);
        }
        else if (Tiles[4].active)
        {
            Tiles[4].SetActive(false);
            Tiles[5].SetActive(true);
        }
        else if (Tiles[5].active)
        {
            Tiles[5].SetActive(false);
            Tiles[6].SetActive(true);
        }
    }

    public void PageJumpLeftEnded()
    {
        if (Tiles[3].active)
        {
            Tiles[3].SetActive(false);
            Tiles[2].SetActive(true);
        }
        else if (Tiles[4].active)
        {

            Tiles[4].SetActive(false);
            Tiles[3].SetActive(true);
        }
        else if (Tiles[5].active)
        {
            Tiles[5].SetActive(false);
            Tiles[4].SetActive(true);
        }
        else if (Tiles[6].active)
        {
            Tiles[6].SetActive(false);
            Tiles[5].SetActive(true);
        }
        else if (Tiles[7].active)
        {
            Tiles[7].SetActive(false);
            Tiles[6].SetActive(true);
        }
        else if (Tiles[8].active)
        {
            Tiles[8].SetActive(false);
            Tiles[0].SetActive(true);
        }
    }

    public void OpenCredits()
    {
        MainMenu.Instance.FadeOut(OpenCreditsEnded);
    }

    public void OpenCreditsEnded()
    {
        Tiles[0].SetActive(false);
        Tiles[8].SetActive(true);
    }

    public void ReturnCheckpoint()
	{
		Tiles[7].SetActive(false);
		Tiles[6].SetActive(true);
	}

	public void OpenCheckpoint()
	{
		Tiles[0].SetActive(false);
		Tiles[6].SetActive(true);
		Time.timeScale = 0;
	}

	public void MagicSelectionOpen()
	{
		Tiles[6].SetActive(false);
		Tiles[7].SetActive(true);
	}
    
    public void GameOverScreen()
    {
        Debug.Log("Tela de Morte");

        Tiles[0].SetActive(true);

        Animator uiAnimator = Tiles[1].GetComponent<Animator>();
        Animator overAnimator = Tiles[0].GetComponent<Animator>();

        uiAnimator.SetTrigger("FadeOut");
        overAnimator.SetTrigger("FadeIn");
    }

    IEnumerator esperar(string name)
    {
        yield return new WaitForSeconds(2);

        if (name == "Abrir")
        {
            Time.timeScale = 0;
        }

        if (name == "Fechar")
        {            
            livro.SetActive(false);
        }       
    }
}
