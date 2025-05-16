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
        // �C�x���g���w��
        falloutCount.OnGameOver += HandleGameOver;
    }

    private void OnDestroy()
    {
        // �C�x���g�̍w�ǉ���
        falloutCount.OnGameOver -= HandleGameOver;
    }

    private void HandleGameOver()
    {
        resultPanel.SetActive(true);
        if (playerMove != null && scoreText != null)
        {
            scoreText.text = "�ێ�J�����[�F" + playerMove.CurrentScore.ToString() + "cal";
        }
    }

    void Update()
    {
        if (TimeKeeper.countDown == 0)
        {
            resultPanel.SetActive(true);
            if (playerMove != null && scoreText != null)
            {
                scoreText.text = "�ێ�J�����[�F" + playerMove.CurrentScore.ToString() + "cal";
            }
        }
        if (TimeKeeper.countDown < 0)
        {
            frame++;
        }
    }
}
