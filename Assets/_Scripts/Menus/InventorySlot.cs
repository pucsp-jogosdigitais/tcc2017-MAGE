using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    Skill skill;


    public void AddSkill(Skill newSkill)
    {
        skill = newSkill;

        icon.sprite = skill.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void RemoveSkill()
    {
        skill = null;

        icon = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.Instance.Remove(skill);
    }
}
