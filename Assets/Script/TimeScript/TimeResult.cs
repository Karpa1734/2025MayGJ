using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeResult : MonoBehaviour
{
    int frame = 0;
    int ResultScore = 10000;

    [SerializeField] GameObject resultPanel;
    [SerializeField] Text scoreText;              // �\������Text�iUI�j��ݒ�
    [SerializeField] PlayerMover playerMove;       // PlayerMove�̎Q�Ƃ�ݒ�
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
                scoreText.text = "�ێ�J�����[�F" + playerMove.CurrentScore.ToString() + "cal";
            }
        }
        if (TimeKeeper.countDown < 0)
        {
            frame++;
        }
    }
}
