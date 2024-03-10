using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PassiveSkillUI : MonoBehaviour
{
    [SerializeField] Image skillImage;
    [SerializeField] TMP_Text nameText;

    Skill skill;
    public void Setup(Skill passiveSkill)
    {
        this.skill = passiveSkill;

        skillImage.sprite = passiveSkill.icon;
        nameText.text = passiveSkill.name;
    }

    public void OnSelectedSkill()
    {
        GachaUI.Instance.SelectedSkill(skill);
    }
}
