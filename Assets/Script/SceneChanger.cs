using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // �w�肵���V�[�����ɐ؂�ւ��郁�\�b�h
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
