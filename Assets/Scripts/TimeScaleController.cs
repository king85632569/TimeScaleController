using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeScaleController : MonoBehaviour
{
    // �w�]���ɶ����v�A��S���S�w�����]�w�ɨϥ�
    [SerializeField] private float defaultTimeScale = 1f;

    // �ΨӦs�x�C�ӳ����������ɶ����v���t�m�}�C
    [SerializeField] private SceneTimeScale[] timeScales;

    // ��e���ɶ����v�A�|�H�۳����ܤƦӧ�s
    [SerializeField] private float currentScale;

    // �b�Ұʮɪ�l��
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); // �O�ҸӪ���b���������ɤ��|�Q�P��
        currentScale = defaultTimeScale; // ��l�Ʒ�e�ɶ����v���w�]��
    }

    // ���U�ƥ�B�z�{�ǡA������[���Ψ����ɩI�s������k
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // ���U�����[���ƥ�
        SceneManager.sceneUnloaded += OnSceneUnloaded; // ���U���������ƥ�
    }

    // ���P�ƥ�B�z�{�ǡA��������[���M�����ɵo�Ϳ��~
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // ���P�����[���ƥ�
        SceneManager.sceneUnloaded -= OnSceneUnloaded; // ���P���������ƥ�
    }

    // ������[����A��s�ɶ����v
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) => UpdateTimeScale();

    // �����������A��s�ɶ����v
    private void OnSceneUnloaded(Scene scene) => UpdateTimeScale();

    // ��s�ɶ����v����k�A�ھڷ�e�[���������ӳ]�m�ɶ����v
    private void UpdateTimeScale()
    {
        // �M���Ҧ��������]�w
        foreach (var scale in timeScales)
        {
            // �ˬd�C�ӥ[���������O�_�P�]�w���������ǰt
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i).name == scale.SceneName)
                {
                    // �p�G���ǰt�������A�]�m�������ɶ����v�ê�^
                    SetTimeScale(scale.timeScale);
                    return;
                }
            }
        }
        // �p�G�S���ǰt�������A��_��w�]�ɶ����v
        SetTimeScale(defaultTimeScale);
    }

    // �]�m�ɶ����v�ç�s��e�ɶ����v
    private void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale; // �]�m�������ɶ����v
        currentScale = timeScale; // ��s��e�ɶ����v
    }

    // �Ω�s�x�����W�٩M�۹����ɶ����v�����c��
    [System.Serializable]
    public struct SceneTimeScale
    {
        public UnityEngine.Object sceneAsset; // �Ω��� .scene �귽
        public float timeScale;   // �o�ӳ������ɶ����v

        // �ھڳ����귽��^�����W��
        public string SceneName => sceneAsset ? sceneAsset.name : null;
    }
}
