using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class SurvivalSend : MonoBehaviour
{
    private string _rankingName = "SurvivalRanking";

    /// <summary>
    /// �X�R�A�Ǝ��Ԃ���b�ԃX�R�A���v�Z����PlayFab�ɑ��M
    /// </summary>
    public void SendCalculatedScore(int score, int seconds, int frames)
    {
        // �����Ԃ�b�P�ʂŌv�Z�i�t���[����1/60�b�Ɖ���j
        float totalTime = seconds + frames / 60f;
        
        // �b�ԃX�R�A���v�Z�i0���Z�h�~�j
        float scorePerSecond = totalTime > 0 ? score / totalTime : 0;
        
        // �����_��2�ʂŎl�̌ܓ����đ�1�ʂ܂�
        scorePerSecond = Mathf.Round(scorePerSecond * 10) / 10;
        
        // �������i10�{���ď����_�������j
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

        Debug.Log($"�b�ԃX�R�A���M: {scorePerSecond} (�����l: {intScore})");
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnSuccess, OnFailure);
    }

    private void OnSuccess(UpdatePlayerStatisticsResult result) => 
        Debug.Log("�X�R�A���M����");

    private void OnFailure(PlayFabError error) => 
        Debug.LogError($"�X�R�A���M���s\n{error.GenerateErrorReport()}");
}