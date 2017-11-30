using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform skillsParent;

    Inventory inventory;
    InventorySlot[] slots;

    void Start()
    {
        inventory = Inventory.Instance;
        inventory.onSkillChangedCallBack += UpdateUI;

        slots = skillsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {

    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.skills.Count)
            {
                slots[i].AddSkill(inventory.skills[i]);
            }

            else
            {
                slots[i].RemoveSkill();
            }
        }
    }
}
