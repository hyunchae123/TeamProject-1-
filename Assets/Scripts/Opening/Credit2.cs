using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit2 : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("OpeningCredit") == true)
        {
            float animTime = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if(animTime >= 1.0f)
            {
                Application.Quit();
            }
        }
    }
}
