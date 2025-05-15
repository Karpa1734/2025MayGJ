using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // 指定したシーン名に切り替えるメソッド
    public void ChangeScene()
    {
        SceneManager.LoadScene("Main");
    }
}
