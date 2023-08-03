using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageBasic
{
    [Header("血條")]
    public Image imgHP;
    [Header("控制系統")]
    public ControlSystem controlSystem;
    [Header("武器啤酒生成點")]
    public WeaponSystem weaponSystem;
    [Header("結束畫面")]
    public GameObject goFinal;
    [Header("結束標題")]
    public TextMeshProUGUI textFinal;
    //private void Start()
    //{
    //    Damage(50);
    //}
    public override void Damage(float damage) 
    {
        base.Damage(damage);
        imgHP.fillAmount = hp / hpMax;
    }
    protected override void Dead()
    {
        base.Dead();
        controlSystem.enabled = false;
        weaponSystem.stop();
        textFinal.text = "你已經死了..";
        goFinal.SetActive(true);
    }
}
