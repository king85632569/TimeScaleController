using UnityEngine;

public class MovsWithTimeScaleSwitch : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isTimeScaleAffected = true; // 控制是否受 Time.timeScale 影響
    public float resetInterval = 3f; // 重設座標的時間間隔（秒）
    private Vector3 initialPosition; // 初始位置
    private float timeSinceLastReset = 0f; // 距離上次重設的時間

    void Start()
    {
        initialPosition = transform.position; // 記錄物體的初始位置
    }

    public void StateSwitch()
    {
        isTimeScaleAffected = !isTimeScaleAffected;
    }


    void Update()
    {
        // 更新距離上次重設的時間
        if (isTimeScaleAffected)
        {
            timeSinceLastReset += Time.deltaTime; // Time.timeScale 影響
        }
        else
        {
            timeSinceLastReset += Time.unscaledDeltaTime; // 不受 Time.timeScale 影響
        }

        // 每隔 resetInterval 秒重設位置
        if (timeSinceLastReset >= resetInterval)
        {
            transform.position = initialPosition; // 重設座標
            timeSinceLastReset = 0f; // 重置計時器
        }

        // 移動操作（會受 Time.timeScale 影響）
        float move = moveSpeed * (isTimeScaleAffected ? Time.deltaTime : Time.unscaledDeltaTime);
        transform.Translate(move, 0f, 0f);
    }
}
