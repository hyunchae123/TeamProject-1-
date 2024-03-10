using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGachaUI : Singleton<StageGachaUI>
{
    [SerializeField] GameObject panel;
    [SerializeField] StageSkillUI[] skillUIs;
    void Start()
    {
        panel.SetActive(false);
    }

    public void OpenGacha(Skill[] skills)
    {
        for (int i = 0; i < skills.Length; i++)
        {
            skillUIs[i].Setup(skills[i]);
        }

        panel.SetActive(true);
    }

    public void SelectedSkill(Skill skill)
    {
        panel.SetActive(false);
        GameManager.Instance.isPause = false;
        SkillManager.Instance.SelectedSkill(skill);
    }
}
