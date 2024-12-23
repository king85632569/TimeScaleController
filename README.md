# TimeScaleController
場景時間控制器

主要做法：
是用OnSceneLoaded和OnSceneUnloaded判定是否載入或關閉場景並呼叫UpdateTimeScale()，然後UpdateTimeScale()裡面是用foreach迴圈判定是否有運行特定場景，有的話就呼叫SetTimeScale()去設定Time.timeScale的值。

注意事項：
1.如果遊戲同時只會運行一個場景，可以不用for (int i = 0; i < SceneManager.sceneCount; i++)，直接if判定即可。也有其他特殊狀況，例如同時加載複數場景，且都需要改timeScale的情況，就需要根據需求調整程式碼了，應該是要設定優先級，我這邊因為其中一個場景(Main)都是預設速度，所以不會有這狀況。

2.Time.timeScale會讓動畫、物理、Update()、FixedUpdate() 等的速度產生變化，然後如果想要讓某些物體不受timeScale的影響，可以把原本的Time.deltaTime改成Time.unscaledDeltaTime。動畫的話可以使用animator.speed = 1f / Time.timeScale之類的方法讓動畫不受影響。
