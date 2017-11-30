using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadosPersistentes
{
    public static string NextLevel = "";
	public static float x = -44;
	public static float y = -3.15f;
	public static float z = -4;
	public static int cajado = 0;
    //caso nao puder usar vector3 no playerPrefs, apagar esta linha
    public static Vector3 posicaoPlayerSalva = new Vector3(-21, 0, -4);
}
