using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoth : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    CharacterController controler;
    public float predictionx = 1;
    public float predictiony = 1;
    [SerializeField] float lerpVelocity;
    public float correctPos;
	Vector3 deltaposition;
    // Use this for initialization
    void Start()
    {
        controler = Player.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
		lerpVelocity = Time.deltaTime;
        //lerpVelocity = 0.025f;
        Vector3 posplayer = new Vector3(Player.transform.position.x, Player.transform.position.y + correctPos, transform.position.z);
        Vector3 velplayer = new Vector3(controler.velocity.x * predictionx, controler.velocity.y * predictiony, 0);
        transform.position = Vector3.Lerp(transform.position, posplayer + velplayer, lerpVelocity);
    }
}
