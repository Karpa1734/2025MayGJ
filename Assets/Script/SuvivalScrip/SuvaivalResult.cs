using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuvaivalResult : MonoBehaviour
{
    int frame = 0;

    [SerializeField] GameObject resultPanel;
    [SerializeField] Text scoreText;
    [SerializeField] PlayerMover playerMove;

    private void Start()
    {
        resultPanel.SetActive(false);
        // イベントを購読
        falloutCount.OnGameOver += HandleGameOver;
    }

    private void OnDestroy()
    {
        // イベントの購読解除
        falloutCount.OnGameOver -= HandleGameOver;
    }

    private void HandleGameOver()
    {
        resultPanel.SetActive(true);
        if (playerMove != null && scoreText != null)
        {
            scoreText.text = "摂取カロリー：" + playerMove.CurrentScore.ToString() + "cal";
        }
    }

    void Update()
    {
        if (TimeKeeper.countDown == 0)
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
