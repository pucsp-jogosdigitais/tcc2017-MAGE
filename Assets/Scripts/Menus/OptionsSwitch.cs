using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsSwitch : MonoBehaviour
{
	public List<GameObject> Tiles;
	public AudioSource music;
	public AudioSource fx;
	//AudioListener playerAudio;

	public void VideoSettings()
	{
		Tiles[0].SetActive(true);
		Tiles[1].SetActive(false);
		Tiles[2].SetActive(false);
	}

	public void AudioSettings()
	{
		Tiles[0].SetActive(false);
		Tiles[1].SetActive(true);
		Tiles[2].SetActive(false);
	}

	public void ControlsSettings()
	{
		Tiles[0].SetActive(false);
		Tiles[1].SetActive(false);
		Tiles[2].SetActive(true);
	}

	public void Graphics(Text txt)
	{
		switch (txt.text)
		{
			case "Fantastic":
				QualitySettings.SetQualityLevel(0);
				txt.text = "Fastest";
				break;
			case "Beautiful":
				QualitySettings.SetQualityLevel(5);
				txt.text = "Fantastic";
				break;
			case "Good":
				QualitySettings.SetQualityLevel(4);
				txt.text = "Beautiful";
				break;
			case "Simple":
				QualitySettings.SetQualityLevel(3);
				txt.text = "Good";
				break;
			case "Fast":
				QualitySettings.SetQualityLevel(2);
				txt.text = "Simple";
				break;
			case "Fastest":
				QualitySettings.SetQualityLevel(1);
				txt.text = "Fast";
				break;

		} 
	}
	
	public void FullScreenMode(Text txt)
	{
		switch (txt.text)
		{
			case "Fullscreen":
				txt.text = "Windows";
				Screen.fullScreen = !Screen.fullScreen;
				break;
			case "Windows":
				txt.text = "Fullscreen";
				Screen.fullScreen = Screen.fullScreen;
				break;
		}
	}

	public void InputControl(Text txt)
	{
		switch (txt.text)
		{
			case "Keyboard":
				txt.text = "Playstation";
				break;
			case "Xbox":
				txt.text = "Keyboard";
				break;
			case "Playstation":
				txt.text = "Xbox";
				break;
		}
	}

	public void MusicListen(Slider mixer)
	{
		music.volume = mixer.value;
	}
	public void FxListen(Slider mixer)
	{
		fx.volume = mixer.value;
	}
	public void MasterListen(Slider mixer)
	{
		fx.volume = mixer.value;
		music.volume = mixer.value;
	}
}
