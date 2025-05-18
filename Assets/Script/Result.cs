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
    [SerializeField] Text scoreText;              // 表示するText（UI）を設定
    [SerializeField] PlayerMover playerMove;       // PlayerMoveの参照を設定
    [SerializeField] GameObject[] character;       // PlayerMoveの参照を設定
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
                scoreText.text = "摂取カロリー：" + playerMove.CurrentScore.ToString() + "kcal";
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
