using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuvaivalResult : MonoBehaviour
{
[SerializeField] private GameObject resultPanel;
[SerializeField] private Text scoreText;
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
    resultPanel.SetActive(true);
    if (playerMove != null && scoreText != null)
    {
        scoreText.text = $"摂取カロリー：{playerMove.CurrentScore}cal";
    }
}
}
