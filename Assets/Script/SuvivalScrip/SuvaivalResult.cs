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
        falloutCount.OnGameOver += ShowResult; // �C�x���g�w��
    }

    private void OnDisable()
    {
        falloutCount.OnGameOver -= ShowResult; // �C�x���g����
    }

    public void ShowResult()
    {
        Debug.Log("ShowResult called");
        resultPanel.SetActive(true);
        if (playerMove != null && scoreText != null && TimeText != null)
        {
            scoreText.text = $"�ێ�J�����[�F{playerMove.CurrentScore}cal";
            TimeText.text = $"�H�����ԁF{CountUpTimer.countUp / 60}�b";
        }
    }
}