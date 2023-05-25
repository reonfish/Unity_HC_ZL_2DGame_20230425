using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    [Header("移動速度")]
    [Range(0, 100)]
    public float moveSpeed = 3.5f;
    [Header("剛體")]
    public Rigidbody2D rig;

    private void Awake()
    {
        // print(666);
        // print("嗨~");
        // print("1 + 2");
        // print($"{1 + 2}");
    }

    private void Start()
    {
        // print("<color=yellow>開始事件</color>");
    }

    private void Update()
    {
        // print("<color=#998877>更新事件</color>");

        // 呼叫移動方法
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rig.velocity = new Vector2(h, v) * moveSpeed;
    }
}
