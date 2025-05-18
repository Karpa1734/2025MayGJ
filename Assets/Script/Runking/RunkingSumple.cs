using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ランキングのサンプル
/// </summary>
public class RankingSample : MonoBehaviour
{

    [SerializeField]
    private Text _scoreText = default;
    [SerializeField]
    private Button _sendButton = default; // ボタンをInspectorから割り当てるためのフィールド
    private string _RunkingName = "ランキングサンプル";

    private void Start()
    {
        // ボタンのクリックイベントにメソッドを登録
        if (_sendButton != null)
        {
            _sendButton.onClick.AddListener(OnButtonClicked);
        }
    }

    // ボタンがクリックされた時の処理
    private void OnButtonClicked()
    {
        // 0～10000のランダムな数字を生成
        int randomScore = Random.Range(0, 10001);

        // スコアをUIに表示（必要に応じて）
        if (_scoreText != null)
        {
            _scoreText.text = randomScore.ToString();
        }

        // スコアをPlayFabに送信
        SendScoreToPlayFab(randomScore);
    }

    /// <summary>
    /// スコアをPlayFabに送信する
    /// </summary>
    private void SendScoreToPlayFab(int score)
    {
        //UpdatePlayerStatisticsRequestのインスタンスを生成
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>{
        new StatisticUpdate{
          StatisticName = _RunkingName,   //ランキング名(統計情報名)
          Value = score, // ランダムなスコア
        }
      }
        };

        //ユーザ名の更新
        Debug.Log($"スコア(統計情報)の更新開始");
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnUpdatePlayerStatisticsSuccess, OnUpdatePlayerStatisticsFailure);
    }

    //スコア(統計情報)の更新成功
    private void OnUpdatePlayerStatisticsSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log($"スコア(統計情報)の更新が成功しました");
    }

    //スコア(統計情報)の更新失敗
    private void OnUpdatePlayerStatisticsFailure(PlayFabError error)
    {
        Debug.LogError($"スコア(統計情報)更新に失敗しました\n{error.GenerateErrorReport()}");
    }
}