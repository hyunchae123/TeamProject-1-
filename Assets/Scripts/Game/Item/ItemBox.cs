using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : Singleton<ItemBox>
{
    [SerializeField] GameObject ItemPanel;
    [SerializeField] RuntimeAnimatorController SwordController;
    [SerializeField] RuntimeAnimatorController BowController;

    [SerializeField] Animator player;

    bool isOpen = false;
    bool isTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTrigger = false;
        }
    }

    private void Start()
    {
        ItemPanel.SetActive(false);
    }

    void Update()
    {
        if(isTrigger == true && Input.GetKeyDown(KeyCode.A) && isOpen == false) 
        {
            ItemPanel.SetActive(true);
            isOpen = !isOpen;
            GameManager.Instance.isPause = true;
        }

        else if (isTrigger == true && Input.GetKeyDown(KeyCode.A) && isOpen == true)
        {
            ItemPanel.SetActive(false);
            isOpen = !isOpen;
            GameManager.Instance.isPause = false;
        }
    }

    public void OnSelectedSword()
    {
        if(player != null)
        {
            GameManager.Instance.StateNum = 1;
            player.runtimeAnimatorController = SwordController;
        }
        
    }

    public void OnSelectedBow()
    {
        if (player != null)
        {
            GameManager.Instance.StateNum = 2;
            player.runtimeAnimatorController = BowController;
        }
    }
}
