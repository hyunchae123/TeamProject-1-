using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : Singleton<SkillManager>
{
    [SerializeField] Image skillQ;
    [SerializeField] Image skillW;
    [SerializeField] Image skillE;
    [SerializeField] Image skillR;

    List<Skill> ActiveSkillList;
    List<Skill> PassiveSkillList;
    List<Skill> MixNAttackSkillList;

    bool changeBow;

    public int arrowCount;

    bool mixSkill1;
    bool mixSkill2;
    bool mixSkill3;
    bool mixSkill4;
    bool mixSkill5;
    bool mixSkill6;
    bool mixSkill7;
    bool mixSkill8;
    bool mixSkill9;

    public int PassiveSkill_1;
    public int PassiveSkill_2;
    public int PassiveSkill_3;
    public int PassiveSkill_4;
    public int PassiveSkill_5;
    public int PassiveSkill_6;
    public int PassiveSkill_7;
    public int PassiveSkill_8;
    public int PassiveSkill_9;
    public int PassiveSkill_10;
    public int PassiveSkill_11;
    public int PassiveSkill_12;
    public int PassiveSkill_13;
    public int PassiveSkill_14;
    public int PassiveSkill_15;
    public int PassiveSkill_16;
    public int PassiveSkill_17;
    public int PassiveSkill_18;
    public int PassiveSkill_19;
    public int PassiveSkill_20;
    public int PassiveSkill_21;


    bool checkQ;
    bool checkW;
    bool checkE;
    bool checkR;

    void Start()
    {
        arrowCount = 1;
        ActiveSkillList = new List<Skill>();
        PassiveSkillList = new List<Skill>();
        MixNAttackSkillList = new List<Skill>();

        skillQ.sprite = Resources.Load<Sprite>("Basic");
        skillW.sprite = Resources.Load<Sprite>("Basic");
        skillE.sprite = Resources.Load<Sprite>("Basic");
        skillR.sprite = Resources.Load<Sprite>("Basic");


        //스탯스킬
        PassiveSkillList.Add(new Skill("1", "공격력 증가", Resources.Load<Sprite>("UI_Skill_Icon_Buff")));
        PassiveSkillList.Add(new Skill("2", "공격속도 증가", Resources.Load<Sprite>("UI_Skill_Icon_Punches")));
        PassiveSkillList.Add(new Skill("3", "이동속도 증가", Resources.Load<Sprite>("UI_Skill_Icon_Slide")));
        PassiveSkillList.Add(new Skill("4", "회복력 증가", Resources.Load<Sprite>("UI_Skill_Icon_Heal")));
        PassiveSkillList.Add(new Skill("5", "체력 증가", Resources.Load<Sprite>("UI_Skill_Icon_Fly")));
        PassiveSkillList.Add(new Skill("10", "공격범위 증가", Resources.Load<Sprite>("UI_Skill_Icon_Fly")));

        //평타공격강화스킬
        if (GameManager.Instance.StateNum == 1)
        {
            MixNAttackSkillList.Add(new Skill("11", "발목 베기", Resources.Load<Sprite>("UI_Skill_Icon_Fly")));
            MixNAttackSkillList.Add(new Skill("6", "다중 베기", Resources.Load<Sprite>("UI_Skill_Icon_Claw")));
            MixNAttackSkillList.Add(new Skill("7", "밀어 치기", Resources.Load<Sprite>("UI_Skill_Icon_Slash")));
        }
    }

    private void Update()
    {
        if(GameManager.Instance.StateNum == 2 && changeBow == false)
        {

            MixNAttackSkillList.Clear();
            MixNAttackSkillList.Add(new Skill("8", "다중 화살", Resources.Load<Sprite>("UI_Skill_Icon_Arrow_Barrage")));
            MixNAttackSkillList.Add(new Skill("9", "강력 화살", Resources.Load<Sprite>("UI_Skill_Icon_SpiritArrows")));
            MixNAttackSkillList.Add(new Skill("12", "헤드샷", Resources.Load<Sprite>("UI_Skill_Icon_Fly")));

            changeBow = true;
        }

        ActiveSkill();
        PassiveSkill();
        DeleteSkill();
    }

    public Sprite SkillSprite(string ID)
    {
        
        Skill skill = ActiveSkillList.FirstOrDefault(c => c.ID == ID);

        if(skill == null) 
        {
            Debug.Log($"{ID}에 해당하는 스킬이 없습니다.");
        }
        
        return skill?.icon ?? null;
        
    }

    private void ActiveSkill()
    {
        if (GameManager.Instance.ActiveSkillQ == true && checkQ == false)
        {
            ActiveSkillList.Add(new Skill("Q", "그림자 발바닥", Resources.Load<Sprite>("UI_Skill_Icon_Dash")));
            skillQ.sprite = SkillSprite("Q");
            checkQ = true;
        }
        else if (GameManager.Instance.ActiveSkillQ == false && checkQ == true)
        {
            skillQ.sprite = Resources.Load<Sprite>("Basic");
        }
        else if (GameManager.Instance.ActiveSkillQ == true && checkQ == true)
        {
            skillQ.sprite = SkillSprite("Q");
        }

        if (GameManager.Instance.ActiveSkillW && checkW == false)
        {
            ActiveSkillList.Add(new Skill("W", "신비한 이동", Resources.Load<Sprite>("UI_Skill_Icon_Slide")));
            skillW.sprite = SkillSprite("W");
            checkW = true;
        }
        else if (GameManager.Instance.ActiveSkillW == false && checkW == true)
        {
            skillW.sprite = Resources.Load<Sprite>("Basic");
        }
        else if (GameManager.Instance.ActiveSkillW == true && checkW == true)
        {
            skillW.sprite = SkillSprite("W");
        }

        if (GameManager.Instance.ActiveSkillE && checkE == false)
        {
            ActiveSkillList.Add(new Skill("E", "힘의 소용돌이", Resources.Load<Sprite>("UI_Skill_Icon_Pound")));
            skillE.sprite = SkillSprite("E");
            checkE = true;
        }
        else if (GameManager.Instance.ActiveSkillE == false && checkE == true)
        {
            skillE.sprite = Resources.Load<Sprite>("Basic");
        }
        else if (GameManager.Instance.ActiveSkillE == true && checkE == true)
        {
            skillE.sprite = SkillSprite("E");
        }

        if (GameManager.Instance.ActiveSkillR && checkR == false)
        {
            ActiveSkillList.Add(new Skill("R", "그림자 숨기", Resources.Load<Sprite>("UI_Skill_Icon_Recon")));
            skillR.sprite = SkillSprite("R");
            checkR = true;
        }
        else if (GameManager.Instance.ActiveSkillR == false && checkR == true)
        {
            skillR.sprite = Resources.Load<Sprite>("Basic");
        }
        else if (GameManager.Instance.ActiveSkillR == true && checkR == true)
        {
            skillR.sprite = SkillSprite("R");
        }
    }

    private void PassiveSkill()
    {
        //조합스킬
        if (GameManager.Instance.StateNum == 1 && PassiveSkill_1 >= 1 && PassiveSkill_6 >= 4 && mixSkill1 == false)
        {
            MixNAttackSkillList.Add(new Skill("13", "검기", Resources.Load<Sprite>("UI_Skill_Icon_Claw")));
            mixSkill1 = true;
        }

        if(GameManager.Instance.StateNum == 1 && PassiveSkill_10 >= 1 && PassiveSkill_6 >= 4 && mixSkill2 == false)
        {
            MixNAttackSkillList.Add(new Skill("14", "발도술", Resources.Load<Sprite>("UI_Skill_Icon_Slash")));
            mixSkill2 = true;
        }

        if (GameManager.Instance.StateNum == 1 && PassiveSkill_5 >= 1 && PassiveSkill_7 >= 4 && mixSkill3 == false)
        {
            MixNAttackSkillList.Add(new Skill("15", "격노의 타격", Resources.Load<Sprite>("UI_Skill_Icon_Slash")));
            mixSkill3 = true;
        }

        if (GameManager.Instance.StateNum == 1 && PassiveSkill_2 >= 1 && PassiveSkill_7 >= 4 && mixSkill4 == false)
        {
            MixNAttackSkillList.Add(new Skill("16", "비상한 회전", Resources.Load<Sprite>("UI_Skill_Icon_Slash")));
            mixSkill4 = true;
        }

        if (GameManager.Instance.StateNum == 1 && PassiveSkill_3 >= 1 && PassiveSkill_11 >= 4 && mixSkill5 == false)
        {
            MixNAttackSkillList.Add(new Skill("17", "발목 파괴", Resources.Load<Sprite>("UI_Skill_Icon_Fly")));
            mixSkill5 = true;
        }

        if (GameManager.Instance.StateNum == 2 && PassiveSkill_4 >= 1 && PassiveSkill_9 >= 4 && mixSkill6 == false)
        {
            MixNAttackSkillList.Add(new Skill("19", "우아한 화살", Resources.Load<Sprite>("UI_Skill_Icon_SpiritArrows")));
            mixSkill6 = true;
        }

        if (GameManager.Instance.StateNum == 2 && PassiveSkill_10 >= 1 && PassiveSkill_12 >= 4 && mixSkill7 == false)
        {
            MixNAttackSkillList.Add(new Skill("21", "뇌절 화살", Resources.Load<Sprite>("UI_Skill_Icon_SpiritArrows")));
            mixSkill7 = true;
        }

        if (GameManager.Instance.StateNum == 2 && PassiveSkill_5 >= 1 && PassiveSkill_12 >= 4 && mixSkill8 == false)
        {
            MixNAttackSkillList.Add(new Skill("20", "심장 찌르기", Resources.Load<Sprite>("UI_Skill_Icon_SpiritArrows")));
            mixSkill8 = true;
        }

        if (GameManager.Instance.StateNum == 2 && PassiveSkill_2 >= 1 && PassiveSkill_8 >= 4 && mixSkill9 == false)
        {
            MixNAttackSkillList.Add(new Skill("18", "속사", Resources.Load<Sprite>("UI_Skill_Icon_SpiritArrows")));
            mixSkill9 = true;
        }
    }

    public void SkillGacha()
    {
        List<Skill> targets = MixNAttackSkillList.ToList();

        for (int i = 0; i < 100; i++) 
        {
            int ran1 = Random.Range(0, targets.Count);
            int ran2 = Random.Range(0, targets.Count);

            Skill temp = targets[ran1];
            targets[ran1] = targets[ran2];
            targets[ran2] = temp;
        }

        Skill[] SelectedSkills = targets.GetRange(0, 3).ToArray();
        GachaUI.Instance.OpenGacha(SelectedSkills);
    }

    public void SkillGacha2()
    {
        List<Skill> targets = PassiveSkillList.ToList();

        for (int i = 0; i < 100; i++)
        {
            int ran1 = Random.Range(0, targets.Count);
            int ran2 = Random.Range(0, targets.Count);

            Skill temp = targets[ran1];
            targets[ran1] = targets[ran2];
            targets[ran2] = temp;
        }

        Skill[] SelectedSkills = targets.GetRange(0, 3).ToArray();
        StageGachaUI.Instance.OpenGacha(SelectedSkills);
    }

    private void DeleteSkill()
    {
        if (PassiveSkill_13 >= 1)
        {
            Skill skill = MixNAttackSkillList.FirstOrDefault(c => c.ID == "13");
            MixNAttackSkillList.Remove(skill);
        }

        if (PassiveSkill_14 >= 1)
        {
            Skill skill = MixNAttackSkillList.FirstOrDefault(c => c.ID == "14");
            MixNAttackSkillList.Remove(skill);
        }

        if (PassiveSkill_15 >= 1)
        {
            Skill skill = MixNAttackSkillList.FirstOrDefault(c => c.ID == "15");
            MixNAttackSkillList.Remove(skill);
        }

        if (PassiveSkill_16 >= 1)
        {
            Skill skill = MixNAttackSkillList.FirstOrDefault(c => c.ID == "16");
            MixNAttackSkillList.Remove(skill);
        }

        if (PassiveSkill_17 >= 1)
        {
            Skill skill = MixNAttackSkillList.FirstOrDefault(c => c.ID == "17");
            MixNAttackSkillList.Remove(skill);
        }

        if (PassiveSkill_18 >= 1)
        {
            Skill skill = MixNAttackSkillList.FirstOrDefault(c => c.ID == "18");
            MixNAttackSkillList.Remove(skill);
        }

        if (PassiveSkill_19 >= 1)
        {
            Skill skill = MixNAttackSkillList.FirstOrDefault(c => c.ID == "19");
            MixNAttackSkillList.Remove(skill);
        }

        if (PassiveSkill_20 >= 1)
        {
            Skill skill = MixNAttackSkillList.FirstOrDefault(c => c.ID == "20");
            MixNAttackSkillList.Remove(skill);
        }

        if (PassiveSkill_21 >= 1)
        {
            Skill skill = MixNAttackSkillList.FirstOrDefault(c => c.ID == "21");
            MixNAttackSkillList.Remove(skill);
        }

    }

    public void SelectedSkill(Skill skill)
    {
        switch (skill.ID)
        {
            case "1":
                if (PassiveSkill_1 >= 4)
                    break;
                if (GameManager.Instance.StateNum == 1)
                    PlayerMovement.Instance.attackPower += 10 * 0.3f;
                else if(GameManager.Instance.StateNum == 2)
                {
                    PlayerMovement.Instance.arrowPower += 7 * 0.3f;
                }
                PassiveSkill_1++;
                break;
            case "2":
                if (PassiveSkill_2 >= 4)
                    break;
                PlayerMovement.Instance.waitTime -= PlayerMovement.Instance.waitTime * 0.25f;
                PassiveSkill_2++;
                break;
            case "3":
                if (PassiveSkill_3 >= 4)
                    break;
                PlayerMovement.Instance.moveSpeed += PlayerMovement.Instance.moveSpeed * 0.1f;
                PassiveSkill_3++;
                break;
            case "4":
                if (PassiveSkill_4 >= 4)
                    break;
                StatusManager.Instance.hp = Mathf.Clamp(StatusManager.Instance.hp + StatusManager.Instance.hp, 0, StatusManager.Instance.MaxHp);
                StatusManager.Instance.HPfillAmount++;
                PassiveSkill_4++;
                break;
            case "5":
                if (PassiveSkill_5 >= 4)
                    break;
                StatusManager.Instance.maxHp = Mathf.FloorToInt(StatusManager.Instance.maxHp + StatusManager.Instance.maxHp * 0.2f);
                PassiveSkill_5++;
                break;
            case "6":
                if (GameManager.Instance.StateNum == 1)
                {
                    if (PassiveSkill_6 >= 4)
                        break;
                    PlayerMovement.Instance.attackPower += 10 * 0.5f;
                    PlayerMovement.Instance.swordAttackRadius += PlayerMovement.Instance.swordAttackRadius * 0.2f;
                }
                PassiveSkill_6++;
                break;
            case "7":
                PassiveSkill_7++;
                if (GameManager.Instance.StateNum == 1)
                {
                    if (PassiveSkill_7 >= 4)
                        break;
                    PlayerMovement.Instance.attackPower += 10 * 0.5f;
                    GameManager.Instance.onNockBack = true;
                    PlayerMovement.Instance.knockbackRange = PlayerMovement.Instance.knockbackRange * PassiveSkill_7;
                }
                break;
            case "8":
                if (GameManager.Instance.StateNum == 2)
                {
                    if (PassiveSkill_8 >= 4)
                        break;
                    PlayerMovement.Instance.arrowPower = PlayerMovement.Instance.arrowPower * arrowCount + 7 * 0.5f;
                    if (arrowCount < 2)
                        arrowCount++;
                    PlayerMovement.Instance.arrowPower = PlayerMovement.Instance.arrowPower / arrowCount;
                }
                PassiveSkill_8++;
                break;
            case "9":
                if (GameManager.Instance.StateNum == 2)
                {
                    if (PassiveSkill_9 >= 4)
                        break;
                    PlayerMovement.Instance.arrowPower += 7 * 0.5f;
                }
                PassiveSkill_9++;
                break;
            case "10":
                if (GameManager.Instance.StateNum == 1)
                {
                    if (PassiveSkill_10 >= 4)
                        break;
                    PlayerMovement.Instance.swordAttackRadius += PlayerMovement.Instance.swordAttackRadius * 0.1f;
                }
                else if (GameManager.Instance.StateNum == 2)
                {
                    if (PassiveSkill_10 >= 4)
                        break;
                    PlayerMovement.Instance.bowAttackRadius += PlayerMovement.Instance.bowAttackRadius * 0.1f;
                }
                PassiveSkill_10++;
                break;

            case "11":
                if (GameManager.Instance.StateNum == 1)
                {
                    if (PassiveSkill_11 >= 4)
                        break;
                    PlayerMovement.Instance.attackPower += 10 * 0.5f;
                    GameManager.Instance.onSlow = true;
                }
                PassiveSkill_11++;
                break;
            case "12":
                if (GameManager.Instance.StateNum == 2)
                {
                    if (PassiveSkill_12 >= 4)
                        break;
                    PlayerMovement.Instance.arrowPower += 7 * 0.5f;
                    GameManager.Instance.onSturn = true;
                }
                PassiveSkill_12++;
                break;
            case "13":
                if(GameManager.Instance.StateNum == 1)
                {
                    PassiveSkill_13++;
                }
                break;

            case "14":
                if (GameManager.Instance.StateNum == 1)
                {
                    PassiveSkill_14++;
                }
                break;
            case "15":
                if (GameManager.Instance.StateNum == 1)
                {
                    PassiveSkill_15++;
                }
                break;
            case "16":
                if (GameManager.Instance.StateNum == 1)
                {
                    PassiveSkill_16++;
                }
                break;
            case "17":
                if (GameManager.Instance.StateNum == 1)
                {
                    PassiveSkill_17++;
                }
                break;
            case "18":
                if (GameManager.Instance.StateNum == 2)
                {
                    arrowCount++;
                    PassiveSkill_18++;
                    PlayerMovement.Instance.arrowPower = PlayerMovement.Instance.arrowPower / arrowCount;
                }
                break;
            case "19":
                if (GameManager.Instance.StateNum == 2)
                {
                    PlayerMovement.Instance.bowAttackRadius = PlayerMovement.Instance.bowAttackRadius * 2;
                    PassiveSkill_19++;
                }
                break;
            case "20":
                if (GameManager.Instance.StateNum == 2)
                {
                    PlayerMovement.Instance.sturnTime = 2.0f;
                    PassiveSkill_20++;
                }
                break;
            case "21":
                if (GameManager.Instance.StateNum == 2)
                {
                    PassiveSkill_21++;
                }
                break;



        }



    }
}
