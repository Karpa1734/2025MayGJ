using UnityEngine;
using UnityEngine.UI;

public class Calory : MonoBehaviour
{
    [SerializeField] Text scoreText;               // 表示するText（UI）を設定
    [SerializeField] PlayerMover playerMove;       // PlayerMoveの参照を設定
    [SerializeField] float scoreSpeed = 1000;      // 1秒あたりの加算速度（調整可能）

    private float displayedScore = 0f;

    void Update()
    {
        if (playerMove == null || scoreText == null) return;

        float targetScore = playerMove.CurrentScore;

        // 内部スコアに近づける（フレーム時間に応じて）
        if (displayedScore < targetScore)
        {
            displayedScore += scoreSpeed * Time.deltaTime;

            if (displayedScore > targetScore)
            {
                displayedScore = targetScore; // 超えたらピタッと止める
            }
        }

        // 表示は整数値でOK（端数切り捨て）
        scoreText.text = Mathf.FloorToInt(displayedScore).ToString() + "kcal";
    }
}
