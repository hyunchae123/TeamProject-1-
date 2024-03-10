using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUIManager : Singleton<DamageUIManager>
{
    [SerializeField] DamageUI prefab;
    [SerializeField] Camera cam;

    public void Show(float damage, Vector3 worldPosition)
    {
        Vector3 screenPosition = cam.WorldToScreenPoint(worldPosition);
        DamageUI newDamage = Instantiate(prefab, screenPosition, Quaternion.identity, transform);
        newDamage.Show(Mathf.FloorToInt(damage), worldPosition);
    }
}
