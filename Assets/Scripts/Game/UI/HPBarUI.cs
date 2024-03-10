using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBarUI : MonoBehaviour
{
    [SerializeField] Image fillImageHP;
    [SerializeField] StatusManager status;
    [SerializeField] TMP_Text hpText;

    void Update()
    {
        fillImageHP.fillAmount = status.Hp / status.MaxHp;
        hpText.text = $"{status.Hp.ToString()} / {status.MaxHp.ToString()}";
    }
}
