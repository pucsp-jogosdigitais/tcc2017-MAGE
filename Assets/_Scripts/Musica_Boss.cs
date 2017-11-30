using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica_Boss : MonoBehaviour {

    public GameObject musicaBoss;
    public GameObject musicaNormal;
    public GameObject cameraBoss;
    public GameObject cameraPlayer;

    // Use this for initialization
    void Start () {
        cameraBoss.SetActive(false);
        cameraPlayer.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            musicaNormal.SetActive(false);
            musicaBoss.SetActive(true);

            cameraBoss.SetActive(true);
            cameraPlayer.SetActive(false);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            musicaNormal.SetActive(true);
            musicaBoss.SetActive(false);

            cameraBoss.SetActive(false);
            cameraPlayer.SetActive(true);
        }

    }


}
