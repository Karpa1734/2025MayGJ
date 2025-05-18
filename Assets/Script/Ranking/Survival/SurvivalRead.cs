using System.Collections.Generic;
using System;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Scoreのランキング
/// </summary>
public class SurvivalRead : MonoBehaviour
{
    [SerializeField]
    private Text _rankingText = default;
    [SerializeField]
    private PlayerSet _playerSet = default;

    private string _RankingName = "SurvivalRanking"; // 修正: スペルミスを修正 (Runking → Ranking)
    private int _GetRanking = 10;
    private bool _isLoginAttempted = false;

    private void Start()
    {
        if (_playerSet == null)
        {
            Debug.LogError("PlayerSetがアサインされていません");
            return;
        }

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

        _rankingText.text = "秒間スコアランキング\n";
        foreach (var entry in result.Leaderboard)
        {
            // 整数値(10倍された値)を秒間スコアに変換
            float scorePerSecond = entry.StatValue / 10f;
            _rankingText.text += $"{Environment.NewLine}順位 : {entry.Position + 1}, 秒間スコア : {scorePerSecond:F1}";
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
        _playerSet.InitializePlayer(result);
        GetLeaderboard();
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError($"匿名ログイン失敗: {error.GenerateErrorReport()}");
    }
}