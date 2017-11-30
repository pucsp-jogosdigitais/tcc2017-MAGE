using UnityEngine;

public class OpenTrigger : StateMachineBehaviour
{
    static bool m_BookOpened;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("MainMenu_FadeIn"))
        {
            MainMenu.Instance.FadeInStarted();
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Livro_aberto"))
        {
            if (!m_BookOpened)
            {
                MainMenu.Instance.FadeIn();

                m_BookOpened = true;
            }
        }

        if (stateInfo.IsName("FlipLeft"))
        {
            MainMenu.Instance.FadeIn();
        }

        if (stateInfo.IsName("FlipRight"))
        {
            MainMenu.Instance.FadeIn();
        }

        if (stateInfo.IsName("MainMenu_FadeOut"))
        {
            LivroControl.Instance.FlipPage();
        }
    }
}
