using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeScaleController : MonoBehaviour
{
    // 預設的時間倍率，當沒有特定場景設定時使用
    [SerializeField] private float defaultTimeScale = 1f;

    // 用來存儲每個場景對應的時間倍率的配置陣列
    [SerializeField] private SceneTimeScale[] timeScales;

    // 當前的時間倍率，會隨著場景變化而更新
    [SerializeField] private float currentScale;

    // 在啟動時初始化
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); // 保證該物件在場景切換時不會被銷毀
        currentScale = defaultTimeScale; // 初始化當前時間倍率為預設值
    }

    // 註冊事件處理程序，當場景加載或卸載時呼叫相應方法
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // 註冊場景加載事件
        SceneManager.sceneUnloaded += OnSceneUnloaded; // 註冊場景卸載事件
    }

    // 註銷事件處理程序，防止場景加載和卸載時發生錯誤
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // 註銷場景加載事件
        SceneManager.sceneUnloaded -= OnSceneUnloaded; // 註銷場景卸載事件
    }

    // 當場景加載後，更新時間倍率
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) => UpdateTimeScale();

    // 當場景卸載後，更新時間倍率
    private void OnSceneUnloaded(Scene scene) => UpdateTimeScale();

    // 更新時間倍率的方法，根據當前加載的場景來設置時間倍率
    private void UpdateTimeScale()
    {
        // 遍歷所有的場景設定
        foreach (var scale in timeScales)
        {
            // 檢查每個加載的場景是否與設定中的場景匹配
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i).name == scale.SceneName)
                {
                    // 如果找到匹配的場景，設置對應的時間倍率並返回
                    SetTimeScale(scale.timeScale);
                    return;
                }
            }
        }
        // 如果沒有匹配的場景，恢復到預設時間倍率
        SetTimeScale(defaultTimeScale);
    }

    // 設置時間倍率並更新當前時間倍率
    private void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale; // 設置全局的時間倍率
        currentScale = timeScale; // 更新當前時間倍率
    }

    // 用於存儲場景名稱和相對應時間倍率的結構體
    [System.Serializable]
    public struct SceneTimeScale
    {
        public UnityEngine.Object sceneAsset; // 用於拖拽 .scene 資源
        public float timeScale;   // 這個場景的時間倍率

        // 根據場景資源返回場景名稱
        public string SceneName => sceneAsset ? sceneAsset.name : null;
    }
}
