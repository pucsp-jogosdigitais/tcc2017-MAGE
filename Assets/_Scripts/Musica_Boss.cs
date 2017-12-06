using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica_Boss : MonoBehaviour {

    public GameObject musicaBoss;
    public GameObject musicaNormal;
    public GameObject cameraBoss;
    public GameObject cameraPlayer;
    public GameObject paredeBoss;
    public GameObject paredeBoss1;
    public GameObject BOSS;
    public ParticleSystem poof;
    public ParticleSystem poof2;

    [SerializeField]
    public Canvas UI;

    // Use this for initialization
    void Start () {
        cameraBoss.SetActive(false);
        cameraPlayer.SetActive(true);
        BOSS.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BOSS.SetActive(true);
            musicaNormal.SetActive(false);
            musicaBoss.SetActive(true);
            paredeBoss.SetActive(true);
            paredeBoss1.SetActive(true);
            cameraBoss.SetActive(true);
            cameraPlayer.SetActive(false);
            poof.Play();
            poof2.Play();
            UI.worldCamera = cameraBoss.GetComponent<Camera>();
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

            UI.worldCamera = cameraPlayer.GetComponent<Camera>();
        }

    }


}
