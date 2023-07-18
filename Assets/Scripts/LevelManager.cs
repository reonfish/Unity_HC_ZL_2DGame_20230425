﻿using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("經驗值")]
    public Image imgExp;
    [Header("文字等級")]
    public TextMeshProUGUI textLv;
    [Header("文字經驗值")]
    public TextMeshProUGUI textExp;
    [Header("升級面板")]
    public GameObject goLvUp;
    [Header("技能1~3")]
    public GameObject goSkillUI1;
    public GameObject goSkillUI2;
    public GameObject goSkillUI3;

    private int lv = 1;
    private float exp = 0;

    public float[] expNeeds = { 100, 200, 300 };
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("經驗值"))
        {
            collision.GetComponent<ExpSystem>().enabled = true;
        }
    }

    public void AddExp(float exp) 
    {
        this.exp += exp;
        if (this.exp > expNeeds[lv - 1])
        {
            this.exp -= expNeeds[lv - 1];
            lv++;
            textLv.text = lv.ToString();
            LevelUp();
        }
        textExp.text = this.exp + " / "+ expNeeds[lv - 1];
        imgExp.fillAmount = this.exp / expNeeds[lv-1];
    }

    private void LevelUp()
    {
        goLvUp.SetActive(true);
        Time.timeScale = 0;
    }

    [ContextMenu("產生經驗值需求資料")]
    private void ExpNeeds() 
    {
        expNeeds = new float[100];
        for (int i = 0; i < 100; i++)
        {
            expNeeds[i] = (i + 1) * 100+i*(i+1);
        }
    
    }
}
