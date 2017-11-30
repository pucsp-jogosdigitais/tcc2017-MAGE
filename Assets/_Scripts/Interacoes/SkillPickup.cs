using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPickup : Interagivel
{
    public Skill skill;
    public override void Interact()
    {
        base.Interact();
        Pickup();
    }

    void Pickup()
    {
        Inventory.Instance.Add(skill);
        Destroy(gameObject);
    }
}
