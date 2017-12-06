using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirBloqueio : MonoBehaviour
{
    //Script responsável pelo desabamento de alguns locais no jogo
    public Tips tips;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        NewMethod();
    }

    private void NewMethod()
    {
        if (tips.ativado == true)
        {
            Destroy(this.gameObject);
        }
    }
}
