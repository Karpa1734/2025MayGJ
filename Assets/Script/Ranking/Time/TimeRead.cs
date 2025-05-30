using System.Collections.Generic;
using System;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Scoreのランキング
/// </summary>
public class TimeRead : MonoBehaviour
{
    [SerializeField]
    private Text _rankingText = default;
    [SerializeField]
    private PlayerSet _playerSet = default;

    private string _RankingName = "TimeRanking";
    private int _GetRanking = 30;
    private bool _isLoginAttempted = false;

    private void Start()
    {
        // PlayerSetが参照されているか確認
        if (_playerSet == null)
        {
            Debug.LogError("PlayerSetがアサインされていません");
            return;
        }

        // 既にログイン済みか確認
        if (PlayFabClientAPI.IsClientLoggedIn())
        {
            Debug.Log("既にログイン済み - 直接リーダーボード取得");
            GetLeaderboard();
        }
        else
        {
            Debug.Log("ログインされていない - 匿名ログイン試行");
            AnonymousLogin();
        }
    }

    /// <summary>
    /// ランキング(リーダーボード)を取得
    /// </summary>
    public void GetLeaderboard()
    {
        if (!PlayFabClientAPI.IsClientLoggedIn())
        {
            Debug.LogWarning("ログインされていないためリーダーボード取得を試行できません");
            AnonymousLogin();
            return;
        }

        var request = new GetLeaderboardRequest
        {
            StatisticName = _RankingName,
            StartPosition = 0,
            MaxResultsCount = _GetRanking
        };

        Debug.Log($"ランキング(リーダーボード)の取得開始");
        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboardSuccess, OnGetLeaderboardFailure);
    }

    private void OnGetLeaderboardSuccess(GetLeaderboardResult result)
    {
        Debug.Log($"ランキング(リーダーボード)の取得に成功しました");

        _rankingText.text = "";
        foreach (var entry in result.Leaderboard)
        {
            // クリア時間を昇順で表示するために、int.MaxValueから引いた値を取得
            int rawTime = int.MaxValue - entry.StatValue;

            // 4桁の整数を小数点第二位までの小数に変換（例: 1234 → 12.34）
            string formattedTime = (rawTime / 100.0).ToString("F2");

            _rankingText.text += $"{Environment.NewLine}順位 : {entry.Position + 1}, 完食した時間 : {formattedTime}秒";
        }
    }

    private void OnGetLeaderboardFailure(PlayFabError error)
    {
        Debug.LogError($"ランキング(リーダーボード)の取得に失敗しました\n{error.GenerateErrorReport()}");
    }

    /// <summary>
    /// 匿名ログイン処理
    /// </summary>
    private void AnonymousLogin()
    {
        if (_isLoginAttempted) return;
        _isLoginAttempted = true;

        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("匿名ログイン成功！");
        // PlayerSetにログイン情報を設定
        _playerSet.InitializePlayer(result);
        GetLeaderboard();
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError($"匿名ログイン失敗: {error.GenerateErrorReport()}");
        // リトライ処理などをここに追加可能
    }
}