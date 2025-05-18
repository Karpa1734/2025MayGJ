using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class SurvivalSend : MonoBehaviour
{
    private string _rankingName = "SurvivalRanking";

    /// <summary>
    /// スコアと時間から秒間スコアを計算してPlayFabに送信
    /// </summary>
    public void SendCalculatedScore(int score, int seconds, int frames)
    {
        // 総時間を秒単位で計算（フレームは1/60秒と仮定）
        float totalTime = seconds + frames / 60f;
        
        // 秒間スコアを計算（0除算防止）
        float scorePerSecond = totalTime > 0 ? score / totalTime : 0;
        
        // 小数点第2位で四捨五入して第1位まで
        scorePerSecond = Mathf.Round(scorePerSecond * 10) / 10;
        
        // 整数化（10倍して小数点を除去）
        int intScore = Mathf.RoundToInt(scorePerSecond * 10);

        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = _rankingName,
                    Value = intScore,
                }
            }
        };

        Debug.Log($"秒間スコア送信: {scorePerSecond} (整数値: {intScore})");
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnSuccess, OnFailure);
    }

    private void OnSuccess(UpdatePlayerStatisticsResult result) => 
        Debug.Log("スコア送信成功");

    private void OnFailure(PlayFabError error) => 
        Debug.LogError($"スコア送信失敗\n{error.GenerateErrorReport()}");
}