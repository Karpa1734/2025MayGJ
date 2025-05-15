using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    int frame = 0;

    [SerializeField] GameObject resultPanel; 
    [SerializeField] Text scoreText;              // �\������Text�iUI�j��ݒ�
    [SerializeField] PlayerMover playerMove;       // PlayerMove�̎Q�Ƃ�ݒ�
    private void Start()
    {
        resultPanel.SetActive(false);
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
