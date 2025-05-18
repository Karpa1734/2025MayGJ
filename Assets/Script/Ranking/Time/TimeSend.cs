using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// TIME�����L���O
/// </summary>
public class TimeSend : MonoBehaviour
{
    private string _RunkingName = "TimeRanking";

    //�����̐�����
    public void SendScoreToPlayFab(int seconds, int frames)
    {
        int combinedScore = seconds * 100 + frames;
        SendScoreToPlayFab(combinedScore);
    }

    // �X�R�A���M�i�����p�ɏC���j
    public void SendScoreToPlayFab(int time)
    {
        // ���������L���O�p�ɃX�R�A���C��
        int modifiedScore = int.MaxValue - time;

        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = _RunkingName,
                    Value = modifiedScore,  // �C�������X�R�A�𑗐M
                }
            }
        };

        Debug.Log($"����(���v���)�̍X�V�J�n");
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnUpdatePlayerStatisticsSuccess, OnUpdatePlayerStatisticsFailure);
    }

    //�X�R�A(���v���)�̍X�V����
    private void OnUpdatePlayerStatisticsSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log($"����(���v���)�̍X�V���������܂���");
    }

    //�X�R�A(���v���)�̍X�V���s
    private void OnUpdatePlayerStatisticsFailure(PlayFabError error)
    {
        Debug.LogError($"����(���v���)�X�V�Ɏ��s���܂���\n{error.GenerateErrorReport()}");
    }
}