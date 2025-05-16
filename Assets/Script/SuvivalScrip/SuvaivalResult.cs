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
    falloutCount.OnGameOver += ShowResult; // �C�x���g�w��
}

private void OnDisable()
{
    falloutCount.OnGameOver -= ShowResult; // �C�x���g����
}

public void ShowResult()
{
    resultPanel.SetActive(true);
    if (playerMove != null && scoreText != null)
    {
        scoreText.text = $"�ێ�J�����[�F{playerMove.CurrentScore}cal";
    }
}
}
