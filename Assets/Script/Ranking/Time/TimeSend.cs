using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// TIMEランキング
/// </summary>
public class TimeSend : MonoBehaviour
{
    private string _RunkingName = "TimeRanking";

    //数字の整数化
    public void SendScoreToPlayFab(int seconds, int frames)
    {
        int combinedScore = seconds * 100 + frames;
        SendScoreToPlayFab(combinedScore);
    }

    // スコア送信（昇順用に修正）
    public void SendScoreToPlayFab(int time)
    {
        // 昇順ランキング用にスコアを修正
        int modifiedScore = int.MaxValue - time;

        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = _RunkingName,
                    Value = modifiedScore,  // 修正したスコアを送信
                }
            }
        };

        Debug.Log($"時間(統計情報)の更新開始");
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnUpdatePlayerStatisticsSuccess, OnUpdatePlayerStatisticsFailure);
    }

    //スコア(統計情報)の更新成功
    private void OnUpdatePlayerStatisticsSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log($"時間(統計情報)の更新が成功しました");
    }

    //スコア(統計情報)の更新失敗
    private void OnUpdatePlayerStatisticsFailure(PlayFabError error)
    {
        Debug.LogError($"時間(統計情報)更新に失敗しました\n{error.GenerateErrorReport()}");
    }
}