using Unity.VisualScripting;
using UnityEngine;

public class ExpSystem : MonoBehaviour
{
    private Transform player;
    private LevelManager levelManager;
    [Header("移動速度"), Range(0, 10)]
    public float speed = 3.5f;
    [Header("吸收範圍"), Range(0, 3)]
    public float distanceEat = 1;
    [Header("經驗值"), Range(0, 500)]
    public float exp = 30;

    private void Awake()
    {
        player = GameObject.Find("爆走企鵝").transform;
        levelManager = player.GetComponent<LevelManager>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, player.position) < distanceEat)
        {
            levelManager.AddExp(exp);
            Destroy(gameObject);
        }
    }
}
