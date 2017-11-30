using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Inventory/Skill")]
public class Skill : ScriptableObject
{
    new public string name = "New Skill";
    public Sprite icon = null;
    public bool isDefaultSkill = false;
}
