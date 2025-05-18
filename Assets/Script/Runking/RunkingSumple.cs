using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �����L���O�̃T���v��
/// </summary>
public class RankingSample : MonoBehaviour
{

    [SerializeField]
    private Text _scoreText = default;
    [SerializeField]
    private Button _sendButton = default; // �{�^����Inspector���犄�蓖�Ă邽�߂̃t�B�[���h
    private string _RunkingName = "�����L���O�T���v��";

    private void Start()
    {
        // �{�^���̃N���b�N�C�x���g�Ƀ��\�b�h��o�^
        if (_sendButton != null)
        {
            _sendButton.onClick.AddListener(OnButtonClicked);
        }
    }

    // �{�^�����N���b�N���ꂽ���̏���
    private void OnButtonClicked()
    {
        // 0�`10000�̃����_���Ȑ����𐶐�
        int randomScore = Random.Range(0, 10001);

        // �X�R�A��UI�ɕ\���i�K�v�ɉ����āj
        if (_scoreText != null)
        {
            _scoreText.text = randomScore.ToString();
        }

        // �X�R�A��PlayFab�ɑ��M
        SendScoreToPlayFab(randomScore);
    }

    /// <summary>
    /// �X�R�A��PlayFab�ɑ��M����
    /// </summary>
    private void SendScoreToPlayFab(int score)
    {
        //UpdatePlayerStatisticsRequest�̃C���X�^���X�𐶐�
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>{
        new StatisticUpdate{
          StatisticName = _RunkingName,   //�����L���O��(���v���)
          Value = score, // �����_���ȃX�R�A
        }
      }
        };

        //���[�U���̍X�V
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