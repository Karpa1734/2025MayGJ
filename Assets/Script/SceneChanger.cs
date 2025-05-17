using KanKikuchi.AudioManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void Start()
    {
        BGMManager.Instance.Play(BGMPath.TITLE);

    }
    // 指定したシーン名に切り替えるメソッド
    public void ChangeSceneScore()
    {
        SceneManager.LoadScene("Score");
    }
    public void ChangeSceneTime()
    {
        SceneManager.LoadScene("Time");
    }
    public void ChangeSceneSurvival()
    {
        SceneManager.LoadScene("Survival");
    }
}
