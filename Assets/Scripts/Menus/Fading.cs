﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
	public static Fading Instance { get; set; }
	public Image fadeImage;

	private bool isInTransition;
	private float transition;
	private bool isShowing;
	private float duration;

	private void Awake()
	{
		Instance = this;
	}

	private void Update()
	{
		if (!isInTransition)
			return;

		transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
		fadeImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.black, transition);

		if(transition > 1 || transition < 0)
		{
			isInTransition = false;
		}
	}

	public void Fade (bool showing, float duration)
	{
		isShowing = showing;
		isInTransition = true;
		this.duration = duration;
		transition = (isShowing) ? 0 : 1;
	}
}
