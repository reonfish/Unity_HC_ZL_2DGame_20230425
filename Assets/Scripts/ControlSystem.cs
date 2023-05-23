using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    private void Awake()
    {
        print(666);
        print("嗨~");
        print("1 + 2");
        print($"{1 + 2}");
    }

    private void Start()
    {
        print("<color=yellow>開始事件</color>");
    }

    private void Update()
    {
        print("<color=#998877>更新事件</color>");
    }
}
