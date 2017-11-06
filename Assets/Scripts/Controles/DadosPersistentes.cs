using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadosPersistentes
{
    public static string NextLevel = "";
	public static float x = -21;
	public static float y = 0;
	public static float z = -4;
	public static int cajado = 0;
    //caso nao puder usar vector3 no playerPrefs, apagar esta linha
    public static Vector3 posicaoPlayerSalva = new Vector3(-21, 0, -4);
}
