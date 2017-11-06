using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillChanger : MonoBehaviour
{
	public CharacterManager player;
	public List<Image> lstSprites;
	private Image selectSprite;
	private string slotName, skillName;
	private int slotNumber, spriteNumber;

	private void Start()
	{
		slotName = "";
		skillName = "";
	}

	private void Update()
	{

	}

	public void GetSlotPlayer(int index)
	{
		slotNumber = index;
		print(slotNumber);
		slotName = player.SetSlot(index);
		print(slotName);
	}

	public void GetSkillPlayer(int index)
	{
		//selectSprite = sprite;
		spriteNumber = index;
		print(spriteNumber);
		skillName = player.SetSkill(index);
		print(skillName);
		SetNewSkill();
	}

	private void SetNewSkill()
	{
		//player.SetAtivos(slotNumber, skillName);
		//ChangeSprite();
		if (slotName != "" && skillName != "")
		{
			if (slotNumber != 0 && skillName == player.SetSlot(0))
			{
				return;
			}
			if (slotNumber != 1 && skillName == player.SetSlot(1))
			{
				return;
			}
			if (slotNumber != 2 && skillName == player.SetSlot(2))
			{
				return;
			}
			if (slotNumber != 3 && skillName == player.SetSlot(3))
			{
				return;
			}
			player.SetAtivos(slotNumber, skillName);
			//ChangeSprite();
		}
		slotName = "";
		skillName = "";
	}

	public void ChangeSprite()
	{
		if (spriteNumber == 0)
		{
			selectSprite = lstSprites[0];
		}
		if (spriteNumber == 1)
		{
			selectSprite = lstSprites[1];
		}
		if (spriteNumber == 2)
		{
			selectSprite = lstSprites[2];
		}
		if (spriteNumber == 3)
		{
			selectSprite = lstSprites[3];
		}
	}
}
