using UnityEngine;

[CreateAssetMenu(menuName = "KID/Data Enemy")]
public class DataEnemy : DataBasic
{
    [Header("掉落經驗值機率"), Range(0, 1)]
    public float expProbability;
    [Header("掉落經驗值預製物")]
    public GameObject prefabExp;
}
