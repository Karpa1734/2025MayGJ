using UnityEngine;
using UnityEngine.UI;

public class Calory : MonoBehaviour
{
    [SerializeField] Text scoreText;               // 表示するText（UI）を設定
    [SerializeField] PlayerMover playerMove;       // PlayerMoveの参照を設定
    [SerializeField] float scoreSpeed = 1000f;     // 1秒あたりの加減算速度（調整可能）

    private float displayedScore = 0f;

    void Update()
    {
        if (playerMove == null || scoreText == null) return;

        float targetScore = playerMove.CurrentScore;

        // targetScoreに近づける（増減対応）
        if (displayedScore < targetScore)
        {
            displayedScore += scoreSpeed * Time.deltaTime;
            if (displayedScore > targetScore)
            {
                displayedScore = targetScore;
            }
        }
        else if (displayedScore > targetScore)
        {
            displayedScore -= scoreSpeed * Time.deltaTime;
            if (displayedScore < targetScore)
            {
                displayedScore = targetScore;
            }
        }

        // 表示は整数値でOK（端数切り捨て）
        scoreText.text = Mathf.FloorToInt(displayedScore).ToString() + "kcal";
    }
}
