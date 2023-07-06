using Unity.VisualScripting;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    private Transform player;
    [Header("敵人資料")]
    public DataEnemy data;

    private void Awake()
    {
        player = GameObject.Find("爆走企鵝").transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, data.moveSpeed * Time.deltaTime);
    }
}
