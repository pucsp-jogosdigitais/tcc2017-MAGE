using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public Image Hp;
    [Range(0f, 2f)] [SerializeField] float f_Gravity;
    [SerializeField] float f_JumpPower;
    [SerializeField] float f_MoveSpeed;

    float f_VerticalVelocity;
    public bool StoneState = false;
    Vector3 moveVector;
    [HideInInspector] public CharacterController m_Controller;
    SkillCharacter m_Skill;
    Animator m_Animator;
    List<string> _lstAtivos = new List<string>();
    List<string> _lstAllSkill = new List<string>();
    private Quaternion PersonRotation;
    [SerializeField] int jumpCount;
    public int jumpLimit;
    bool grounded;
    public ParticleSystem doubleJumpParticle, onGround;
    public Material MatProtag;

    private void Update()
    {
        TravaPosicao();
    }
    void TravaPosicao()
    {
        Vector3 posicao = transform.position;
        posicao.z = -4;
        transform.position = posicao;
    }
    void Start()
    {
        MatProtag.color = Color.white;
        transform.position = new Vector3(DadosPersistentes.x, DadosPersistentes.y, DadosPersistentes.z);
        _lstAtivos.Add("");
        _lstAtivos.Add("");
        _lstAtivos.Add("");
        _lstAtivos.Add("");

        _lstAllSkill.Add("StoneState");
        _lstAllSkill.Add("FlameThrower");
        _lstAllSkill.Add("MagicMissle");
        _lstAllSkill.Add("Clone");
        _lstAllSkill.Add("Dash");
        m_Animator = GetComponent<Animator>();
        m_Controller = GetComponent<CharacterController>();
        m_Skill = GetComponent<SkillCharacter>();
        jumpLimit = 1;
        jumpCount = jumpLimit;
    }

    public void SetAtivos(int posicao, string ativo)
    {
        _lstAtivos.Insert(posicao, ativo);

    }

    public void ButtonSelect(int buttonTriggered)
    {
        if (buttonTriggered == -1)
        {
            return;
        }
        string name = _lstAtivos[buttonTriggered];
        switch (name)
        {
            case "StoneState":
                m_Skill.StoneState();
                break;
            case "FlameThrower":
                m_Skill.FlameThrower(PersonRotation);
                break;
            case "MagicMissle":
                m_Skill.MagicMissile(PersonRotation);
                break;
            case "Clone":
                m_Skill.Clone(PersonRotation);
                break;
        }
    }

    public void RotationCharacter(bool right)
    {
        if (!StoneState)
        {
            if (right)
            {
                PersonRotation = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, PersonRotation, Time.deltaTime * 4);
            }
            else
            {
                PersonRotation = Quaternion.Euler(0, -180, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, PersonRotation, Time.deltaTime * 4);
            }
        }
    }

    public void Move(bool jump, float f_Horizontal)
    {
        if (StoneState)
        {
            if (m_Controller.isGrounded && !grounded)
            {
                grounded = true;
                onGround.Play();
            }
            moveVector = new Vector3(0, -3, 0);
            m_Controller.Move(moveVector);
            m_Animator.SetBool("Andar", false);
        }
        else
        {
            SetAnimation(f_Horizontal, StoneState);

            if (m_Controller.isGrounded)
            {
                grounded = true;
                jumpCount = jumpLimit;
                f_VerticalVelocity = -f_Gravity * Time.deltaTime;
                if (jump && jumpCount != 0)
                {
                    jumpCount--;
                    f_VerticalVelocity = f_JumpPower;
                }
            }
            else
            {
                grounded = false;
                if (jumpCount == jumpLimit)
                    jumpCount--;

                if (jump && jumpCount != 0)
                {
                    doubleJumpParticle.Play();
                    jumpCount--;
                    f_VerticalVelocity = f_JumpPower;
                }
                f_VerticalVelocity -= f_Gravity * Time.deltaTime;
            }
            moveVector = new Vector3(f_Horizontal * f_MoveSpeed, f_VerticalVelocity, 0);
            m_Controller.Move(moveVector);
        }
    }

    private void SetAnimation(float move, bool stoneState)
    {
        if (move != 0 && !stoneState)
        {
            m_Animator.SetBool("Andar", true);
        }
        else
        {
            m_Animator.SetBool("Andar", false);
        }
    }

    public string SetSlot(int index)
    {
        return _lstAtivos[index].ToString();
    }

    public string SetSkill(int index)
    {
        return _lstAllSkill[index].ToString();
    }
}
