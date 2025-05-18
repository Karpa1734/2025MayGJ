using KanKikuchi.AudioManager;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public int resuleScore = 0;
    int frame = 0;
    bool ClearCall = false;
    [SerializeField] GameObject resultPanel; 
    [SerializeField] Text scoreText;              // �\������Text�iUI�j��ݒ�
    [SerializeField] PlayerMover playerMove;       // PlayerMove�̎Q�Ƃ�ݒ�
    [SerializeField] GameObject[] character;       // PlayerMove�̎Q�Ƃ�ݒ�
    [SerializeField] ScoreSend scoreSend;
    private void Start()
    {
        resultPanel.SetActive(false);
        character[0].SetActive(false);
        character[1].SetActive(false);
    }
    void Update()
    {
        if (TimeKeeper.countDown == 0)
        {

            resultPanel.SetActive(true);  
            if (!ClearCall)
            {
                if (playerMove.dumbbellcnt >= 8)
                {
                    SEManager.Instance.Play(SEPath.MUSCLE_CLEAR);
                    character[1].SetActive(true);
                }
                else
                {
                    SEManager.Instance.Play(SEPath.CLEAR);
                    character[0].SetActive(true);
                }
                ClearCall = true;
            }

            if (playerMove != null && scoreText != null)
            {
                scoreText.text = "�ێ�J�����[�F" + playerMove.CurrentScore.ToString() + "kcal";
                resuleScore = playerMove.CurrentScore;
                if (scoreSend != null)
                {
                    scoreSend.SendScoreToPlayFab(resuleScore);
                }
            }
        }
        if (TimeKeeper.countDown < 0)
        {
            frame++;
        }
    }
}
