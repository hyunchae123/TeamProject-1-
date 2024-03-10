using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpBarUI : Singleton<ExpBarUI>
{
    [SerializeField] Image expImage;
    [SerializeField] TMP_Text levelText;

    public void UpdateExp(int exp, int maxExp)
    {
        expImage.fillAmount = exp / (float)maxExp;
    }

    public void UpdateLevel(int level)
    {
        levelText.text = $"Lv.{level}";
    }
}
