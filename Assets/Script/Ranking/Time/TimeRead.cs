using System.Collections.Generic;
using System;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Score�̃����L���O
/// </summary>
public class TimeRead : MonoBehaviour
{
    [SerializeField]
    private Text _rankingText = default;
    [SerializeField]
    private PlayerSet _playerSet = default;

    private string _RunkingName = "TimeRanking";
    private int _GetRunking = 10;
    private bool _isLoginAttempted = false;

    private void Start()
    {
        // PlayerSet���Q�Ƃ���Ă��邩�m�F
        if (_playerSet == null)
        {
            Debug.LogError("PlayerSet���A�T�C������Ă��܂���");
            return;
        }

        // ���Ƀ��O�C���ς݂��m�F
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
            StatisticName = _RunkingName,
            StartPosition = 0,
            MaxResultsCount = _GetRunking
        };

        Debug.Log($"�����L���O(���[�_�[�{�[�h)�̎擾�J�n");
        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboardSuccess, OnGetLeaderboardFailure);
    }

    private void OnGetLeaderboardSuccess(GetLeaderboardResult result)
    {
        Debug.Log($"�����L���O(���[�_�[�{�[�h)�̎擾�ɐ������܂���");

        _rankingText.text = "";
        foreach (var entry in result.Leaderboard)
        {
            // �N���A���Ԃ������ŕ\�����邽�߂ɁAint.MaxValue����������l��\��
            _rankingText.text += $"{Environment.NewLine}���� : {entry.Position + 1}, �N���A���� : {int.MaxValue - entry.StatValue}";
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
        // PlayerSet�Ƀ��O�C������ݒ�
        _playerSet.InitializePlayer(result);
        GetLeaderboard();
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError($"�������O�C�����s: {error.GenerateErrorReport()}");
        // ���g���C�����Ȃǂ������ɒǉ��\
    }
}