# TimeScaleController
Unity場景時間控制器

主要說明：

程式用於調整特定場景的時間速度，用OnSceneLoaded和OnSceneUnloaded判定是否載入或關閉場景並呼叫UpdateTimeScale()，然後UpdateTimeScale()裡面是用foreach迴圈判定是否有運行特定場景，有的話就呼叫SetTimeScale()去設定Time.timeScale的值。

注意事項：

1.如果遊戲同時只會運行一個場景，可以不用for (int i = 0; i < SceneManager.sceneCount; i++)，直接if判定即可。也有其他特殊狀況，例如同時加載複數場景，且都需要改timeScale的情況，就需要根據需求調整程式碼了，應該是要設置優先級。

2.Time.timeScale會讓動畫、物理運算、Update()、FixedUpdate() 等的速度產生變化，如果想要讓某些物體不受timeScale的影響，可以把原本的Time.deltaTime改成Time.unscaledDeltaTime。動畫的話可以使用animator.speed = 1f / Time.timeScale之類的方法讓動畫不受影響。完整代碼可參考文件中的AnimationWithTimeScaleSwitch.cs與MovsWithTimeScaleSwitch.cs。
以上程式碼可應用在遊戲的慢動作的鏡頭特寫等其他情境，也歡迎補充與建議。
