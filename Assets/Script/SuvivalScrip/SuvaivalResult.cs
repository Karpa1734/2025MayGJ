using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SuvaivalResult : MonoBehaviour
{
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text TimeText;
    [SerializeField] private PlayerMover playerMove;

    private void Start()
    {
        resultPanel.SetActive(false);
    }

    private void OnEnable()
    {
        falloutCount.OnGameOver += ShowResult; // イベント購読
    }

    private void OnDisable()
    {
        falloutCount.OnGameOver -= ShowResult; // イベント解除
    }

    public void ShowResult()
    {
        Debug.Log("ShowResult called");
        resultPanel.SetActive(true);
        if (playerMove != null && scoreText != null && TimeText != null)
        {
            scoreText.text = $"摂取カロリー：{playerMove.CurrentScore}cal";
            TimeText.text = $"食事時間：{CountUpTimer.countUp / 60}秒";
        }
    }
}