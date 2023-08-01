using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageBasic
{
    [Header("血條")]
    public Image imgHP;
    //private void Start()
    //{
    //    Damage(50);
    //}
    public override void Damage(float damage) 
    {
        base.Damage(damage);
        imgHP.fillAmount = hp / hpMax;
    }
}
