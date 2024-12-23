using UnityEngine;

public class AnimationWithTimeScaleSwitch : MonoBehaviour
{
    private Animator animator;
    public bool isTimeScaleAffected = true; // 控制是否受 Time.timeScale 影響

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void StateSwitch()
    {
        isTimeScaleAffected = !isTimeScaleAffected;
    }

    void Update()
    {
        if (animator != null)
        {
            if (isTimeScaleAffected)
            {
                // 設置正常速度，動畫受 Time.timeScale 影響
                animator.speed = 1f;
            }
            else
            {
                // 設置動畫速度，確保動畫不受 Time.timeScale 影響
                animator.speed = 1f / Time.timeScale;
            }
        }
    }
}
