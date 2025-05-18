using KanKikuchi.AudioManager;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Text Volume; 
    private int VolumeValue = 100; //���ʂ̒l
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
    public void AddVolume(int addV)
    {
        int newVolume = Mathf.Clamp(VolumeValue + addV, 0, 100);

        if (newVolume != VolumeValue)
        {
            VolumeValue = newVolume;
            Volume.text = VolumeValue.ToString();
            float normalizedVolume = VolumeValue / 100f;
            BGMManager.Instance.ChangeBaseVolume(normalizedVolume);
            SEManager.Instance.ChangeBaseVolume(normalizedVolume);
        }
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
