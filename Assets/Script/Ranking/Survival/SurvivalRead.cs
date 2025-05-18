using System.Collections.Generic;
using System;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Score�̃����L���O
/// </summary>
public class SurvivalRead : MonoBehaviour
{
    [SerializeField]
    private Text _rankingText = default;
    [SerializeField]
    private PlayerSet _playerSet = default;

    private string _RankingName = "SurvivalRanking"; // �C��: �X�y���~�X���C�� (Runking �� Ranking)
    private int _GetRanking = 10;
    private bool _isLoginAttempted = false;

    private void Start()
    {
        if (_playerSet == null)
        {
            Debug.LogError("PlayerSet���A�T�C������Ă��܂���");
            return;
        }

        if (PlayFabClientAPI.IsClientLoggedIn())
        {
            Debug.Log("���Ƀ��O�C���ς� - ���ڃ��[�_�[�{�[�h�擾");
            GetLeaderboard();
        }
        else
        {
            Debug.Log("���O�C������Ă��Ȃ� - �������O�C�����s");
            AnonymousLogin();
        }
    }

    /// <summary>
    /// �����L���O(���[�_�[�{�[�h)���擾
    /// </summary>
    public void GetLeaderboard()
    {
        if (!PlayFabClientAPI.IsClientLoggedIn())
        {
            Debug.LogWarning("���O�C������Ă��Ȃ����߃��[�_�[�{�[�h�擾�����s�ł��܂���");
            AnonymousLogin();
            return;
        }

        var request = new GetLeaderboardRequest
        {
            StatisticName = _RankingName,
            StartPosition = 0,
            MaxResultsCount = _GetRanking
        };

        Debug.Log($"�����L���O(���[�_�[�{�[�h)�̎擾�J�n");
        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboardSuccess, OnGetLeaderboardFailure);
    }

    private void OnGetLeaderboardSuccess(GetLeaderboardResult result)
    {
        Debug.Log($"�����L���O(���[�_�[�{�[�h)�̎擾�ɐ������܂���");

        _rankingText.text = "�b�ԃX�R�A�����L���O\n";
        foreach (var entry in result.Leaderboard)
        {
            // �����l(10�{���ꂽ�l)��b�ԃX�R�A�ɕϊ�
            float scorePerSecond = entry.StatValue / 10f;
            _rankingText.text += $"{Environment.NewLine}���� : {entry.Position + 1}, �b�ԃX�R�A : {scorePerSecond:F1}";
        }
    }

    private void OnGetLeaderboardFailure(PlayFabError error)
    {
        Debug.LogError($"�����L���O(���[�_�[�{�[�h)�̎擾�Ɏ��s���܂���\n{error.GenerateErrorReport()}");
    }

    /// <summary>
    /// �������O�C������
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
        Debug.Log("�������O�C�������I");
        _playerSet.InitializePlayer(result);
        GetLeaderboard();
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError($"�������O�C�����s: {error.GenerateErrorReport()}");
    }
}