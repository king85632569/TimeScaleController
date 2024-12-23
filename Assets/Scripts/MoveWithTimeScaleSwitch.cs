using UnityEngine;

public class MovsWithTimeScaleSwitch : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isTimeScaleAffected = true; // ����O�_�� Time.timeScale �v�T
    public float resetInterval = 3f; // ���]�y�Ъ��ɶ����j�]��^
    private Vector3 initialPosition; // ��l��m
    private float timeSinceLastReset = 0f; // �Z���W�����]���ɶ�

    void Start()
    {
        initialPosition = transform.position; // �O�����骺��l��m
    }

    public void StateSwitch()
    {
        isTimeScaleAffected = !isTimeScaleAffected;
    }


    void Update()
    {
        // ��s�Z���W�����]���ɶ�
        if (isTimeScaleAffected)
        {
            timeSinceLastReset += Time.deltaTime; // Time.timeScale �v�T
        }
        else
        {
            timeSinceLastReset += Time.unscaledDeltaTime; // ���� Time.timeScale �v�T
        }

        // �C�j resetInterval ���]��m
        if (timeSinceLastReset >= resetInterval)
        {
            transform.position = initialPosition; // ���]�y��
            timeSinceLastReset = 0f; // ���m�p�ɾ�
        }

        // ���ʾާ@�]�|�� Time.timeScale �v�T�^
        float move = moveSpeed * (isTimeScaleAffected ? Time.deltaTime : Time.unscaledDeltaTime);
        transform.Translate(move, 0f, 0f);
    }
}
