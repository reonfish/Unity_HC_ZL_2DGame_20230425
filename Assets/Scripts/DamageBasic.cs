using UnityEngine;

public class DamageBasic : MonoBehaviour
{
    [Header("資料")]
    public DataBasic data;
    [Header("傷害值預製物")]
    public GameObject prefabDamage;

    private float hp;

    private void Awake()
    {
        hp = data.hp;
    }

    public void Damage(float damage)
    {
        hp -= damage;

        Instantiate(prefabDamage, transform.position, transform.rotation);

        print($"<color=#ffee66>{gameObject.name} 血量剩下：{hp}</color>");

        if (hp <= 0) Dead();
    }

    private void Dead()
    {
        print($"<color=#ff9966>{gameObject.name} 死亡</color>");
    }
}
