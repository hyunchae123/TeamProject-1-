using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    [SerializeField] TMP_Text damageText;
    [SerializeField] Animation anim;

    Vector3 worldPosition;

    public void Show(float damage, Vector3 worldPosition)
    {
        this.worldPosition = worldPosition;
        damageText.text = damage.ToString();
        anim.Play();
        StartCoroutine(IEPlay());
    }

    IEnumerator IEPlay()
    {
        Camera cam = Camera.main;
        Vector3 destination = worldPosition;

        while (anim.isPlaying) 
        {
            destination += Vector3.up * 3.0f * Time.deltaTime;
            transform.position = cam.WorldToScreenPoint(destination);
            yield return null;
        }
        
        Destroy(gameObject);
    }
}
