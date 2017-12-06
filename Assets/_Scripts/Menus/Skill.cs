using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Inventory/Skill")]
public class Skill : ScriptableObject
{
    //Menu criado para facilitar a criação de habilidades no jogo
    new public string name = "New Skill";
    public Sprite icon = null;
    public bool isDefaultSkill = false;
}
