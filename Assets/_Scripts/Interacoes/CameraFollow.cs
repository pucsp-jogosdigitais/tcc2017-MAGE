using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	// Use this for initialization
	Vector3 PosInicial;
	Vector3 PosPersonagem;
	Vector3 PosAtual;
	public GameObject Personagem;
	private Transform c_cam;
	private float hCamera;
	private float vCamera;
	[Range (1,30)] public float distanceCam;
	Vector3 inputDirection = Vector3.zero;

	//void Start()
	//{		
	//	if (Camera.main != null)
	//	{
	//		c_cam = Camera.main.transform;
	//	}
	//	PosInicial = c_cam.transform.position;
		
	//}

	//// Update is called once per frame
	//void Update()
	//{
	//	PosPersonagem = Personagem.transform.position + PosInicial;

	//	hCamera = Input.GetAxis("CameraX");
	//	vCamera = Input.GetAxis("CameraY");

	//	inputDirection.x = hCamera;
	//	inputDirection.z = vCamera;

	//	if (hCamera != 0 || vCamera != 0)
	//	{
	//		PosAtual.x = PosPersonagem.x + (hCamera * distanceCam);
	//		PosAtual.y = PosPersonagem.y + (vCamera * distanceCam);
	//		PosAtual.z = PosPersonagem.z;
	//		c_cam.transform.position =  PosAtual;
	//	}
	//	else
	//	{
	//		c_cam.position = PosPersonagem;
	//	}
		
	//}
}
