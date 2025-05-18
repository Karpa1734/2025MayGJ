using UnityEngine;
using UnityEngine.SceneManagement;

public class RunkingManager : MonoBehaviour
{
    public void ChangeSceneScoreRanking()
    {
        SceneManager.LoadScene(5);
    }
    public void ChangeSceneTimeRanking()
    {
        SceneManager.LoadScene(6);
    }
    public void ChangeSceneSurvivalRanking()
    {
        SceneManager.LoadScene(7);
    }
}
