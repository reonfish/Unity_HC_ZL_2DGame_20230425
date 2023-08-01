using Unity.VisualScripting;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    private Transform player;
    [Header("敵人資料")]
    public DataEnemy data;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0.3f, 0.5f);
        Gizmos.DrawSphere(transform.position, data.attackRange);
    }

    private void Awake()
    {
        player = GameObject.Find("爆走企鵝").transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        print(distance);
        if (distance > data.attackRange) 
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, data.moveSpeed * Time.deltaTime);
        }
    }
}
