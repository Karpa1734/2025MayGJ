using UnityEngine;
using UnityEngine.SceneManagement;

public class Rsultmanager : MonoBehaviour
{
    // �w�肵���V�[�����ɐ؂�ւ��郁�\�b�h
    public void ReturnTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
