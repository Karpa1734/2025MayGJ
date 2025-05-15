using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    int frame = 0;

    [SerializeField] GameObject resultPanel; 
    [SerializeField] Text scoreText;              // 表示するText（UI）を設定
    [SerializeField] PlayerMover playerMove;       // PlayerMoveの参照を設定
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
                scoreText.text = "摂取カロリー：" + playerMove.CurrentScore.ToString() + "cal";
            }
        }
        if (TimeKeeper.countDown < 0)
        {
            frame++;
        }
    }


}
