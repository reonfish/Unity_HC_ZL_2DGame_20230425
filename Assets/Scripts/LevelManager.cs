using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

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
    public GameObject[] goSkillUI;

    /// <summary>
    /// 0 武器傷害
    /// 1 武器間隔
    /// 2 移動速度
    /// 3 吸取範圍
    /// 4 血量
    /// </summary>

    [Header("技能資料陣列")]
    public DataSkill[] dataSkills;
    public List<DataSkill> randomSkill = new List<DataSkill>();

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

        randomSkill = dataSkills.Where(skill => skill.skillLv < 5).ToList();
        randomSkill = randomSkill.OrderBy(skill => Random.Range(0, 999)).ToList();

        for (int i = 0; i < 3; i++) 
        {
            goSkillUI[i].transform.Find("技能名稱").GetComponent<TextMeshProUGUI>().text = randomSkill[i].skillName;
            goSkillUI[i].transform.Find("技能圖示").GetComponent<Image>().sprite = randomSkill[i].skillPicture;
            goSkillUI[i].transform.Find("文字描述").GetComponent<TextMeshProUGUI>().text = randomSkill[i].skillDescription;
            goSkillUI[i].transform.Find("技能等級").GetComponent<TextMeshProUGUI>().text = "Lv"+randomSkill[i].skillLv;

        }
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
    public void ClickSkillButton(int indexSkill) 
    {
        randomSkill[indexSkill].skillLv++;
        goLvUp.SetActive(false);
        Time.timeScale = 1;
        if (randomSkill[indexSkill].skillName == "經驗吸取") UpdateExpRange();
        if (randomSkill[indexSkill].skillName == "啤酒傷害") UpdateBeerAttack();
        if (randomSkill[indexSkill].skillName == "發射速度") UpdateBeerInterval();
        if (randomSkill[indexSkill].skillName == "血量") UpdatePlayerHp();
        if (randomSkill[indexSkill].skillName == "移動速度") UpdateMoveSpeed();

    }

    [Header("爆走企鵝")]
    public CircleCollider2D playerExpRamge;
    private void UpdateExpRange()
    {
        int lv = dataSkills[0].skillLv - 1;
        playerExpRamge.radius = dataSkills[0].skillValues[lv];
    }
    [Header("武器啤酒")]
    public WeaponSystem WeaponSystem;
    private void UpdateBeerAttack()
    {
        int lv = dataSkills[1].skillLv - 1;
        WeaponSystem.attack = dataSkills[1].skillValues[lv];
    }
    private void UpdateBeerInterval()
    {
        int lv = dataSkills[2].skillLv - 1;
        WeaponSystem.interval = dataSkills[2].skillValues[lv];
    }
    [Header("玩家血量")]
    public DataBasic DataBasic;
    private void UpdatePlayerHp()
    {
        int lv = dataSkills[3].skillLv - 1;
        DataBasic.hp = dataSkills[3].skillValues[lv];
    }
    [Header("爆走企鵝：控制系統")]
    public ControlSystem controlSystem;
    private void UpdateMoveSpeed()
    {
        int lv = dataSkills[4].skillLv - 1;
        controlSystem.moveSpeed = dataSkills[4].skillValues[lv];
    }
}


