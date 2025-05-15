using UnityEngine;
using UnityEngine.SceneManagement;

public class Rsultmanager : MonoBehaviour
{
    // 指定したシーン名に切り替えるメソッド
    public void ReturnTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
