using UnityEngine;

public class AnimationWithTimeScaleSwitch : MonoBehaviour
{
    private Animator animator;
    public bool isTimeScaleAffected = true; // ����O�_�� Time.timeScale �v�T

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
                // �]�m���`�t�סA�ʵe�� Time.timeScale �v�T
                animator.speed = 1f;
            }
            else
            {
                // �]�m�ʵe�t�סA�T�O�ʵe���� Time.timeScale �v�T
                animator.speed = 1f / Time.timeScale;
            }
        }
    }
}
