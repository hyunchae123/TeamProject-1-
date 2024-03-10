using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TalkTrigger1 : MonoBehaviour
{
    [SerializeField] TalkManager1 talkManager;
    [SerializeField] TalkBundel1[] bundles3;
    [SerializeField] TalkBundel1[] bundles4;
    [SerializeField] GameObject Emilie;

    bool isTrigger;
    bool checkTalk;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTrigger = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if( collision.tag == "Player" && checkTalk == true && GameManager.Instance.StageNum == 1)
        {
            Destroy(Emilie);
            talkManager.StartTalk(bundles4[0]);
        }
    }

    private void Update()
    {
        if (isTrigger == true && Input.GetKeyDown(KeyCode.A) && GameManager.Instance.StageNum == 1)
        {
            talkManager.StartTalk(bundles3[0]);
            isTrigger = false;
            checkTalk = true;
        }
    }
}
