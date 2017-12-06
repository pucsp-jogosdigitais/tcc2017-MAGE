using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class CharacterManager : MonoBehaviour
{
    public Image Hp; //Representa a vida do jogador
    [Range(0f, 2f)] [SerializeField] float f_Gravity; //Representa a velocidade de deslocamento vertical substituindo a gravidade global
    public float f_JumpPower; //Representa a velocidade de deslocamento vertical
    public float f_MoveSpeed; //Representa a velocidade de deslocamento horizontal
    float f_VerticalVelocity; //Recebe o cálculo da velocidade no ar
    public bool StoneState = false; //Representa a codição de virar pedra
    Vector3 moveVector; //Recebe o cálculo da movimentação
    [HideInInspector] public CharacterController m_Controller; //CharacterController do jogador
    SkillCharacter m_Skill; //Script responsável pelos métodos das habilidades;
    Animator m_Animator; //Animator do jogador
    List<string> _lstAtivos = new List<string>(); //Lista de habilidades ativas
    List<string> _lstAllSkill = new List<string>(); //Lista de habilidades desbloqueadas
    private Quaternion PersonRotation; //Rotação do jogador
    public int jumpCount; //Quantidade disponível pra pular
    public int jumpLimit; //Limite do pulo
    public ParticleSystem doubleJumpParticle, onGround; //Sistemas de particula do duplo pulo e de cair no chão
    public Material MatProtag; //Material do modelo
    public PlayerAnimation setAnim; //Script com todas as animações referentes ao jogador
    float velocityInAir; //Calcula a velocidade no ar do jogador
    Vector3 posicao; //Representa o transform.position do jogador
    public bool Nascer; //Usado para verificar se o jogador está começando um novo jogo ou carregando um jogo salvo
    float bornTime = 7.5f; //Tempo para nascer
    public AudioClip[] m_FootstepSounds; //Lista de sons do passo
    public AudioClip[] m_JumpSounds; //Lista de sons do pulo
    private AudioSource m_AudioSource; //Audio Source do jogador
    int randomstep; //Representa o valor randomico a ser gerado do som do passo
    int randomjump; //Representa o valor randomico a ser gerado do som do pulo
    public bool travar; //Trava e destrava posição do jogador




    //public Image HP;

    private void Update()
    {

        //As próximas 3 linhas impedem o jogador de ser jogado para fora da área de interação do jogo
        posicao = transform.position;
        posicao.z = -4;
        transform.position = posicao;

        if (Nascer && !DadosPersistentes.Reload)
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
        MatProtag.color = Color.white;

        transform.position = new Vector3(DadosPersistentes.x, DadosPersistentes.y, DadosPersistentes.z); //Recebe a posição do arquivo salvo
        travar = false;
        if (!DadosPersistentes.Reload) //Faz o jogador nascer
        {
            Nascer = true;
        }
        else //Faz o jogador aparecer depois de carregar um jogo salvo
        {
            travar = true;
            StartCoroutine(ReloadTime());
        }

        //inicializa as habilidades ativas
        _lstAtivos.Add("");
        _lstAtivos.Add("");
        _lstAtivos.Add("");
        _lstAtivos.Add("");
        //Inicializa as habilidades liberadas (somente para a apresentação)
        _lstAllSkill.Add("StoneState");
        _lstAllSkill.Add("FlameThrower");
        _lstAllSkill.Add("MagicMissle");
        _lstAllSkill.Add("Clone");
        _lstAllSkill.Add("Dash");
        
        m_Animator = GetComponent<Animator>();
        m_Controller = GetComponent<CharacterController>();
        m_Skill = GetComponent<SkillCharacter>();
        jumpCount = jumpLimit;
        m_AudioSource = GetComponent<AudioSource>();
    }


    private void JumpSound() //Reproduz o som do pulo
    {
        AudioClip clip = GetRandomJump();
        m_AudioSource.PlayOneShot(clip);
    }

    private void Step() //Reproduz o som do passo
    {
        AudioClip clip = GetRandomStep();
        m_AudioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomStep() //Gera um som aleatório do passo
    {
        randomstep = Random.Range(0, m_FootstepSounds.Length);
        return m_FootstepSounds[randomstep];
    }

    private AudioClip GetRandomJump() //Gera um som aleatório do pulo
    {
        randomjump = Random.Range(0, m_JumpSounds.Length);
        return m_JumpSounds[randomjump];
    }

    public void SetAtivos(int posicao, string ativo) //troca a habilidade escolhida pelo jogador
    {      
        _lstAtivos.Insert(posicao, ativo);
    }

    public void ButtonSelect(int buttonTriggered) //Recebe o input das habilidades do jogador
    {
        if (buttonTriggered == -1) //Valor padrão para evitar o ativamento de alguma habilidade sem pressionar nenhum botão
        {
            return;
        }
        string name = _lstAtivos[buttonTriggered];
        
        if (moveVector.x == 0) //Trava o personagem para não quebrar a animação da habilidade
        {
            switch (name) //Ativa a habilidade que o jogador usou
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
    }





    public void RotationCharacter(bool right) //Método responsável por toda a rotação do jogador
    {
        if (Hp.fillAmount <= 0)
            return;
        if (!StoneState && !Nascer && !travar) //Trava a rotação se tiver nascendo, soltando habilidade ou estiver virado em pedra
        {
            if (right) //Vira o personagem para a direita
            {
                PersonRotation = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, PersonRotation, Time.deltaTime * 4);
            }
            else //Vira o personagem para a esquerda
            {
                PersonRotation = Quaternion.Euler(0, -180, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, PersonRotation, Time.deltaTime * 4);
            }
        }
    }

    public void Move(bool jump, float f_Horizontal) //Método responável por toda a movimentação do jogador
    {
        if (Hp.fillAmount <= 0) //Se o personagem morrer, trava a posição para rodar a animação de morte
            return;
        if (StoneState) //Trasforma em pedra
        {
            travar = true;
            moveVector = new Vector3(0, -3, 0); //Garante que vai cair se tiver no ar
            m_Controller.Move(moveVector);
            m_Animator.SetBool("Walk", false);
        }

        else if (travar) //Trava a posição em outras circunstâncias
        {
            moveVector = Vector3.zero;
            m_Controller.Move(moveVector);
            m_Animator.SetBool("Walk", false);
        }
        else
        {
            setAnim.SetWalkAndIdle(f_Horizontal); //Liga a animação de andar e ficar parado


            if (m_Controller.isGrounded) //Verifica se o jogador está no chão
            {
                jumpCount = jumpLimit; //Limita o pulo do jogador
                f_VerticalVelocity = -f_Gravity * Time.deltaTime; //Calculo para adicionar gravidade

                if (jump && jumpCount != 0)// Aplica o pulo quando o jogador está no chão
                {
                    JumpSound();
                    jumpCount--;
                    f_VerticalVelocity = f_JumpPower;
                }
            }
            else
            {
                if (jumpCount == jumpLimit) //Se estiver no ar o conta como se o jogador tivesse um pulo a menos
                    jumpCount--;

                if (jump && jumpCount != 0)//Aplica o pulo quando o jogador estiver no ar
                {
                    JumpSound();
                    doubleJumpParticle.Play();
                    jumpCount--;
                    f_VerticalVelocity = f_JumpPower;
                }
                f_VerticalVelocity -= f_Gravity * Time.deltaTime; //Calculo para adicionar gravidade
            }
            moveVector = new Vector3(f_Horizontal * f_MoveSpeed * Time.deltaTime * 40, f_VerticalVelocity, 0); // Vetor de movimento e de pulo aplicado
            if (m_Controller.enabled)
            {
                m_Controller.Move(moveVector);
            }

        }

    }

    public string SetSlot(int index) //Retorna a habilidade que o jogador quer mudar da lista de habilidades ativas
    {
        return _lstAtivos[index].ToString();
    }

    public string SetSkill(int index) //Retorna a habilidade que o jogador escolheu da lista de habildiades disponíveis
    {
        return _lstAllSkill[index].ToString();
    }

    public void Born(float time, Vector3 pos) //Método de cuida de todo o processo do jogador nascendo
    {
        m_Controller.enabled = false;
        transform.position = pos;
        StartCoroutine(IsBorning(time));
    }

    IEnumerator IsBorning(float time) //Corrotina responsável pelo tempo de nascimento do jogador
    {
        yield return new WaitForSeconds(time);
        //camera.enabled = true;
        Nascer = false;
        m_Controller.enabled = true;
    }
    IEnumerator ReloadTime() //Corrotina responsável pelo tempo do jogador retomar o controle depois de carregar um jogo salvo
    {
        yield return new WaitForSeconds(bornTime);
        //camera.enabled = true;
        travar = false;
    }

    public void Travar() //Método que trava a posição do jogador
    {
        if (travar)
        {
            m_Animator.SetBool("Walk", false);
            posicao.x = -44;
            posicao.z = -4;
        }

    }
}
