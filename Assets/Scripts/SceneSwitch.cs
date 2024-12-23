using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SceneSwitch1()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void SceneSwitch2()
    {
        SceneManager.LoadScene("Scene2");
    }

}
