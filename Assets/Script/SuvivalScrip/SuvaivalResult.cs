using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
public class SuvaivalResult : MonoBehaviour
{
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text TimeText;
    [SerializeField] private PlayerMover playerMove;
    [SerializeField] private falloutCount falloutCounter;
    [SerializeField] private CountUpTimer CountUpTime;

    private void Start()
    {
        resultPanel.SetActive(false);
    }
    private void Update()
    {
        if (falloutCounter.IsGameOver)
        {
            ShowResult();
        }
    }
    public void ShowResult()
    {
        Debug.Log("ShowResult called");
        resultPanel.SetActive(true);
        if (playerMove != null && scoreText != null && TimeText != null)
        {
            scoreText.text = $"摂取カロリー：{playerMove.CurrentScore}cal";
            TimeText.text = $"食事時間：{string.Format("{0:00}:{1:00}", CountUpTime.seconds, CountUpTime.frames)}秒";
        }
    }
}