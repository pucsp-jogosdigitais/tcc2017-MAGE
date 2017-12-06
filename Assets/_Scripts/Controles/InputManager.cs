using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{


    public CharacterManager m_Player;
    public PauseSwitch p_Switch;
    public InGameMenu inGameMenu;
    private bool m_Jump, m_Trigger1, m_Trigger2, m_Button1, m_Button2, m_Button3, m_Button4, Tg3, Tg4;
    private float m_Horizontal, m_Trigger4;
    public bool right = true;
    public bool Equiped = false;
    public bool m_Get_Objects, m_Pause, m_Interact;
    [SerializeField] private int i_buttonTriggered = -1;
    int m_Trigger3;

    void Start()
    {

    }

    void Update()
    {
        //Condicional para enviar o valor literal da direção do player
        if (m_Horizontal > 0)
            right = true;
        else if (m_Horizontal < 0)
            right = false;


        m_Player.Move(m_Jump, m_Horizontal); //Envia as informações de movimento para o script responável pelo player
        m_Player.RotationCharacter(right); //Envia as informações de doratção para o script responsável pelo player
        inGameMenu.Pause(m_Pause); //Pausa o jogo



        m_Horizontal = Input.GetAxis("Horizontal"); //Input de movimentação horizontal
        m_Jump = Input.GetButtonDown("Jump"); //Input de movimentação vertical (pulo)
        m_Get_Objects = Input.GetButtonDown("Get"); //Input para pegar objetos
        m_Interact = Input.GetButtonDown("Interact"); //Input de interação com o cenário
        m_Pause = Input.GetButtonDown("Pause"); //Input para pausar o jogo

        #region Input dos triggers
        m_Button1 = Input.GetButtonDown("Button1");
        m_Button2 = Input.GetButtonDown("Button2");
        m_Button3 = Input.GetButtonDown("Button3");
        m_Button4 = Input.GetButtonDown("Button4");
        #endregion
        #region Trigger das habilidades
        if (m_Button1)
        {
            i_buttonTriggered = 0;
        }
        else if (m_Button2)
        {
            i_buttonTriggered = 1;
        }
        else if (m_Button3)
        {
            i_buttonTriggered = 2;
        }
        else if (m_Button4)
        {
            i_buttonTriggered = 3;
        }
        else
        {
            i_buttonTriggered = -1;
        }
        m_Player.ButtonSelect(i_buttonTriggered);
        #endregion
    }
}
