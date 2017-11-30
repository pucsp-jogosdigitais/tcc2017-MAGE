using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CharacterManager : MonoBehaviour
{
    public Image Hp;
    [Range(0f, 2f)] [SerializeField] float f_Gravity;
    public float f_JumpPower;
    public float f_MoveSpeed;

    float f_VerticalVelocity;
    public bool StoneState = false;
    Vector3 moveVector;
    [HideInInspector] public CharacterController m_Controller;
    SkillCharacter m_Skill;
    Animator m_Animator;
    List<string> _lstAtivos = new List<string>();
    List<string> _lstAllSkill = new List<string>();
    private Quaternion PersonRotation;
    public int jumpCount;
    public int jumpLimit;
    bool grounded;
    public ParticleSystem doubleJumpParticle, onGround;
    public Material MatProtag;
    public int life;
    public PlayerAnimation setAnim;
    float velocityInAir;
    Vector3 posicao;
    [HideInInspector] public bool TaVindoOMonstro;
    float bornTime = 7.5f;
    //public AudioSource SomAndar;
    public AudioClip[] m_FootstepSounds;
    public AudioClip[] m_JumpSounds;
    private AudioSource m_AudioSource;
    int randomstep;
    int randomjump;
    public bool travar;


	public float _MyTimeScale=1;
    //public Image HP;

    private void Update()
    {
		posicao = transform.position;
        posicao.z = -4;
        transform.position = posicao;

        if (TaVindoOMonstro)
        {
            posicao.x = -44;
            posicao.y = -3f;
            posicao.z = -4;
            Born(bornTime, posicao);
        }

        //TravaPosicao();
        velocityInAir = m_Controller.velocity.y;
        setAnim.SetJump(jumpCount, velocityInAir, jumpLimit);

    }

    void Start()
    {
        travar = false;
        TaVindoOMonstro = true;
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
        //jumpLimit = 1;
        jumpCount = jumpLimit;
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void JumpSound()
    {
        AudioClip clip = GetRandomJump();
        m_AudioSource.PlayOneShot(clip);
    }

    private void Step()
    {
        AudioClip clip = GetRandomStep();
        m_AudioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomStep()
    {
        randomstep = Random.Range(0, m_FootstepSounds.Length);
        return m_FootstepSounds[randomstep];
    }

    private AudioClip GetRandomJump()
    {
        randomjump = Random.Range(0, m_JumpSounds.Length);
        return m_JumpSounds[randomjump];
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
        if (moveVector.x == 0)
        {
            if(!m_Skill.inCooldown)
                setAnim.SetSkill(name);

            switch (name)
            {
                case "StoneState":
                    m_Skill.StoneState();
                    //setAnim.SetSkill(1);
                    break;
                case "FlameThrower":
                    m_Skill.FlameThrower(PersonRotation);
                    //setAnim.SetSkill(2);
                    break;
                case "MagicMissle":
                    m_Skill.MagicMissile(PersonRotation);
                    //setAnim.SetSkill(3);
                    break;
                case "Clone":
                    m_Skill.Clone(PersonRotation);
                    //setAnim.SetSkill(4);
                    break;
            }
        }
    }

    public void RotationCharacter(bool right)
    {
        if (Hp.fillAmount <= 0)
        	return;
        if (!StoneState && !TaVindoOMonstro && !travar)
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
        if (Hp.fillAmount <= 0)
        	return;
        if (StoneState)
        {
            if (m_Controller.isGrounded && !grounded)
            {
                grounded = true;
                onGround.Play();
            }
            travar = true;
            moveVector = new Vector3(0, -3, 0);
			m_Controller.Move(moveVector*Time.deltaTime*_MyTimeScale);
            m_Animator.SetBool("Walk", false);
        }

        else if (travar)
        {
            moveVector = Vector3.zero;
			m_Controller.Move(moveVector*Time.deltaTime*_MyTimeScale);
            m_Animator.SetBool("Walk", false);
        }
        else
        {
            //SetAnimation(f_Horizontal, StoneState);
            setAnim.SetWalkAndIdle(f_Horizontal);


            if (m_Controller.isGrounded)
            {
                grounded = true;
                jumpCount = jumpLimit;
                f_VerticalVelocity = -f_Gravity * Time.deltaTime ;

                if (jump && jumpCount != 0)
                {
                    JumpSound();
                    //setAnim.SetJump(jumpCount, velocityInAir);
                    jumpCount--;
                    f_VerticalVelocity = f_JumpPower * Time.deltaTime * _MyTimeScale;
                }
            }
            else
            {
                grounded = false;
                if (jumpCount == jumpLimit)
                    jumpCount--;

                if (jump && jumpCount != 0)
                {
                    JumpSound();
                    doubleJumpParticle.Play();
                    jumpCount--;
                    f_VerticalVelocity = f_JumpPower * Time.deltaTime * _MyTimeScale;
                }
                f_VerticalVelocity -= f_Gravity * Time.fixedDeltaTime;
            }
            moveVector = new Vector3(f_Horizontal * f_MoveSpeed, f_VerticalVelocity, 0);
            if (m_Controller.enabled)
            {
				m_Controller.Move(moveVector*Time.deltaTime*_MyTimeScale);
            }

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

    public void Born(float time, Vector3 pos)
    {
        m_Controller.enabled = false;
        transform.position = pos;
        //camera.enabled = false;
        StartCoroutine(IsBorning(time));
    }

    public void KillPlayer()
    { 
    
       if (Hp.fillAmount <= 0)
       {

           Debug.Log("Morreu");

       }
    
    }

    IEnumerator IsBorning(float time)
    {
        yield return new WaitForSeconds(time);
        //camera.enabled = true;
        TaVindoOMonstro = false;
        m_Controller.enabled = true;
    }

    public void Travar()
    {
        if (travar)
        {
            m_Animator.SetBool("Walk", false);
            posicao.x = -44;
            posicao.z = -4;
        }

    }
}
