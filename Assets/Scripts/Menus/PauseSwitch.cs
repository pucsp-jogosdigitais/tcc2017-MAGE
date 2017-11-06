using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSwitch : MonoBehaviour
{
	public List<GameObject> Tiles;

	public void PauseEnable(bool Pause)
	{
		if (Pause)
		{
			Tiles[0].SetActive(false);
			Tiles[1].SetActive(true);
			Time.timeScale = 0;
		}
	}

	public void ReturnGame()
	{
		Time.timeScale = 1.8f;
		Tiles[0].SetActive(true);
		Tiles[1].SetActive(false);
		Tiles[6].SetActive(false);
	}

	public void OptionOpen()
	{
		Tiles[1].SetActive(false);
		Tiles[2].SetActive(true);
	}

	public void ReturnPauseMenu()
	{
		Tiles[1].SetActive(true);
		Tiles[2].SetActive(false);
		Tiles[3].SetActive(false);
		Tiles[4].SetActive(false);
		Tiles[5].SetActive(false);

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
		Tiles[1].SetActive(false);
		Tiles[5].SetActive(true);
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
}
