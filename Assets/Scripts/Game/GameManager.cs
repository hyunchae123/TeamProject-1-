using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] TalkManager1 talkManager;
    [SerializeField] TalkBundel1[] bundles1;
    [SerializeField] TalkBundel1[] bundles6;
    [SerializeField] TalkBundel1[] bundles8;
    [SerializeField] TalkBundel1[] bundles10;
    [SerializeField] TalkBundel1[] bundles12;
    [SerializeField] TalkBundel1[] bundles14;
    [SerializeField] TalkBundel1[] bundles16;
    [SerializeField] TalkBundel1[] bundles18;
    [SerializeField] TalkBundel1[] bundles22;
    [SerializeField] TalkBundel1[] bundles24;
    [SerializeField] TalkBundel1[] bundles26;
    [SerializeField] TalkBundel1[] bundles28;
    [SerializeField] TalkBundel1[] bundles30;
    [SerializeField] TalkBundel1[] bundles33;
    [SerializeField] TalkBundel1[] bundles35;

    public int StageNum;
    public int StateNum;

    public bool ActiveSkillQ;
    public bool ActiveSkillW;
    public bool ActiveSkillE;
    public bool ActiveSkillR;

    bool checkSkillQ;
    bool checkSkillW;
    bool checkSkillE;
    bool checkSkillR;

    public int monsterCount;

    public bool isPause;

    public bool onNockBack;
    public bool onSturn;
    public bool onSlow;

    bool checkStage2;
    bool checkStage3;
    bool checkStage4;
    bool checkStage5;
    bool checkStage6;
    bool checkStage7;
    bool checkStage8;
    bool checkStage9;
    bool checkStage10;
    bool checkStage11;
    bool checkStage12;
    bool checkStage13;
    bool checkStage14;
    bool checkStage15;
    bool checkStage16;
    bool checkStage17;
    bool checkStage18;
    bool checkStage19;

    void Start()
    {
        Invoke("FirstTalk", 0.5f);
        StageNum = 0;
        StateNum = 1;
    }

    private void Update()
    {
        if(PlayerMovement.Instance.level == 2 && checkSkillQ == false)
        {
            ActiveSkillQ = true;
            checkSkillQ = true;
        }

        if (PlayerMovement.Instance.level == 4 && checkSkillW == false)
        {
            ActiveSkillW = true;
            checkSkillW = true;
        }

        if (PlayerMovement.Instance.level == 6 && checkSkillE == false)
        {
            ActiveSkillE = true;
            checkSkillE = true;
        }

        if (PlayerMovement.Instance.level == 8 && checkSkillR == false)
        {
            ActiveSkillR = true;
            checkSkillR = true;
        }

        StageClear();
    }

    private void FirstTalk()
    {
        talkManager.StartTalk(bundles1[0]);
    }

    private void StageClear()
    {
        switch(StageNum) 
        {
            case 2:
                if (monsterCount == 5 && checkStage2 == false)
                {
                    talkManager.StartTalk(bundles6[0]);
                    SkillManager.Instance.SkillGacha2();
                    isPause = true;
                    checkStage2 = true;
                }
                break;
            case 3:
                if (monsterCount == 5 && checkStage3 == false)
                {
                    talkManager.StartTalk(bundles8[0]);
                    SkillManager.Instance.SkillGacha2();
                    isPause = true;
                    checkStage3 = true;
                }
                break;
            case 4:
                if (monsterCount == 5 && checkStage4 == false)
                {
                    talkManager.StartTalk(bundles10[0]);
                    SkillManager.Instance.SkillGacha2();
                    isPause = true;
                    checkStage4 = true;
                }
                break;
            case 5:
                if (monsterCount == 10 && checkStage5 == false)
                {
                    talkManager.StartTalk(bundles12[0]);
                    SkillManager.Instance.SkillGacha2();
                    isPause = true;
                    checkStage5 = true;
                }
                break;
            case 6:
                if (monsterCount == 10 && checkStage6 == false)
                {
                    talkManager.StartTalk(bundles14[0]);
                    SkillManager.Instance.SkillGacha2();
                    isPause = true;
                    checkStage6 = true;
                }
                break;
            case 7:
                if (monsterCount == 13 && checkStage7 == false)
                {
                    talkManager.StartTalk(bundles16[0]);
                    SkillManager.Instance.SkillGacha2();
                    isPause = true;
                    checkStage7 = true;
                }
                break;
            case 8:
                if (monsterCount == 1 && checkStage8 == false)
                {
                    talkManager.StartTalk(bundles18[0]);
                    SkillManager.Instance.SkillGacha2();
                    isPause = true;
                    checkStage8 = true;
                }
                break;
            case 9:
                if (monsterCount == 8 && checkStage9 == false)
                {
                    talkManager.StartTalk(bundles22[0]);
                    SkillManager.Instance.SkillGacha2();
                    isPause = true;
                    checkStage9 = true;
                }
                break;
            case 10:
                if (monsterCount == 12 && checkStage10 == false)
                {
                    talkManager.StartTalk(bundles24[0]);
                    SkillManager.Instance.SkillGacha2();
                    isPause = true;
                    checkStage10 = true;
                }
                break;
            case 11:
                if (monsterCount == 11 && checkStage11 == false)
                {
                    talkManager.StartTalk(bundles26[0]);
                    SkillManager.Instance.SkillGacha2();
                    isPause = true;
                    checkStage11 = true;
                }
                break;
            case 12:
                if (monsterCount == 13 && checkStage12 == false)
                {
                    talkManager.StartTalk(bundles28[0]);
                    SkillManager.Instance.SkillGacha2();
                    isPause = true;
                    checkStage12 = true;
                }
                break;
            case 13:
                if (monsterCount == 12 && checkStage13 == false)
                {
                    talkManager.StartTalk(bundles30[0]);
                    SkillManager.Instance.SkillGacha2();
                    isPause = true;
                    checkStage13 = true;
                }
                break;
            case 14:
                if (monsterCount == 14 && checkStage14 == false)
                {
                    talkManager.StartTalk(bundles33[0]);
                    SkillManager.Instance.SkillGacha2();
                    isPause = true;
                    checkStage14 = true;
                }
                break;
            case 18:
                if (monsterCount == 1 && checkStage18 == false)
                {
                    talkManager.StartTalk(bundles35[0]);
                    SkillManager.Instance.SkillGacha2();
                    isPause = true;
                    checkStage18 = true;
                }
                break;
        }
    }

}
