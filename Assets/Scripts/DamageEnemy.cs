using UnityEngine;
using UnityEngine.Events;

public class DamageEnemy : DamageBasic
{
    [Header("死亡事件")]
    public UnityEvent onDead;
    private DataEnemy dataEnemy;
    private DamagePlayer damagePlayer;
    private void Start()
    {
        dataEnemy = (DataEnemy)data;
        //    print(dataEnemy.expProbability);
        damagePlayer = GameObject.Find("爆走企鵝").GetComponent<DamagePlayer>();
        if(name.Contains("Boss")) onDead.AddListener(() => damagePlayer.Win());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("武器"))
        {
            float damge = collision.gameObject.GetComponent<Weapon>().attack; 
            Damage(damge);  
        }
	}
	protected override void Dead()
    {
        base.Dead();
        onDead.Invoke();
        Destroy(gameObject);
        if(Random.value<dataEnemy.expProbability)
        {
            Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
        }
    }
}