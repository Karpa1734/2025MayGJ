using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeResult : MonoBehaviour
{
    int frame = 0;
    int ResultScore = 10000;

    [SerializeField] GameObject resultPanel;
    [SerializeField] Text scoreText;              // 表示するText（UI）を設定
    [SerializeField] PlayerMover playerMove;       // PlayerMoveの参照を設定
    private void Start()
    {
        resultPanel.SetActive(false);
    }
    void Update()
    {
        if (playerMove.CurrentScore >= 10000)
        {
            resultPanel.SetActive(true);
            if (playerMove != null && scoreText != null)
            {
                scoreText.text = "摂取カロリー：" + playerMove.CurrentScore.ToString() + "cal";
            }
        }
        if (TimeKeeper.countDown < 0)
        {
            frame++;
        }
    }
}
