using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public delegate void OnSkillChanged();
    public OnSkillChanged onSkillChangedCallBack;


    public int Space = 12;
    public List<Skill> skills = new List<Skill>();



    public void Add(Skill skill)
    {
        if (skills.Count <= Space)
        {
            skills.Add(skill);
            if(onSkillChangedCallBack != null)
                onSkillChangedCallBack.Invoke();
        }
    }

    public void Remove(Skill skill)
    {
        skills.Remove(skill);
        if (onSkillChangedCallBack != null)
            onSkillChangedCallBack.Invoke();
    }
}
