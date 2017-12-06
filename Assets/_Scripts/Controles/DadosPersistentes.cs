using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadosPersistentes
{
    //Script responsável pela troca de algumas informações importantes entre as cenas
    public static string NextLevel = ""; //Cena a ser carregada
	//public static float x = -44;
	//public static float y = -3.15f;
	//public static float z = -4;

    //Posições do player
    public static float x = -44;
    public static float y = 0;
    public static float z = 0;

    public static int cajado = 0; //Se está com o cajado ou não
    public static bool Reload = false; //Se está carregando o jogo ou começando um novo
}
