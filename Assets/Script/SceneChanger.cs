using KanKikuchi.AudioManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void Start()
    {
        BGMManager.Instance.Play(BGMPath.TITLE);
    }
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
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
}
