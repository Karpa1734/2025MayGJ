using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ランキングのをScoreの降順で送る
/// </summary>
public class ScoreSend : MonoBehaviour
{
    private string _RunkingName = "ScoreRanking";

    /// <summary>
    /// スコアをPlayFabに送信する
    /// </summary>
    public void SendScoreToPlayFab(int score)
    {

        //UpdatePlayerStatisticsRequestのインスタンスを生成
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = _RunkingName,
                    Value = score,
                }
            }
        };

        // スコア送信
        Debug.Log($"スコア(統計情報)の更新開始");
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnSuccess, OnFailure);
    }

    //スコア(統計情報)の更新成功
    private void OnSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log($"スコア(統計情報)の更新が成功しました");
    }

    //スコア(統計情報)の更新失敗
    private void OnFailure(PlayFabError error)
    {
        Debug.LogError($"スコア(統計情報)更新に失敗しました\n{error.GenerateErrorReport()}");
    }
}