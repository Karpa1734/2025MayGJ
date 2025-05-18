using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �����L���O�̃T���v��
/// </summary>
public class ScoreSend : MonoBehaviour
{
    private string _RunkingName = "ScoreRunking";

    /// <summary>
    /// �X�R�A��PlayFab�ɑ��M����
    /// </summary>
    public void SendScoreToPlayFab(int score)
    {

        //UpdatePlayerStatisticsRequest�̃C���X�^���X�𐶐�
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = _RunkingName,
                    Value = score, // �X�R�A
                }
            }
        };

        // �X�R�A���M
        Debug.Log($"�X�R�A(���v���)�̍X�V�J�n");
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnUpdatePlayerStatisticsSuccess, OnUpdatePlayerStatisticsFailure);
    }

    //�X�R�A(���v���)�̍X�V����
    private void OnUpdatePlayerStatisticsSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log($"�X�R�A(���v���)�̍X�V���������܂���");
    }

    //�X�R�A(���v���)�̍X�V���s
    private void OnUpdatePlayerStatisticsFailure(PlayFabError error)
    {
        Debug.LogError($"�X�R�A(���v���)�X�V�Ɏ��s���܂���\n{error.GenerateErrorReport()}");
    }
}