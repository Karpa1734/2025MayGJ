using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // �w�肵���V�[�����ɐ؂�ւ��郁�\�b�h
    public void ChangeScene()
    {
        SceneManager.LoadScene("Main");
    }
}
