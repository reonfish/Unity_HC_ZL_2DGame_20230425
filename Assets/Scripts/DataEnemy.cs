﻿using UnityEngine;

[CreateAssetMenu(menuName = "KID/Data Enemy")]
public class DataEnemy : DataBasic
{
    [Header("掉落經驗值機率"), Range(0, 1)]
    public float expProbability;
    [Header("掉落經驗值預製物")]
    public GameObject prefabExp;
    [Header("攻擊範圍"), Range(0, 5)]
    public float attackRange = 2;
    [Header("攻擊間隔"), Range(0, 5)]
    public float attackInterval = 2.5f;

}
