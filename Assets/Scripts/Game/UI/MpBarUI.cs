using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MpBarUI : MonoBehaviour
{
    [SerializeField] Image fillImageMP;
    [SerializeField] StatusManager status;
    [SerializeField] TMP_Text mpText;


    void Update()
    {
        fillImageMP.fillAmount = status.Mp / status.MaxMp;
        mpText.text = $"{status.Mp.ToString()} / {status.MaxMp.ToString()}";
    }
}
