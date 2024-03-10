using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TalkManager1 : MonoBehaviour
{
    [SerializeField] GameObject talkPanel;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text talkText;
    [SerializeField] Image talkerImage;
    [SerializeField] Sprite[] sprites;

    private void Start()
    {
        talkPanel.SetActive(false);
    }
    public void StartTalk(TalkBundel1 bundle)
    {
        StartCoroutine(IETalk(bundle.talks));
    }

    private IEnumerator IETalk(Talk[] talks)
    {
        talkPanel.SetActive(true);

        GameManager.Instance.isPause = true;

        Queue<Talk> queue = new Queue<Talk>(talks);
        while(queue.Count > 0) 
        {
            Talk talk = queue.Dequeue();
            nameText.text = talk.name;
            talkText.text = talk.talk;
            talkerImage.sprite = sprites.FirstOrDefault(s => s.name == talk.spriteID);

            yield return StartCoroutine(Press());
        }

        talkPanel.SetActive(false);
        GameManager.Instance.isPause = false;

        if(GameManager.Instance.StageNum == 19)
            SceneManager.LoadScene("Ending");

    }

    private IEnumerator Press()
    {
        while(!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        yield return null;
    }
}
