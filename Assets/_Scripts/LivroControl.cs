using UnityEngine;

public class LivroControl : MonoBehaviour {
    [SerializeField]
    private GameObject m_Page;
    [SerializeField]
    private Animator m_Animator;

    private int m_PageDirection = -1;

    public int PageDirection
    {
        get { return m_PageDirection; }
        set { m_PageDirection = value; }
    }

    private static LivroControl m_Instance;

    public static LivroControl Instance
    {
        get { return m_Instance; }
    }

    private void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void FlipPage()
    {
        switch (m_PageDirection)
        {
            case -1:
                FlipLeft();
                break;
            case 1:
                FlipRight();
                break;
        }
    }

    public void FlipLeft()
    {
        m_Animator.SetTrigger("FlipLeft");
    }

    public void FlipRight()
    {
        m_Animator.SetTrigger("FlipRight");
    }
}
